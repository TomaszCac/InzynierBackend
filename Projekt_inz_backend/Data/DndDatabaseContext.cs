using Microsoft.EntityFrameworkCore;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Data
{
    public class DndDatabaseContext : DbContext
    {
        public DndDatabaseContext() 
        {
        }

        public DndDatabaseContext(DbContextOptions<DndDatabaseContext> options) : base(options) { 
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<DndClass> dndClasses { get; set; }
        public DbSet<CustomRaceFeature> customRaceFeatures { get; set; }
        public DbSet<CustomDndClassFeature> customDndClassFeatures { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EnemyActionEconomy> enemyActions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<DndSubclass> dndSubclasses { get; set; }
        public DbSet<CustomDndSubclassFeature> customDndSubclassFeatures { get; set; }
        public DbSet<Upvote> upvotes { get; set; }
        public DbSet<Character> characters {  get; set; }
    }
}
