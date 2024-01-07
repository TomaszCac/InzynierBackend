using Projekt_inz_backend.Data;
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
            DndClass dndClassEntity = _context.dndClasses.Where(b => b.classId == classid).FirstOrDefault();
            subclass.owner = ownerEntity;
            subclass.inheritedClass = dndClassEntity;
            subclass.upvotes = 0;
            _context.Add(subclass);
            return Save();
            
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }

        public bool DeleteSubclass(DndSubclass subclass)
        {
            _context.Remove(subclass);
            return Save();
        }

        public DndSubclass GetSubclass(int subclassId)
        {
            return _context.dndSubclasses.Where(b => b.subclassId == subclassId).FirstOrDefault();
        }

        public ICollection<DndSubclass> GetSubclasses()
        {
            return _context.dndSubclasses.ToList();
        }
        public int GetOwnerId(int subclassId)
        {
            return _context.dndSubclasses.Where(b => b.subclassId == subclassId).Select(b => b.owner.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSubclass(DndSubclass subclass)
        {
            var temp = _context.dndSubclasses.Where(b => b.subclassId == subclass.subclassId).Select(b => b.upvotes).FirstOrDefault();
            subclass.upvotes = temp;
            _context.Update(subclass);
            return Save();
        }

        public ICollection<DndSubclass> GetSubclassesByOwner(int ownerId)
        {
            return _context.dndSubclasses.Where(b => b.owner.userID == ownerId).ToList();
        }

        public DndClass GetClassFromSubclass(int subclassId)
        {
            return _context.dndSubclasses.Where(b => b.subclassId == subclassId).Select(b => b.inheritedClass).FirstOrDefault();
        }

        public bool Upvote(int userid, int subclassId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "subclass" && b.userId == userid && b.categoryId == subclassId).FirstOrDefault();
            var subclass = _context.dndSubclasses.Where(b => b.subclassId == subclassId).FirstOrDefault();
            if (upvote != null)
            {
                subclass.upvotes -= 1;
                _context.upvotes.Remove(upvote);
                return Save();
            }
            upvote = new Upvote();
            upvote.userId = userid;
            upvote.category = "subclass";
            upvote.categoryId = subclassId;
            subclass.upvotes += 1;
            _context.upvotes.Add(upvote);
            return Save();
        }

        public bool CheckUpvote(int userid, int subclassId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "subclass" && b.userId == userid && b.categoryId == subclassId).FirstOrDefault();
            if (upvote != null)
            {
                return true;
            }
            return false;
        }

        public ICollection<DndSubclass> UpvotedList(int userid)
        {
            var categoryids = _context.upvotes.Where(b => b.userId == userid && b.category == "subclass").Select(b => b.categoryId).ToList();
            List<DndSubclass> subclasses = new List<DndSubclass>();
            foreach (var categoryid in categoryids)
            {
                subclasses.Add(_context.dndSubclasses.Where(b => b.subclassId == categoryid).FirstOrDefault());
            }
            return subclasses;
        }
    }
}
