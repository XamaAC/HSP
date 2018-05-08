using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HSP.Models
{
    public partial class HearthStonePortalContext : DbContext
    {
        public virtual DbSet<DCardClasses> DCardClasses { get; set; }
        public virtual DbSet<DCardProperties> DCardProperties { get; set; }
        public virtual DbSet<DCards> DCards { get; set; }
        public virtual DbSet<DCardTypes> DCardTypes { get; set; }
        public virtual DbSet<DExpansions> DExpansions { get; set; }
        public virtual DbSet<DExpansionSets> DExpansionSets { get; set; }
        public virtual DbSet<DHeroClasses> DHeroClasses { get; set; }
        public virtual DbSet<DHeroClassSkins> DHeroClassSkins { get; set; }
		public HearthStonePortalContext(DbContextOptions<HearthStonePortalContext> options)
				: base(options)
				{ }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer(@"");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DCardClasses>(entity =>
            {
                entity.ToTable("D_CardClasses");

                entity.HasIndex(e => e.CardClass)
                    .HasName("UK_D_CardClasses")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardClass)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DCardProperties>(entity =>
            {
                entity.ToTable("D_CardProperties");

                entity.HasIndex(e => e.CardProperty)
                    .HasName("UK_D_CardProperties")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardProperty)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DCards>(entity =>
            {
                entity.ToTable("D_Cards");

                entity.HasIndex(e => e.Title)
                    .HasName("UK_D_Cards")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCardClass).HasColumnName("ID_CardClass");

                entity.Property(e => e.IdCardType).HasColumnName("ID_CardType");

                entity.Property(e => e.IdExpansion).HasColumnName("ID_Expansion");

                entity.Property(e => e.IdHeroClass).HasColumnName("ID_HeroClass");

                entity.Property(e => e.ImgDeckPath)
                    .HasColumnName("IMG_Deck_Path")
                    .HasMaxLength(255);

                entity.Property(e => e.ImgGoldenPath)
                    .HasColumnName("IMG_Golden_Path")
                    .HasMaxLength(255);

                entity.Property(e => e.ImgPath)
                    .HasColumnName("IMG_Path")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdExpansionNavigation)
                    .WithMany(p => p.DCards)
                    .HasForeignKey(d => d.IdExpansion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_Cards_D_Expansions");

                entity.HasOne(d => d.IdHeroClassNavigation)
                    .WithMany(p => p.DCards)
                    .HasForeignKey(d => d.IdHeroClass)
                    .HasConstraintName("FK_D_Cards_D_HeroClasses");
            });

            modelBuilder.Entity<DCardTypes>(entity =>
            {
                entity.ToTable("D_CardTypes");

                entity.HasIndex(e => e.CardType)
                    .HasName("UK_D_CardTypes")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DExpansions>(entity =>
            {
                entity.ToTable("D_Expansions");

                entity.HasIndex(e => e.Title)
                    .HasName("UK_D_Expansions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdExpansionSet)
                    .HasColumnName("ID_ExpansionSet")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.IdExpansionSetNavigation)
                    .WithMany(p => p.DExpansions)
                    .HasForeignKey(d => d.IdExpansionSet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_Expansions_D_ExpansionSets");
            });

            modelBuilder.Entity<DExpansionSets>(entity =>
            {
                entity.ToTable("D_ExpansionSets");

                entity.HasIndex(e => e.Title)
                    .HasName("UK_D_ExpansionSets");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DHeroClasses>(entity =>
            {
                entity.ToTable("D_HeroClasses");

                entity.HasIndex(e => e.ClassName)
                    .HasName("UK_D_HeroClasses")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdHeroClassDefaultSkin).HasColumnName("ID_HeroClassDefaultSkin");

                entity.HasOne(d => d.IdHeroClassDefaultSkinNavigation)
                    .WithMany(p => p.DHeroClasses)
                    .HasForeignKey(d => d.IdHeroClassDefaultSkin)
                    .HasConstraintName("FK_D_HeroClasses_D_HeroClassSkins");
            });

            modelBuilder.Entity<DHeroClassSkins>(entity =>
            {
                entity.ToTable("D_HeroClassSkins");

                entity.HasIndex(e => e.Title)
                    .HasName("UK_D_HeroClassSkins")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdHeroClass).HasColumnName("ID_HeroClass");

                entity.Property(e => e.ImgPath).HasColumnName("IMG_Path");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.IdHeroClassNavigation)
                    .WithMany(p => p.DHeroClassSkins)
                    .HasForeignKey(d => d.IdHeroClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_HeroClassSkins_D_HeroClasses");
            });
        }
    }
}
