using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstLikeApp.Model;
using System.Data.SqlClient;

namespace InstLikeApp.DataLayer.Sql
{
    public class DataLayer : I_DataLayer
    {
        private readonly string _connectionString;

        public DataLayer(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }

        //Writing into BD--------------------------------------------------------------
        public Comment AddComment(Comment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //Exceptions-----------------------------------------------------
                    command.CommandText = "SELECT * FROM Users WHERE UserId = @userId";
                    command.Parameters.AddWithValue("@userId", comment.UserId);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    var isUser = reader.HasRows;
                    reader.Close();

                    command.CommandText = "SELECT * FROM Posts WHERE PostId = @postId";
                    command.Parameters.AddWithValue("@postId", comment.PostId);
                    reader = command.ExecuteReader();
                    reader.Read();
                    var isPost = reader.HasRows;
                    reader.Close();

                    try
                    {
                        if (!isUser)
                            throw new Exception("Пользователя с указанным Id не существует.");
                        else if (!isPost)
                            throw new Exception("Поста с указанным Id не существует.");
                        else if (comment.CommentText.Length > 500)
                            throw new Exception("Комментарий должен содержать не более 500 символов.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    //------------------------------------------------------------------

                    comment.CommentId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Comments (CommentId, UserId, PostId, Date, CommentText) VALUES (@commentId, @userId, @postId, @date, @commentText)";
                    command.Parameters.AddWithValue("@commentId", comment.CommentId);
                    command.Parameters.AddWithValue("@userId", comment.UserId);
                    command.Parameters.AddWithValue("@postId", comment.PostId);
                    command.Parameters.AddWithValue("@date", comment.Date);
                    command.Parameters.AddWithValue("@commentText", comment.CommentText);
                    command.ExecuteNonQuery();
                    return comment;
                }
            }
        }

        public Hashtag AddHashtag(Hashtag hashtag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //Exceptions-----------------------------------------------------
                    /*command.CommandText = "SELECT * FROM Posts WHERE PostId = @postId";
                    command.Parameters.AddWithValue("@postId", hashtag.PostId);
                    var readerPostId = command.ExecuteReader();
                    readerPostId.Read();

                    try
                    {
                        if (!readerPostId.HasRows)
                            throw new Exception("Поста с указанным Id не существует.");
                        else if (hashtag.HashtagText.Length > 30)
                            throw new Exception("Хэштег должен содержать не более 30 символов.");
                        else if (hashtag.HashtagText[0] != '#')
                            throw new Exception("Хэштег должен начинаться с символа '#'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }*/
                    //------------------------------------------------------------------

                    hashtag.HashtagId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Hashtags (HashtagId, PostId, HashtagText) VALUES (@hashtagId, @postId, @hashtagText)";
                    command.Parameters.AddWithValue("@hashtagId", hashtag.HashtagId);
                    command.Parameters.AddWithValue("@postId", hashtag.PostId);
                    command.Parameters.AddWithValue("@hashtagText", hashtag.HashtagText);
                    command.ExecuteNonQuery();
                    return hashtag;
                }
            }
        }

        public Like AddLike(Like like)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //Exceptions-----------------------------------------------------
                   /* command.CommandText = "SELECT * FROM Users WHERE UserId = @userId";
                    command.Parameters.AddWithValue("@userId", like.UserId);
                    var readerUserId = command.ExecuteReader();
                    readerUserId.Read();

                    command.CommandText = "SELECT * FROM Posts WHERE PostId = @postId";
                    command.Parameters.AddWithValue("@postId", like.PostId);
                    var readerPostId = command.ExecuteReader();
                    readerPostId.Read();

                    command.CommandText = "SELECT * FROM Posts WHERE (PostId = @postId) AND (UserId = @userId) ";
                    command.Parameters.AddWithValue("@postId", like.PostId);
                    command.Parameters.AddWithValue("@userId", like.UserId);
                    var readerUserPostId = command.ExecuteReader();
                    readerPostId.Read();

                    try
                    {
                        if (!readerUserId.HasRows)
                            throw new Exception("Пользователя с указанным Id не существует.");
                        else if (!readerPostId.HasRows)
                            throw new Exception("Поста с указанным Id не существует.");
                        else if (readerUserPostId.HasRows)
                            throw new Exception("Лайк от указанного пользователя для указанного поста уже существует.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }*/
                    //------------------------------------------------------------------

                    like.LikeId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Likes (LikeId,UserId,PostId) VALUES (@likeId, @userId, @postId)";
                    command.Parameters.AddWithValue("@likeId", like.LikeId);
                    command.Parameters.AddWithValue("@userId", like.UserId);
                    command.Parameters.AddWithValue("@postId", like.PostId);
                    command.ExecuteNonQuery();
                    return like;
                }
            }
        }

        public Mark AddMark(Mark mark)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    mark.MarkId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Marks (MarkId, PostId, UserId) VALUES (@markId, @postId, @userId)";
                    command.Parameters.AddWithValue("@markId", mark.MarkId);
                    command.Parameters.AddWithValue("@postId", mark.PostId);
                    command.Parameters.AddWithValue("@userId", mark.UserId);
                    command.ExecuteNonQuery();
                    return mark;
                }
            }
        }

        public Post AddPost(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    post.PostId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Posts (PostId, UserId, Picture, Date) VALUES (@postId, @userId, @picture, @date)";
                    command.Parameters.AddWithValue("@postId", post.PostId);
                    command.Parameters.AddWithValue("@userId", post.UserId);
                    command.Parameters.AddWithValue("@picture", post.Picture);
                    command.Parameters.AddWithValue("@date", post.Date);
                    command.ExecuteNonQuery();
                    return post;
                }
            }
        }

        public Reference AddReference(Reference reference)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    reference.ReferenceId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO References_t (ReferenceId, CommentId, UserId) VALUES (@referenceId, @commentId, @userId)";
                    command.Parameters.AddWithValue("@referenceId", reference.ReferenceId);
                    command.Parameters.AddWithValue("@commentId", reference.CommentId);
                    command.Parameters.AddWithValue("@userId", reference.UserId);
                    command.ExecuteNonQuery();
                    return reference;
                }
            }
        }

        public User AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    user.UserId = Guid.NewGuid();
                    command.CommandText = "INSERT INTO Users (UserId, UserName) VALUES (@userId, @userName)";
                    command.Parameters.AddWithValue("@userId", user.UserId);
                    command.Parameters.AddWithValue("@userName", user.UserName);
                    command.ExecuteNonQuery();
                    return user;
                }
            }
        }

        //Removal from BD--------------------------------------------------------------
        public int DeleteComment(Guid commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Comments WHERE CommentId = @commentId";
                    command.Parameters.AddWithValue("@commentId", commentId);
                    return command.ExecuteNonQuery();//number of deleted items
                }
            }
        }

        public int DeleteHashtag(Guid hashtagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Hashtags WHERE HashtagId = @hashtagId";
                    command.Parameters.AddWithValue("@hashtagId", hashtagId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteLike(Guid likeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Likes WHERE LikeId = @likeId";
                    command.Parameters.AddWithValue("@likeId", likeId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteMark(Guid markId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Marks WHERE MarkId = @markId";
                    command.Parameters.AddWithValue("@markId", markId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeletePost(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Posts WHERE PostId = @postId";
                    command.Parameters.AddWithValue("@postId", postId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteReference(Guid referenceId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE References_t WHERE ReferenceId = @referenceId";
                    command.Parameters.AddWithValue("@referenceId", referenceId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteUser(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Users WHERE UserId = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    return command.ExecuteNonQuery();
                }
            }
        }

        //Reading from BD--------------------------------------------------------------
        public Comment GetComment(Guid commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT CommentId, UserId, PostId, Date, CommentText FROM Comments WHERE CommentId = @commentId";
                    command.Parameters.AddWithValue("@commentId", commentId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Comment
                        {
                            CommentId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1),
                            PostId = reader.GetGuid(2),
                            Date = reader.GetDateTime(3),
                            CommentText = reader.GetString(4)
                        };
                    }
                }
            }
        }

        public Hashtag GetHashtag(Guid hashtagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT HashtagId, PostId, HashtagText FROM Hashtags WHERE HashtagId = @hashtagId";
                    command.Parameters.AddWithValue("@hashtagId", hashtagId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Hashtag
                        {
                            HashtagId = reader.GetGuid(0),
                            PostId = reader.GetGuid(1),
                            HashtagText = reader.GetString(2)
                        };
                    }
                }
            }
        }

        public Like GetLike(Guid likeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT LikeId, UserId, PostId FROM Likes WHERE LikeId = @likeId";
                    command.Parameters.AddWithValue("@likeId", likeId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Like
                        {
                            LikeId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1),
                            PostId = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public Mark GetMark(Guid markId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT MarkId, PostId, UserId FROM Marks WHERE MarkId = @markId";
                    command.Parameters.AddWithValue("@markId", markId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Mark
                        {
                            MarkId = reader.GetGuid(0),
                            PostId = reader.GetGuid(1),
                            UserId = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public Post GetPost(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT PostId, UserId, Picture, Date FROM Posts WHERE PostId = @postId";
                    command.Parameters.AddWithValue("@postId", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Post
                        {
                            PostId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1),
                            Picture = (byte[]) reader["Picture"],
                            Date = reader.GetDateTime(3)
                        };
                    }
                }
            }
        }

        public Reference GetReference(Guid referenceId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ReferenceId, CommentId, UserId FROM References_t WHERE ReferenceId = @referenceId";
                    command.Parameters.AddWithValue("@referenceId", referenceId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Reference
                        {
                            ReferenceId = reader.GetGuid(0),
                            CommentId = reader.GetGuid(1),
                            UserId = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public User GetUser(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT UserId, UserName FROM Users WHERE UserId = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new User
                        {
                            UserId = (Guid)reader["UserId"]/*.GetGuid(0)*/,
                            UserName = (String)reader["UserName"]/*.GetString(1)*/,
                        };
                    }
                }
            }
        }

        //--------------------------------------------------------------
    }
}
