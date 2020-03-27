using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;
using GraphQLGraphTypeFirstSingleTable.Interfaces;
using System;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PaginationType : ObjectGraphType<Pagination>
    {
        public PaginationType(IPokemonRepository pokemonRepository)
        {
            Field(a => a.count, type: typeof(IntGraphType));
            Field(a => a.first, type: typeof(IntGraphType));
            Field(a => a.last, type: typeof(IntGraphType));
            Field(a => a.startCursor, type: typeof(IntGraphType));
            Field(a => a.endCursor, type: typeof(IntGraphType));
            Field(a => a.totalPages, type: typeof(IntGraphType));
            Field(a => a.hasNextPage, type: typeof(BooleanGraphType));
            Field(a => a.currentPage, type: typeof(BooleanGraphType));
            Field<ListGraphType<PokemonType>>(
                "Pokemons",
                resolve: context => 
                    {
                        if (context.Source.countPerPage != 0)
                        {
                            var start = context.Source.countPerPage * (context.Source.currentPage - 1) + 1;
                            var end = start + context.Source.countPerPage;
                            if(context.Source.after != 0)
                            {
                                start += context.Source.after;
                                end += context.Source.after;
                            }
                            else if(context.Source.first != 0)
                            {
                                if(end > context.Source.first)
                                {
                                    end = context.Source.first + 1;
                                }
                            }
                            return pokemonRepository.GetPokemonPagination(first: start, last: end);
                        }
                        else
                        {
                            return pokemonRepository.GetPokemonPagination(first: context.Source.first, after: context.Source.after);
                        }
                    }
                );
            Field<PageInfoType>(
                "PageInfo",
                resolve: context => new PageInfo(1,1,false));
        }
    }
}
