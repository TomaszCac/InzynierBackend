using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class Spell
    {
        [Key]
        public int spellID { get; set; }
        public string spellName { get; set; }
        public string spellSchool { get; set; }
        public string spellCasting { get; set; }
        public string spellRange { get; set; }
        public string spellDuration { get; set; }
        public string spellComponents { get; set; }
        public int spellLevel { get; set; }
        public string spellDesc { get; set; }
        public string spellAHL { get; set; }
        public User? owner { get; set; }
        public ICollection<SpellForClass> usedBy { get; set; }
    }
}
