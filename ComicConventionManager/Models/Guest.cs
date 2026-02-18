using System.ComponentModel.DataAnnotations;

namespace ComicConventionManager.Models
{
    public class Guest
    {
        public int GuestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Role { get; set; }

        public string? Bio { get; set; }
    }
}