using System.ComponentModel.DataAnnotations;

namespace ComicConventionManager.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}