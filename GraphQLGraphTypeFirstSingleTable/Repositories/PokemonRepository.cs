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

        public Task<List<PokemonData>> GetPokemonPagination(int first = 0, int after = 0, int last = 0, string sortBy = "")
        {
            Task<List<PokemonData>> result = Task.FromResult(new List<PokemonData>());
            IQueryable<PokemonData> temp = Enumerable.Empty<PokemonData>().AsQueryable();
            /*if (last != 0)
            {
                result = _context.PokemonData.Where(a => a.Id >= first && a.Id < last).ToListAsync();
            }
            else
            {
                if (first != 0 && after != 0) result = _context.PokemonData.Where(a => a.Id > after && a.Id < (after + first + 1)).ToListAsync();
                else if (first != 0) result = _context.PokemonData.Where(a => a.Id <= first).ToListAsync();
                else if (after != 0) result = _context.PokemonData.Where(a => a.Id > after).ToListAsync();
                else result = _context.PokemonData.ToListAsync();
            }

            return result;*/
            if (last != 0)
            {
                temp = _context.PokemonData.Where(a => a.Id >= first && a.Id < last);
            }
            else
            {
                if (first != 0 && after != 0) temp = _context.PokemonData.Where(a => a.Id > after && a.Id < (after + first + 1));
                else if (first != 0) temp = _context.PokemonData.Where(a => a.Id <= first);
                else if (after != 0) temp = _context.PokemonData.Where(a => a.Id > after);
                else temp = _context.PokemonData;
            }

            if(!string.IsNullOrEmpty(sortBy))
            {
                temp = Helper.OrderBy(temp, sortBy, true);
            }
            
            return temp.ToListAsync();
        }

        public Task<List<PokemonData>> GetPokemons()
        {
            return _context.PokemonData.ToListAsync();
        }

    }
}
