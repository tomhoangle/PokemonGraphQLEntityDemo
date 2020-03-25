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
            Field(a => a.hasNextPage, type: typeof(BooleanGraphType));
            Field(a => a.currentPage, type: typeof(BooleanGraphType));
            Field<ListGraphType<PokemonType>>(
                "Pokemons",
                //resolve: context => pokemonRepository.GetPokemonPagination(first: context.Source.first, after: context.Source.after));
                resolve: context => 
                    {
                        if (context.Source.countPerPage != 0)
                        {
                            var totalPage = Math.Ceiling((double)context.Source.count / (double)context.Source.countPerPage);
                            var start = context.Source.countPerPage * (context.Source.currentPage - 1) + 1;
                            var end = start + context.Source.countPerPage;
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
