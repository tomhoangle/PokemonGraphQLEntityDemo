using System;
using System.Collections.Generic;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public partial class PokemonEvolution
    {
        public short Id { get; set; }
        public short EvolvedSpeciesId { get; set; }
        public byte EvolutionTriggerId { get; set; }
        public byte? TriggerItemId { get; set; }
        public byte? MinimumLevel { get; set; }
        public byte? GenderId { get; set; }
        public short? LocationId { get; set; }
        public short? HeldItemId { get; set; }
        public string TimeOfDay { get; set; }
        public short? KnownMoveId { get; set; }
        public byte? KnownMoveTypeId { get; set; }
        public byte? MinimumHappiness { get; set; }
        public byte? MinimumBeauty { get; set; }
        public byte? MinimumAffection { get; set; }
        public short? RelativePhysicalStats { get; set; }
        public byte? PartySpeciesId { get; set; }
        public byte? PartyTypeId { get; set; }
        public short? TradeSpeciesId { get; set; }
        public bool NeedsOverworldRain { get; set; }
        public bool TurnUpsideDown { get; set; }
    }
}
