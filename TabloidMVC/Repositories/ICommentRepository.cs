using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
       public List<Comment> GetCommentsByPost(int postId);
    }
}
