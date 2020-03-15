using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLGraphTypeFirstSingleTable.Models;

namespace GraphQLGraphTypeFirstSingleTable.Interfaces
{
    public interface ISpecieRepository
    {
        Task<PokemonSpecies> GetEvolution(int specieId);
    }
}
