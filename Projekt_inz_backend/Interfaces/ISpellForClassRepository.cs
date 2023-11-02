using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ISpellForClassRepository
    {
        public ICollection<SpellForClass> GetSpellsForClasses();
        public ICollection<SpellForClass> GetSpellsForClassByClass(int classId);
        public ICollection<SpellForClass> GetSpellsForClassBySpell(int spellId);
        bool CreateSpellForClass(int spellId, int classId, bool update = false);
        bool UpdateSpellForClass(int classOld, int classNew, int spellOld, int spellNew);
        bool DeleteSpellForClass(SpellForClass spellForClass, bool update = false);
        bool Save();
    }
}
