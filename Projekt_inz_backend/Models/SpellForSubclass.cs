namespace Projekt_inz_backend.Models
{
    public class SpellForSubclass
    {
        public int spellId { get; set; }
        public Spell spellUsed { get; set; }
        public int subclassId { get; set; }
        public DndSubclass usingSubclass { get; set; }
    }
}
