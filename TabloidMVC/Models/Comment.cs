using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TabloidMVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [DisplayName("Author:")]
        public int UserProfileId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [DisplayName("Comment")]
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
        public UserProfile Profile { get; set; }
        public UserProfile UserProfile { get; internal set; }
    }
}
