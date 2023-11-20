using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Dto
{
    public class ItemDto
    {
        public int? itemId { get; set; }
        public string itemName { get; set; }
        public string itemRarity { get; set; }
        public string itemDescription { get; set; }
        public string itemWeight { get; set; }
    }
}
