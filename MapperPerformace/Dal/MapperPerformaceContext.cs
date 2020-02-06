using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MapperPerformace.Dal
{
    public partial class MapperPerformaceContext : DbContext
    {
        public MapperPerformaceContext()
        {
        }

        public MapperPerformaceContext(DbContextOptions<MapperPerformaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LocalEvent> LocalEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Program.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalEvent>(entity =>
            {
                entity.HasKey(e => e.LocalEventId)
                    .HasName("PK__LocalEve__781AEDD8610D491C");

                entity.Property(e => e.LocalEventId).HasColumnName("LocalEventID");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Hdata).HasColumnName("HData");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("PersonalID")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
