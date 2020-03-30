using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Interfaces;
using GraphQLGraphTypeFirstSingleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PokemonQuery : ObjectGraphType
    {
        public PokemonQuery(IPokemonRepository pokemonRepository)
        {
            Field<ListGraphType<PokemonType>>(
                "AllPokemons",
                resolve: context => pokemonRepository.GetPokemons()
                );

            Field<PokemonType>(
                "PokemonById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => pokemonRepository.GetPokemonById((context.GetArgument<int>("id")))
                );

            Field<PaginationType>(
                "PokemonPagination",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "first", DefaultValue = 0 }, 
                    new QueryArgument<IntGraphType> { Name = "after", DefaultValue = 0 }, 
                    new QueryArgument<IntGraphType> { Name = "countPerPage", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "currentPage", DefaultValue = 0 },
                    new QueryArgument<StringGraphType> { Name = "sortBy" }
                    ),
                resolve: context =>
                {
                    int totalCount;
                    int totalPage;
                    var temp = context.GetArgument<int>("countPerPage");
                    using (var ctx = new PokemonContext())
                    {
                        totalCount = ctx.PokemonData.Count();
                        if (context.GetArgument<int>("countPerPage") != 0 && context.GetArgument<int>("first") != 0)
                        {
                            totalPage = (int)Math.Ceiling((double)context.GetArgument<int>("first") / temp);
                        }
                        else if (context.GetArgument<int>("countPerPage") != 0)
                        {
                            totalPage = (int)Math.Ceiling((double)ctx.PokemonData.Count() / temp);
                        }
                        else
                        {
                            totalPage = 0;
                        }
                        
                    }
                    return new Pagination(totalCount, context.GetArgument<int>("first"), context.GetArgument<int>("after"), context.GetArgument<int>("countPerPage"), context.GetArgument<int>("currentPage"), totalPage, context.GetArgument<string>("sortBy"));
                }
                );
        }
    }
}
