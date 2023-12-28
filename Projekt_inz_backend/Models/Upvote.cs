using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Upvote
    {
        [Key]
        public int upvoteId { get; set; }
        public string category { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }


    }
}
