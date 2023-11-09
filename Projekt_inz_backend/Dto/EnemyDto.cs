using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Dto
{
    public class EnemyDto
    {
        public int? EnemyID { get; set; }
        public string EnemyName { get; set; }
        public string size { get; set; }
        public string race { get; set; }
        public string armorClass { get; set; }
        public string health { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int inteligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }
        public string speed { get; set; }
        public string savingThrows { get; set; }
        public string skills { get; set; }
        public string immunes { get; set; }
        public string resistances { get; set; }
        public string vulnerabilities { get; set; }
        public string senses { get; set; }
        public string languages { get; set; }
        public string dangerLvl { get; set; }
        public string proficencyBonus { get; set; }
    }
}
