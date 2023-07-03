namespace TabloidMVC.Models.ViewModels
{
    public class PostCommentViewModel
    {
      public int PostId { get; set; }
      public List <Comment> Comments { get; set; }
      public string PostTitle { get; set; }
    }
}