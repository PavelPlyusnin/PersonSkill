using Microsoft.EntityFrameworkCore;

namespace PersonSkill.DataModels
{
    public sealed class Conext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(local)\\MSSQLLocalDB;Database=PersonSkill;Trusted_Connection=True;Data Source=localhost;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .HasMany(e => e.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}


