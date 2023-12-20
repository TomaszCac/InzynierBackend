using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IDndSubclassRepository
    {
        public ICollection<DndSubclass> GetSubclasses();
        public DndSubclass GetSubclass(int subclassId);
        public bool Save();
        public bool DeleteSubclass(DndSubclass subclass);
        public bool UpdateSubclass(DndSubclass subclass);
        public bool CreateSubclass(int ownerid, int classid, DndSubclass subclass);
        public ICollection<DndSubclass> GetSubclassesFromClass(int classid);
        int GetUserIdByName(string username);
        public int GetOwnerId(int subclassId);


    }
}
