using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public partial class PokemonContext : DbContext
    {
        public PokemonContext()
        {
        }

        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EvolutionTriggers> EvolutionTriggers { get; set; }
        public virtual DbSet<PokemonData> PokemonData { get; set; }
        public virtual DbSet<PokemonEvolution> PokemonEvolution { get; set; }
        public virtual DbSet<PokemonSpecies> PokemonSpecies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Tatlong;Database=Pokemon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<EvolutionTriggers>(entity =>
            {
                entity.ToTable("evolution_triggers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PokemonData>(entity =>
            {
                entity.ToTable("pokemon_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseExperience).HasColumnName("base_experience");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(50);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.SpeciesId).HasColumnName("species_id");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<PokemonEvolution>(entity =>
            {
                entity.ToTable("pokemon_evolution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EvolutionTriggerId).HasColumnName("evolution_trigger_id");

                entity.Property(e => e.EvolvedSpeciesId).HasColumnName("evolved_species_id");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.HeldItemId).HasColumnName("held_item_id");

                entity.Property(e => e.KnownMoveId).HasColumnName("known_move_id");

                entity.Property(e => e.KnownMoveTypeId).HasColumnName("known_move_type_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MinimumAffection).HasColumnName("minimum_affection");

                entity.Property(e => e.MinimumBeauty).HasColumnName("minimum_beauty");

                entity.Property(e => e.MinimumHappiness).HasColumnName("minimum_happiness");

                entity.Property(e => e.MinimumLevel).HasColumnName("minimum_level");

                entity.Property(e => e.NeedsOverworldRain).HasColumnName("needs_overworld_rain");

                entity.Property(e => e.PartySpeciesId).HasColumnName("party_species_id");

                entity.Property(e => e.PartyTypeId).HasColumnName("party_type_id");

                entity.Property(e => e.RelativePhysicalStats).HasColumnName("relative_physical_stats");

                entity.Property(e => e.TimeOfDay)
                    .HasColumnName("time_of_day")
                    .HasMaxLength(50);

                entity.Property(e => e.TradeSpeciesId).HasColumnName("trade_species_id");

                entity.Property(e => e.TriggerItemId).HasColumnName("trigger_item_id");

                entity.Property(e => e.TurnUpsideDown).HasColumnName("turn_upside_down");
            });

            modelBuilder.Entity<PokemonSpecies>(entity =>
            {
                entity.ToTable("pokemon_species");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseHappiness).HasColumnName("base_happiness");

                entity.Property(e => e.CaptureRate).HasColumnName("capture_rate");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ConquestOrder).HasColumnName("conquest_order");

                entity.Property(e => e.EvolutionChainId).HasColumnName("evolution_chain_id");

                entity.Property(e => e.EvolvesFromSpeciesId).HasColumnName("evolves_from_species_id");

                entity.Property(e => e.FormsSwitchable).HasColumnName("forms_switchable");

                entity.Property(e => e.GenderRate).HasColumnName("gender_rate");

                entity.Property(e => e.GenerationId).HasColumnName("generation_id");

                entity.Property(e => e.GrowthRateId).HasColumnName("growth_rate_id");

                entity.Property(e => e.HabitatId).HasColumnName("habitat_id");

                entity.Property(e => e.HasGenderDifferences).HasColumnName("has_gender_differences");

                entity.Property(e => e.HatchCounter).HasColumnName("hatch_counter");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(50);

                entity.Property(e => e.IsBaby).HasColumnName("is_baby");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.ShapeId).HasColumnName("shape_id");
            });
        }
    }
}
