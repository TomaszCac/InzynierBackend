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
        public DbSet<SpellForClass> spellsForClasses { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EnemyActionEconomy> enemyActions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<DndSubclass> dndSubclasses { get; set; }
        public DbSet<CustomDndSubclassFeature> customDndSubclassFeatures { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpellForClass>(eb => { eb.HasKey(b => new { b.spellId, b.classId }); }
            );
            modelBuilder.Entity<SpellForClass>(eb => eb.HasOne(b => b.spellUsed).WithMany(b => b.usedBy).HasForeignKey(b => b.spellId).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<SpellForClass>(eb => eb.HasOne(b => b.usingClass).WithMany(b => b.usesSpells).HasForeignKey(b => b.classId).OnDelete(DeleteBehavior.ClientSetNull));
            
        }
    }
}
