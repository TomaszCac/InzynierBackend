using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Item
    {
        [Key]
        public int itemID { get; set; }
        public string name { get; set; }
        public string rarity { get; set; }
        public string description { get; set; }
        public string weight {  get; set; }
        public User? owner { get; set; }
    }
}
