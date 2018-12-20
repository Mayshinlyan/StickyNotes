
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sticky.Models;
using Microsoft;

namespace Sticky.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Boards> Boards { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserBoards> UserBoards { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Maps models/Database stuff
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            builder.Entity<Boards>(entity =>
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

            builder.Entity<Notes>(entity =>
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

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK__notes__OwnerBoar__5165187F");
            });

            builder.Entity<UserBoards>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.BoardId });

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.TypeUser)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.UserBoards)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserBoard__Board__5FB337D6");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.UserBoards)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserBoards__Id__7F2BE32F");
            });
            
        }

    }
}
