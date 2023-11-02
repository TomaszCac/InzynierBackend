﻿using Projekt_inz_backend.Data;
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
            var spellsUsed = _context.spellsForClasses.Where(b => b.classID == id).Select(b => b.spellUsed).ToList();
            return spellsUsed;
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
    }
}
