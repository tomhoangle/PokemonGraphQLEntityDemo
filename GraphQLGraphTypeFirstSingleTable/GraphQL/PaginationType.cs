using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;
using GraphQLGraphTypeFirstSingleTable.Interfaces;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PaginationType : ObjectGraphType<Pagination>
    {
        public PaginationType(IPokemonRepository pokemonRepository)
        {
            Field(a => a.count, type: typeof(IntGraphType));
            Field<ListGraphType<PokemonType>>(
                "Pokemons",
                resolve: context => pokemonRepository.GetPokemons());
        }
    }
}
