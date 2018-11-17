using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sticky.Models;

namespace Sticky.Data
{
    public partial class Stickynotes210Context : IdentityDbContext
    {
        public Stickynotes210Context()
        {
        }

        public Stickynotes210Context(DbContextOptions<Stickynotes210Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Boards> Boards { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<UserBoards> UserBoards { get; set; }

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
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
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

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            */
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

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK__notes__OwnerBoar__5165187F");
            });

            modelBuilder.Entity<UserBoards>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.BoardId });

                entity.HasIndex(e => e.UserName)
                    .HasName("UserName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeUser)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.UserBoards)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserBoard__Board__5FB337D6");
            });
        }
    }
}
