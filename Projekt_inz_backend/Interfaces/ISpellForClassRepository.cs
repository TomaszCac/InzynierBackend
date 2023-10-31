using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ISpellForClassRepository
    {
        public ICollection<SpellForClass> GetSpellsForClasses();
        public ICollection<SpellForClass> GetSpellsForClassByClass(int classId);
        public ICollection<SpellForClass> GetSpellsForClassBySpell(int spellId);
    }
}
