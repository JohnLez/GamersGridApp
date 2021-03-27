﻿using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL
{
    public class ApplicationDbContext : IdentityDbContext<GGuser, CustomRole, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<UsersGamesRelation> UsersGames { get; set; }
        public DbSet<VideoGame> Games { get; set; }
        public DbSet<VideoGameAccount> GameAccounts { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<GGuser>().ToTable("Users");
            builder.Entity<GGuser>().HasIndex(u => u.Email).IsUnique();
            builder.Entity<GGuser>().HasIndex(u => u.NickName).IsUnique();

            builder.Entity<CustomRole>().ToTable("Roles");

            builder.Entity<UsersGamesRelation>().ToTable("UsersGamesRelations");
            builder.Entity<UsersGamesRelation>()
                .HasIndex(usr => new { usr.UserId, usr.GameId })
                .IsUnique();

            builder.Entity<VideoGame>().ToTable("VideoGames");




        }
    }
}
