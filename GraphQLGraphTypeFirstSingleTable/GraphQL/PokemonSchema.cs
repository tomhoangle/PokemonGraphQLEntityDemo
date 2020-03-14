using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PokemonSchema : Schema
    {
        public PokemonSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PokemonQuery>();
        }
    }
}
