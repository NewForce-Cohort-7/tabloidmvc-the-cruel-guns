using Microsoft.Data.SqlClient;
using TabloidMVC.Models;
using TabloidMVC.Utils;
namespace TabloidMVC.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration config) : base(config) { }

        public void Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByPost(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT co.Id as CommentId, co.PostId as CommentPostId, 
                co.UserProfileId, co.Subject as CommentSubject, 
                co.Content as CommentContent, co.CreateDateTime as CommentDate,
                u.Id as UserProfileId, u.CreateDateTime, u.ImageLocation as AvatarImage,
                u.UserTypeId
                FROM Comment co
                LEFT JOIN UserProfile u ON co.UserProfileId = u.Id
                WHERE co.PostId = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    var comments = new List<Comment>();

                    while (reader.Read())
                    {
                        var comment = new Comment
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CommentId")),
                            PostId = reader.GetInt32(reader.GetOrdinal("CommentPostId")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            Subject = reader.GetString(reader.GetOrdinal("CommentSubject")),
                            Content = reader.GetString(reader.GetOrdinal("CommentContent")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CommentDate")),
                            UserProfile = new UserProfile
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                // Populate other properties of UserProfile as needed
                            }
                        };

                        comments.Add(comment);
                    }

                    reader.Close();
                    return comments;
                }
            }
        }
    }
