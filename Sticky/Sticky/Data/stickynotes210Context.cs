using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sticky.Models;

namespace Sticky.Data
{
    public partial class Stickynotes210Context : DbContext
    {
        private static readonly Stickynotes210Context Singleton = new Stickynotes210Context();

        private Stickynotes210Context()
        {
        }

        /// <summary>
        /// Enforces singleton pattern
        /// </summary>
        /// <returns> The instance of this context </returns>
        public static Stickynotes210Context getStickyNotes210Context()
        {
            return Singleton;
        }

        public Stickynotes210Context(DbContextOptions<Stickynotes210Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Boards> Boards { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=csc210finalproject.database.windows.net;Database=sticky-notes-210;User ID=csc210;Password=MyAwesomePassword210!;Trusted_Connection=False;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boards>(entity =>
            {
                entity.HasKey(e => e.BoardId);

                entity.ToTable("boards");

                entity.Property(e => e.BoardId).ValueGeneratedNever();

                entity.Property(e => e.BoardType)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.ToTable("notes");

                entity.Property(e => e.NoteId).ValueGeneratedNever();

                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.Color)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FontColor)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FontName)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.LastEdit).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.OwnerBoardNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.OwnerBoard)
                    .HasConstraintName("FK__notes__OwnerBoar__5165187F");
            });
        }
    }
}
