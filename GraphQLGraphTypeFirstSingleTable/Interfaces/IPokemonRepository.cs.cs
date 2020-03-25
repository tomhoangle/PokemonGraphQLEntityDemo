using GraphQLGraphTypeFirstSingleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.Interfaces
{
    public interface IPokemonRepository
    {
        Task<List<PokemonData>> GetPokemons();
        Task<List<PokemonData>> GetPokemonPagination(int first = 0, int after = 0, int last = 0);
        Task<PokemonData> GetPokemonById(int id);
    }
}
