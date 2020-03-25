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
                    new QueryArgument<IntGraphType> { Name = "currentPage", DefaultValue = 0 }
                    ),
                resolve: context =>
                {
                    int totalCount;
                    using (var ctx = new PokemonContext())
                    {
                        totalCount = ctx.PokemonData.Count();
                    }
                    return new Pagination(totalCount, context.GetArgument<int>("first"), context.GetArgument<int>("after"), context.GetArgument<int>("countPerPage"), context.GetArgument<int>("currentPage"));
                }
                );
        }
    }
}
