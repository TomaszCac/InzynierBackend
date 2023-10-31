using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class DndClassRepository : IDndClassRepository
    {
        private readonly DndDatabaseContext _context;

        public DndClassRepository( DndDatabaseContext context)
        {
            _context = context;
        }

        public DndClass getDndClass(int id)
        {
            return _context.dndClasses.Where(b => b.classID == id).FirstOrDefault();
        }

        public ICollection<DndClass> GetDndClass(string name)
        {
            return _context.dndClasses.Where(b => b.className == name).ToList();
        }

        public ICollection<DndClass> getDndClasses()
        {
            return _context.dndClasses.OrderBy(p => p.classID).ToList();
        }

       
    }
}
