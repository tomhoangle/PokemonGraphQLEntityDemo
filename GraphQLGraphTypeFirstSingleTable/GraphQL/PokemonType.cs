using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;
using GraphQLGraphTypeFirstSingleTable.Interfaces;
using GraphQLGraphTypeFirstSingleTable.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PokemonType : ObjectGraphType<PokemonData>
    {
        public PokemonType(ISpecieRepository specieRepository)
        {
            Field(a => a.Id, type: typeof(IntGraphType));
            Field(a => a.SpeciesId, type: typeof(IntGraphType));
            Field(a => a.Identifier);
            Field<SpecieType>(
                "Evolvution",
                resolve: context => specieRepository.GetEvolution(context.Source.SpeciesId)
                );
        }
    }
}
