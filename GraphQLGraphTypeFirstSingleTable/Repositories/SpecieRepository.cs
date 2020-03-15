using GraphQLGraphTypeFirstSingleTable.Interfaces;
using GraphQLGraphTypeFirstSingleTable.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.Repositories
{
    public class SpecieRepository : ISpecieRepository
    {
        private readonly PokemonContext _context;

        public SpecieRepository(PokemonContext context)
        {
            _context = context;
        }

        public Task<PokemonSpecies> GetEvolution(int specieId)
        {
            return _context.PokemonSpecies.SingleOrDefaultAsync(a => a.EvolvesFromSpeciesId == specieId);
        }
    }
}
