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
        public DbSet<DndClassFeature> dndClassFeatures { get; set; }
        public DbSet<RaceFeature> raceFeatures { get; set; }
        public DbSet<SpellForClass> spellsForClasses { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EnemyActionEconomy> enemyActions { get; set; }
        public DbSet<Item> Items { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpellForClass>(eb => { eb.HasKey(b => new { b.spellID, b.classID }); }
            );
            modelBuilder.Entity<SpellForClass>(eb => eb.HasOne(b => b.spellUsed).WithMany(b => b.usedBy).HasForeignKey(b => b.spellID).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<SpellForClass>(eb => eb.HasOne(b => b.usingClass).WithMany(b => b.usesSpells).HasForeignKey(b => b.classID).OnDelete(DeleteBehavior.ClientSetNull));
            
        }
    }
}
