using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DndDatabaseContext _context;

        public ItemRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public bool CreateItem(int ownerid, Item item)
        {
            var ownerEntity = _context.Users.Where(b => b.userID == ownerid).FirstOrDefault();
            item.owner = ownerEntity;
            _context.Add(item);
            return Save();
        }

        public bool DeleteItem(Item item)
        {
            _context.Remove(item);
            return Save();
        }

        public Item GetItem(int id)
        {
            return _context.Items.Where(b => b.itemId == id).FirstOrDefault();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public ICollection<Item> GetItemsByOwner(int ownerid)
        {
            return _context.Items.Where(b => b.owner.userID == ownerid).ToList();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }
        public int GetOwnerId(int itemId)
        {
            return _context.Items.Where(b => b.itemId == itemId).Select(b => b.owner.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateItem(Item item)
        {
            _context.Update(item);
            return Save();
        }
    }
}
