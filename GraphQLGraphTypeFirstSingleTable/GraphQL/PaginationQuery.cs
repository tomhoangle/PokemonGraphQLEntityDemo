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
        public PaginationQuery()
        {

            int totalCount;
            using (var context = new PokemonContext())
            {
                totalCount = context.PokemonData.Count();  //FromSql("Select Count(*) from pokemon_data").ToList().;
            }

            Field<PaginationType>(
                "PokemonPagination",
                resolve: context => new Pagination(totalCount)
                );
        }
    }
}
