using System.ComponentModel.DataAnnotations;

namespace ComicConventionManager.Models
{
    public class Panel
    {
        public int PanelId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        [Required]
        public string LocationName { get; set; }

        public string? GoogleMapsLink { get; set; }
    }
}
