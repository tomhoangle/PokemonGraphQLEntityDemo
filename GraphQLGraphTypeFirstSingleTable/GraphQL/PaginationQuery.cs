using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Interfaces;
using GraphQLGraphTypeFirstSingleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PaginationQuery : ObjectGraphType
    {
        public PaginationQuery(IPokemonRepository pokemonRepository)
        {
            Field<PaginationType>(
                "PokemonPagination",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "first" }), new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                resolve: context =>
                    {
                        int totalCount;
                        using (var ctx = new PokemonContext())
                        {
                            totalCount = ctx.PokemonData.Count();
                        }
                        return new Pagination(totalCount, context.GetArgument<int>("first"), context.GetArgument<int>("last"));
                    }
                );
    }
}
