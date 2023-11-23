using Microsoft.EntityFrameworkCore;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface ISpellForSubclassRepository
    {
        bool CreateSpellForSubclass(int spellId, int subclassId, bool update = false);
        bool Save();
        public ICollection<SpellForSubclass> GetSpellsForSubclasses();
        public ICollection<SpellForSubclass> GetSpellsForSubclassBySubclass(int subclassId);
        public ICollection<SpellForSubclass> GetSpellsForSubclassBySpell(int spellId);
        bool UpdateSpellForSubclass(int subclassOld, int subclassNew, int spellOld, int spellNew);
        bool DeleteSpellForSubclass(SpellForSubclass spellForSubclass, bool update = false);
    }
}
