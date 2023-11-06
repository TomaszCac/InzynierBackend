using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Dto
{
    public class ItemDto
    {
        public int? itemID { get; set; }
        public string name { get; set; }
        public string rarity { get; set; }
        public string description { get; set; }
        public string weight { get; set; }
    }
}
