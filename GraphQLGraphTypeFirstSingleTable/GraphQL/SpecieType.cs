using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class SpecieType : ObjectGraphType<PokemonSpecies>
    {
        public SpecieType()
        {
            Field(a => a.Id, type: typeof(IntGraphType));
            Field(a => a.Identifier);
            Field(a => a.EvolvesFromSpeciesId, type: typeof(IntGraphType));
        }
    }
}
