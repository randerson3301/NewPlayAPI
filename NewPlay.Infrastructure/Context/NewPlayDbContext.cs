using Microsoft.EntityFrameworkCore;
using NewPlay.Domain.Models;

namespace NewPlay.Infrastructure.Context
{
    public class NewPlayDbContext : DbContext
    {
        public DbSet<Developer> Developer{get; set;}
        public DbSet<Game> Game{get; set;}
        public DbSet<GameGenre> GameGenre{get; set;}
        public DbSet<GamePlatform> GamePlatform{get; set;}
        public DbSet<Genre> Genre{get; set;}
        public DbSet<Platform> Platform{get; set;}
        public DbSet<Publisher> Publisher{get; set;}
        public DbSet<User> User{get; set;}
        public DbSet<UserGame> UserGame{get; set;}
        public DbSet<UserGenre> UserGenre{get; set;}
        public DbSet<UserPlatform> UserPlatform{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
            Database=NEXT_PLAY;Integrated Security=True");
        }
    }

}