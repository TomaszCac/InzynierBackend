using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IDndSubclassRepository
    {
        public ICollection<DndSubclass> GetSubclasses();
        public DndSubclass GetSubclass(int subclassId);
        public ICollection<DndSubclass> GetSubclassesByOwner(int ownerId);
        public bool Save();
        public bool DeleteSubclass(DndSubclass subclass);
        public bool UpdateSubclass(DndSubclass subclass);
        public bool CreateSubclass(int ownerid, int classid, DndSubclass subclass);
        int GetUserIdByName(string username);
        public int GetOwnerId(int subclassId);
        public DndClass GetClassFromSubclass(int subclassId);
        public int Upvotes(int subclassId);
        public bool Upvote(int userid, int subclassId);
        public bool CheckUpvote(int userid, int subclassId);
        public ICollection<DndSubclass> UpvotedList(int userid);

    }
}
