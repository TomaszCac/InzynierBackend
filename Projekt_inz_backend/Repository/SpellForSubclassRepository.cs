using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class SpellForSubclassRepository : ISpellForSubclassRepository
    {
        private readonly DndDatabaseContext _context;

        public SpellForSubclassRepository(DndDatabaseContext context)
        {
            _context = context;
        }


        public bool CreateSpellForSubclass(int spellId, int subclassId, bool update = false)
        {
            SpellForSubclass SpellForClassEntity = new SpellForSubclass
            {
                subclassId = subclassId,
                spellId = spellId,
                spellUsed = _context.Spells.Where(b => b.spellId == spellId).FirstOrDefault(),
                usingSubclass = _context.dndSubclasses.Where(b => b.subclassId == subclassId).FirstOrDefault()

            };
            _context.Add(SpellForClassEntity);
            if (update)
            {
                return true;
            }
            else
                return Save();
        }

        public bool DeleteSpellForSubclass(SpellForSubclass spellForSubclass, bool update = false)
        {
            _context.Remove(spellForSubclass);

            if (update)
            {
                return true;
            }
            else
                return Save();
        }

        public ICollection<SpellForSubclass> GetSpellsForSubclassBySpell(int spellId)
        {
            return _context.spellsForSubclasses.Where(b => b.spellId == spellId).ToList();
        }

        public ICollection<SpellForSubclass> GetSpellsForSubclassBySubclass(int subclassId)
        {
            return _context.spellsForSubclasses.Where(b => b.subclassId == subclassId).ToList();
        }

        public ICollection<SpellForSubclass> GetSpellsForSubclasses()
        {
            return _context.spellsForSubclasses.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSpellForSubclass(int subclassOld, int subclassNew, int spellOld, int spellNew)
        {
            SpellForSubclass oldSpellForSubclassEntity = new SpellForSubclass
            {
                subclassId = subclassOld,
                spellId = spellOld,
                spellUsed = _context.Spells.Where(b => b.spellId == spellOld).FirstOrDefault(),
                usingSubclass = _context.dndSubclasses.Where(b => b.subclassId == subclassOld).FirstOrDefault()

            };
            DeleteSpellForSubclass(oldSpellForSubclassEntity, true);
            CreateSpellForSubclass(spellNew, subclassNew, true);
            return Save();
        }
    }
}
