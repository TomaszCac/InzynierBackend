using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IDndClassRepository
    {
        ICollection<DndClass> getDndClasses();
        DndClass getDndClass(int id);
        ICollection<DndClass> GetDndClass(string name);
        
        
        
    }
}
