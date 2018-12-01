
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
        public DbSet<Board> Boards { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //For many to many relationships of boards and users
          /*  builder.Entity<Note>()
                .HasOne(n => n.Board)
                .WithMany(b => b.Notes)
                .HasForeignKey(n => n.BoardID);

            builder.Entity<Invite>()
                .HasOne(i => i.Board)
                .WithMany(b => b.InvitesSent)
                .HasForeignKey(i => i.BoardID);

            builder.Entity<UserBoard>()
                .HasKey(ub => new { ub.Board, ub.ApplicationUser });

            builder.Entity<UserBoard>()
                .HasOne(ub => ub.Board)
                .WithMany(b => b.UserBoards)
                .HasForeignKey(ub => ub.BoardID);

           builder.Entity<UserBoard>()
                .HasOne(ub => ub.ApplicationUser)
                .WithMany(u => u.UserBoards)
                .HasForeignKey(ub => ub.ApplicationUserID); */
               

            
        }

    }
}
