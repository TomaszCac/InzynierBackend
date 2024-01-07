using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Enemy
    {
        [Key]
        public int enemyId { get; set; }
        public string enemyName { get; set; }
        public string enemySize { get; set; }
        public string enemyRace { get; set; }
        public string enemyArmorClass { get; set; }
        public string enemyHealth { get; set; }
        public int enemyStrength { get; set; }
        public int enemyDexterity { get; set; }
        public int enemyConstitution { get; set; }
        public int enemyInteligence { get; set; }
        public int enemyWisdom { get; set; }
        public int enemyCharisma { get; set; }
        public string enemySpeed { get; set; }
        public string enemySavingThrows { get; set; }
        public string enemySkills { get; set; }
        public string enemyImmunes { get; set; }
        public string enemyResistances { get; set; }
        public string enemyVulnerabilities { get; set; }
        public string enemySenses { get; set; }
        public string enemyLanguages { get; set; }
        public string enemyDangerLvl { get; set; }
        public string enemyProficencyBonus { get; set; }
        public User? owner { get; set; }
        public string ownerName { get; set; }
        public int upvotes { get; set; }
        public ICollection<EnemyActionEconomy> actionEcononomy { get; set; }
    }
}
