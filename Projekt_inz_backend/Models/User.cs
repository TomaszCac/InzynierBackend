using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string email {  get; set; }
        public string username {  get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public string role { get; set; }
        public ICollection<Spell> spells { get; set; }
        public ICollection<DndClass> dndClasses { get; set; }
        public ICollection<Race> races { get; set; }

    }
}
