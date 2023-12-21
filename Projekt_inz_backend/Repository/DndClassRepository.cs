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

        public bool CreateDndClass(int ownerId, DndClass dndClass)
        {
            User ownerEntity = _context.Users.Where(b => b.userID == ownerId).FirstOrDefault();
            dndClass.owner = ownerEntity;
            _context.Add(dndClass);
            return Save();
        }

        public bool DeleteDndClass(DndClass dndClass)
        {
            _context.Remove(dndClass);
            return Save();
        }

        public ICollection<Spell> GetClassSpells(int id)
        {
            var spellsUsed = _context.spellsForClasses.Where(b => b.classId == id).Select(b => b.spellUsed).ToList();
            return spellsUsed;
        }

        public DndClass GetDndClass(int id)
        {
            return _context.dndClasses.Where(b => b.classId == id).FirstOrDefault();
        }

        public ICollection<DndClass> GetDndClass(string name)
        {
            return _context.dndClasses.Where(b => b.className == name).ToList();
        }

        public ICollection<DndClass> GetDndClasses()
        {
            return _context.dndClasses.OrderBy(p => p.classId).ToList();
        }

        public ICollection<DndClass> GetDndClassesByOwner(int ownerId)
        {
            return _context.dndClasses.Where(b => b.owner.userID == ownerId).ToList();
        }

        public int GetOwnerId(int classId)
        {
            return _context.dndClasses.Where(b => b.classId == classId).Select(b => b.owner.userID).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDndClass(DndClass dndClass)
        {
            _context.Update(dndClass);
            return Save();
        }
        public ICollection<DndSubclass> GetSubclassesFromClass(int classid)
        {
            return _context.dndSubclasses.Where(b => b.inheritedClass.classId == classid).ToList();
        }
    }
}
