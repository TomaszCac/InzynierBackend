﻿using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class DndSubclassRepository : IDndSubclassRepository
    {
        private readonly DndDatabaseContext _context;

        public DndSubclassRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public bool CreateSubclass(int ownerid, int classid, DndSubclass subclass)
        {
            User ownerEntity = _context.Users.Where(b => b.userID  == ownerid).FirstOrDefault();
            DndClass dndClassEntity = _context.dndClasses.Where(b => b.classID == classid).FirstOrDefault();
            subclass.owner = ownerEntity;
            subclass.inheritedClass = dndClassEntity;
            _context.Add(subclass);
            return Save();
            
        }

        public bool DeleteSubclass(DndSubclass subclass)
        {
            _context.Remove(subclass);
            return Save();
        }

        public DndSubclass GetSubclass(int subclassId)
        {
            return _context.dndSubclasses.Where(b => b.subclassID == subclassId).FirstOrDefault();
        }

        public ICollection<DndSubclass> GetSubclasses()
        {
            return _context.dndSubclasses.ToList();
        }

        public ICollection<DndSubclass> GetSubclassesFromClass(int classid)
        {
            return _context.dndSubclasses.Where(b => b.inheritedClass.classID == classid).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSubclass(DndSubclass subclass)
        {
            _context.Update(subclass);
            return Save();
        }
    }
}
