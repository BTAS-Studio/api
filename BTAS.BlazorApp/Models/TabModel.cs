using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models
{
    public class TabModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TabUrl { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsTitle { get; set; } = false;
        public string Module { get; set; } = "";
    }
}
