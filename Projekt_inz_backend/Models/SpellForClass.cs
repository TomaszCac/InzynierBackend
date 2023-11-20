using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class SpellForClass
    {
        public int spellId {  get; set; }
        public Spell spellUsed {  get; set; }
        public int classId { get; set; }
        public DndClass usingClass { get; set; }
    }
}
