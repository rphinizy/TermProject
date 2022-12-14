using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class DogContext : DbContext
    {
        public DogContext(DbContextOptions<DogContext> options)
            :base(options)
        { }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Origin> Origins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Origin>().HasData(
                new Origin { OriginId = "E", Planet = "Earth" },
                new Origin { OriginId = "M", Planet = "Mars" },
                new Origin { OriginId = "B", Planet = "Bellerophon" }
                );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = "M", Sex = "Male" },
                new Gender { GenderId = "F", Sex = "Female" }
                );


            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    DogId =1,
                    Name ="Daisy",
                    Breed="Bulldog",
                    Age=2,
                    Weight=45,
                    OriginId="E",
                    GenderId="F"
                },

                new Dog
                {
                    DogId = 2,
                    Name = "Fido",
                    Breed = "Mix",
                    Age = 6,
                    Weight = 30,
                    OriginId = "M",
                    GenderId ="M"
                },

                new Dog
                {
                    DogId = 3,
                    Name = "Bingo",
                    Breed = "Labrador",
                    Age = 1,
                    Weight = 60,
                    OriginId = "E",
                    GenderId ="M"
                },

                new Dog
                {
                    DogId = 4,
                    Name = "Balto",
                    Breed = "Husky",
                    Age = 8,
                    Weight = 55,
                    OriginId = "E",
                    GenderId = "M"
                },

                new Dog
                {
                    DogId = 5,
                    Name = "Meezork",
                    Breed = "blarphog",
                    Age = 72,
                    Weight = 5,
                    OriginId = "B",
                    GenderId = "M"
                }

                );
        }
    }
  
}
