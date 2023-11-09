using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class DndClass
    {
        [Key]
        public int classID { get; set; }
        public string className { get; set; }
        public string tableHeader {  get; set; }
        public string tableData { get; set; }
        public int? inheritedClassID { get; set; }
        public string classDescription { get; set; }
        public string multiclassReq { get; set; }
        public string hitDice { get; set; }
        public string hitPointsAtFirst { get; set; }
        public string hitPointsAtHigh { get; set; }
        public string armorProficency { get; set; }
        public string weaponProficency { get; set; }
        public string toolsProficency { get; set; }
        public string savingThrows { get; set; }
        public string skills { get; set; }
        public string equipment { get; set; }
        public User owner { get; set; }
        public ICollection<SpellForClass> usesSpells { get; set; }
        public ICollection<CustomDndClassFeature> customFeatures { get; set; }

    }
}
