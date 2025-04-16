using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.EntityFramework.Context
{
    public class RouletteDbContext : DbContext
    {

        public RouletteDbContext(DbContextOptions<RouletteDbContext> dbContextOptions): base(dbContextOptions) { }
        
            public DbSet<Users> Users =>  Set<Users>();
            public DbSet<Bets> Bets => Set<Bets>();
            public DbSet<Results> Results => Set<Results>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Users>(builder =>
            {
                builder.ToTable("users");

                builder.HasKey(u => u.id);

                builder.Property(u => u.name)
                .IsRequired()
                .HasMaxLength(100);

                builder.Property(u => u.balance)
                .HasColumnType("numeric(10,2)");

                builder.HasMany(u => u.Bets)
                       .WithOne(b => b.Users)
                       .HasForeignKey(b => b.userid)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Bets>(builder => 
            {
                builder.ToTable("bets");

                builder.HasKey(b => b.id);

                builder.Property(b => b.betamount)
                .HasColumnType("numeric(10,2)");

                builder.Property(b => b.bettype)
                .IsRequired()
                .HasMaxLength(100);

                builder.Property(b => b.betvalue)
                .IsRequired()
                .HasMaxLength(100);

                builder.Property(b => b.date)
                .HasColumnType("timestamp");

                builder.HasOne(b => b.Result)
                       .WithOne(r => r.Bet)
                       .HasForeignKey<Results>(r => r.betId);
            
                

            });


            modelBuilder.Entity<Results>(builder => 
            {
                builder.ToTable("results");

                builder.HasKey(r => r.id);

                builder.Property(r => r.randomroulette)
                .IsRequired();

                builder.Property(r => r.colorroulette)
                .IsRequired()
                .HasMaxLength(100);

                builder.Property(r => r.result)
                .IsRequired();

                builder.Property(r => r.prizeamount)
                .HasColumnType("numeric(10,2)");
            });

            base.OnModelCreating(modelBuilder);
        }


    }
  
}

    