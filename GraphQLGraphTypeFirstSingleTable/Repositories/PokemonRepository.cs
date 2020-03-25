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

        public Task<List<PokemonData>> GetPokemonPagination(int first = 0, int after = 0, int last = 0)
        {
            if (last != 0)
            {
                return _context.PokemonData.Where(a => a.Id >= first && a.Id < last).ToListAsync();
            }
            else
            {
                if (first != 0 && after != 0) return _context.PokemonData.Where(a => a.Id > after && a.Id < (after + first + 1)).ToListAsync();
                else if (first != 0) return _context.PokemonData.Where(a => a.Id <= first).ToListAsync();
                else if (after != 0) return _context.PokemonData.Where(a => a.Id > after).ToListAsync();
                else return _context.PokemonData.ToListAsync();
            }
        }

        public Task<List<PokemonData>> GetPokemons()
        {
            return _context.PokemonData.ToListAsync();
        }

    }
}
