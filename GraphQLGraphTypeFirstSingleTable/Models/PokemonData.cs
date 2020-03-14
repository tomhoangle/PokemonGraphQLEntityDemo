using System;
using System.Collections.Generic;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public partial class PokemonData
    {
        public short Id { get; set; }
        public string Identifier { get; set; }
        public short SpeciesId { get; set; }
        public byte Height { get; set; }
        public short Weight { get; set; }
        public short BaseExperience { get; set; }
        public short Order { get; set; }
        public bool IsDefault { get; set; }
    }
}
