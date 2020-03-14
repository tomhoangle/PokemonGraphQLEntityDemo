using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PokemonType : ObjectGraphType<PokemonData>
    {
        public PokemonType()
        {
            Field(a => a.Id, type: typeof(IntGraphType));
            Field(a => a.SpeciesId, type: typeof(IntGraphType));
            Field(a => a.Identifier);
        }
    }
}
