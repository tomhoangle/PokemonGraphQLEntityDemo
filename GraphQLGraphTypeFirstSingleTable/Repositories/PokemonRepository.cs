using GraphQLGraphTypeFirstSingleTable.Interfaces;
using GraphQLGraphTypeFirstSingleTable.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GraphQLGraphTypeFirstSingleTable.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
        }

        public Task<PokemonData> GetPokemonById(int id)
        {
            return _context.PokemonData.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<List<PokemonData>> GetPokemons()
        {
            return _context.PokemonData.ToListAsync();
        }

    }
}
