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

        public ICollection<Item> GetItems()
        {
            return _context.items.ToList();
        }
    }
}
