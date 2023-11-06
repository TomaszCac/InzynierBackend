using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class EnemyFeature
    {
        [Key]
        public int featureID {  get; set; }
        public string size {  get; set; }
        public string race { get; set; }
        public string armorClass {  get; set; }
        public string health { get; set; }
        public string strength { get; set; }
        public string dexterity {  get; set; }
        public string constitution { get; set; }
        public string inteligence { get; set; }
        public string wisdom {  get; set; }
        public string charisma {  get; set; }
        public string speed { get; set; }
        public string savingThrows {  get; set; }
        public string skills {  get; set; }
        public string immunes { get; set; }
        public string resistances { get; set; }
        public string vulnerabilities { get; set; }
        public string senses { get; set; }
        public string languages { get; set; }
        public string dangerLvl { get; set; }
        public string proficencyBonus { get; set; }
        public int enemyID { get; set; }
        public Enemy usedBy { get; set; }
    }
}
