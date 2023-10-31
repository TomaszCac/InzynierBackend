using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class CustomDndClassFeature
    {
        [Key]
        public int featureID {  get; set; } 
        public DndClass usedBy { get; set; }
        public string featureDesc { get; set; }


    }
}
