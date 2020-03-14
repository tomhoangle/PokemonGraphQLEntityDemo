using System;
using System.Collections.Generic;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public partial class PokemonSpecies
    {
        public short Id { get; set; }
        public string Identifier { get; set; }
        public byte GenerationId { get; set; }
        public short? EvolvesFromSpeciesId { get; set; }
        public short EvolutionChainId { get; set; }
        public byte ColorId { get; set; }
        public byte ShapeId { get; set; }
        public byte? HabitatId { get; set; }
        public short GenderRate { get; set; }
        public byte CaptureRate { get; set; }
        public byte BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public byte HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public byte GrowthRateId { get; set; }
        public bool FormsSwitchable { get; set; }
        public short Order { get; set; }
        public byte? ConquestOrder { get; set; }
    }
}
