using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class SpellForClassRepository : ISpellForClassRepository
    {
        private readonly DndDatabaseContext _context;

        public SpellForClassRepository(DndDatabaseContext context)
        {
            _context = context;   
        }

        public bool CreateSpellForClass(int spellId, int classId, bool update=false)
        {
            SpellForClass SpellForClassEntity = new SpellForClass {
                classId = classId,
                spellId = spellId,
                spellUsed = _context.Spells.Where(b => b.spellId == spellId).FirstOrDefault(),
                usingClass = _context.dndClasses.Where(b => b.classId == classId).FirstOrDefault()
                
            };
            _context.Add(SpellForClassEntity);
            if (update)
            {
                return true;
            }
            else
                return Save();
        }

        public bool DeleteSpellForClass(SpellForClass spellForClass, bool update = false)
        {
            _context.Remove(spellForClass);

            if (update)
            {
                return true;
            }
            else
                return Save();
        }

        public ICollection<SpellForClass> GetSpellsForClassByClass(int classId)
        {
            return _context.spellsForClasses.Where(b => b.classId == classId).ToList();
        }

        public ICollection<SpellForClass> GetSpellsForClassBySpell(int spellId)
        {
            return _context.spellsForClasses.Where(b => b.spellId == spellId).ToList();
        }

        public ICollection<SpellForClass> GetSpellsForClasses()
        {
            return _context.spellsForClasses.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UpdateSpellForClass(int classOld, int classNew, int spellOld, int spellNew)
        {
            SpellForClass oldSpellForClassEntity = new SpellForClass
            {
                classId = classOld,
                spellId = spellOld,
                spellUsed = _context.Spells.Where(b => b.spellId == spellOld).FirstOrDefault(),
                usingClass = _context.dndClasses.Where(b => b.classId == classOld).FirstOrDefault()

            };
            DeleteSpellForClass(oldSpellForClassEntity, true);
            CreateSpellForClass(spellNew, classNew, true);
            return Save();

        }
    }
}
