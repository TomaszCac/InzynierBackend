﻿using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IDndClassRepository
    {
        ICollection<DndClass> GetDndClasses();
        DndClass GetDndClass(int id);
        ICollection<DndClass> GetDndClass(string name);
        bool CreateDndClass(int ownerId, DndClass dndClass);
        bool DeleteDndClass(DndClass dndClass);
        bool UpdateDndClass(DndClass dndClass);
        bool Save();
        ICollection<Spell> GetClassSpells(int id);
        
        
        
    }
}
