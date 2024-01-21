using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class DndClass
    {
        [Key]
        public int classId { get; set; }
        public string className { get; set; }
        public string classTableHeader {  get; set; }
        public string classTableData { get; set; }
        public string spellTableHeader { get; set; }
        public string spellTableData { get; set; }
        public int? inheritedClassID { get; set; }
        public string classDescription { get; set; }
        public string classMulticlassReq { get; set; }
        public string classHitDice { get; set; }
        public string classHitPointsAtFirst { get; set; }
        public string classHitPointsAtHigh { get; set; }
        public string classArmorProficency { get; set; }
        public string classWeaponProficency { get; set; }
        public string classToolsProficency { get; set; }
        public string classSavingThrows { get; set; }
        public string classSkills { get; set; }
        public string classEquipment { get; set; }
        public User? owner { get; set; }
        public string ownerName { get; set; }
        public int upvotes { get; set; }
        public ICollection<SpellForClass> usesSpells { get; set; }
        public ICollection<DndSubclass> dndSubclasses { get; set; }
        public ICollection<CustomDndClassFeature> customFeatures { get; set; }
        public ICollection<Character> characters { get; set; }

    }
}
