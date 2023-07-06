                        
                        INSERT INTO Comment (
                        [Subject], Content, CreateDateTime, PostId, UserProfileId)
                        OUTPUT INSERTED.ID
                        VALUES ('TEST', 'TEST', GETDATE(), 1, 1)
                        
                        SELECT co.Id as CommentId, co.PostId as CommentPostId, 
                        co.UserProfileId, co.Subject as CommentSubject, 
                        co.Content as CommentContent, co.CreateDateTime as CommentDate,
                        u.Id
                        FROM Comment co
                        LEFT JOIN Post p ON p.Id = co.PostId
                        LEFT JOIN UserProfile u ON  co.UserProfileId = u.Id
                        WHERE co.Id = @id