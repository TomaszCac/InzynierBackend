using Projekt_inz_backend.Models;

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
        public int GetOwnerId(int classId);
        public int GetUserIdByName(string username);
        ICollection<DndClass> GetDndClassesByOwner(int ownerId);
        public ICollection<DndSubclass> GetSubclassesFromClass(int classid);
        public bool Upvote(int userid, int classid);
        public bool CheckUpvote(int userid, int classid);
        public ICollection<DndClass> UpvotedList(int userid);



    }
}
