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

        public ICollection<SpellForClass> GetSpellsForClassByClass(int classId)
        {
            return _context.spellsForClasses.Where(b => b.classID == classId).ToList();
        }

        public ICollection<SpellForClass> GetSpellsForClassBySpell(int spellId)
        {
            return _context.spellsForClasses.Where(b => b.spellID == spellId).ToList();
        }

        public ICollection<SpellForClass> GetSpellsForClasses()
        {
            return _context.spellsForClasses.ToList();
        }
    }
}
