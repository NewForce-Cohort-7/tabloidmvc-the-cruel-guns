namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<CommentRepository> GetCommentsByPost();
    }
}
