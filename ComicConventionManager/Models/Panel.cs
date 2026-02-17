using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ComicConventionManager.Models
{
    public class Panel : Controller
    {
        public int PanelId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public string Location { get; set; }
    }
}
