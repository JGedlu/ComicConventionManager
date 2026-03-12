using System.ComponentModel.DataAnnotations;

namespace ComicConventionManager.Models
{
    public class UserPanel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PanelId { get; set; }

        public Panel Panel { get; set; }
    }
}