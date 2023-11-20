﻿using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IItemRepository
    {
        public ICollection<Item> GetItems();
        public Item GetItem(int id);
        public bool Save();
        public bool CreateItem(int ownerid, Item item);
        public bool DeleteItem(Item item);
        public bool UpdateItem(Item item);
        public ICollection<Item> GetItemsByOwner(int ownerid);
    }
}