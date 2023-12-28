using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Item
    {
        [Key]
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemRarity { get; set; }
        public string itemDescription { get; set; }
        public string itemWeight {  get; set; }
        public User? owner { get; set; }
        public string ownerName { get; set; }
    }
}
