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
        public C_Comment AddComment(C_Comment Comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Comment.Comment_ID = Guid.NewGuid();
                    command.CommandText = "insert into Comments (Comment_ID, User_ID, Post_ID, Date, Comment_text) values (@Comment_ID, @User_ID, @Post_ID, @Date, @Comment_text)";
                    command.Parameters.AddWithValue("@Comment_ID", Comment.Comment_ID);
                    command.Parameters.AddWithValue("@User_ID", Comment.User_ID);
                    command.Parameters.AddWithValue("@Post_ID", Comment.Post_ID);
                    command.Parameters.AddWithValue("@Date", Comment.Date);
                    command.Parameters.AddWithValue("@Comment_text", Comment.Comment_text);
                    command.ExecuteNonQuery();
                    return Comment;
                }
            }
        }

        public C_Hashtag AddHashtag(C_Hashtag Hashtag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Hashtag.Hashtag_ID = Guid.NewGuid();
                    command.CommandText = "insert into Hashtags (Hashtag_ID,Post_ID,Hashtag_text) values (@Hashtag_ID, @Post_ID, @Hashtag_text)";
                    command.Parameters.AddWithValue("@Hashtag_ID", Hashtag.Hashtag_ID);
                    command.Parameters.AddWithValue("@Post_ID", Hashtag.Post_ID);
                    command.Parameters.AddWithValue("@Hashtag_text", Hashtag.Hashtag_text);
                    command.ExecuteNonQuery();
                    return Hashtag;
                }
            }
        }

        public C_Like AddLike(C_Like Like)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Like.Like_ID = Guid.NewGuid();
                    command.CommandText = "insert into Likes (Like_ID,User_ID,Post_ID) values (@Like_ID, @User_ID, @Post_ID)";
                    command.Parameters.AddWithValue("@Like_ID", Like.Like_ID);
                    command.Parameters.AddWithValue("@User_ID", Like.User_ID);
                    command.Parameters.AddWithValue("@Post_ID", Like.Post_ID);
                    command.ExecuteNonQuery();
                    return Like;
                }
            }
        }

        public C_Mark AddMark(C_Mark Mark)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Mark.Mark_ID = Guid.NewGuid();
                    command.CommandText = "insert into Marks (Mark_ID,Post_ID,User_ID) values (@Mark_ID, @Post_ID, @User_ID)";
                    command.Parameters.AddWithValue("@Mark_ID", Mark.Mark_ID);
                    command.Parameters.AddWithValue("@Post_ID", Mark.Post_ID);
                    command.Parameters.AddWithValue("@User_ID", Mark.User_ID);
                    command.ExecuteNonQuery();
                    return Mark;
                }
            }
        }

        public C_Post AddPost(C_Post Post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Post.Post_ID = Guid.NewGuid();
                    command.CommandText = "insert into Posts (Post_ID, User_ID, Picture, Date) values (@Post_ID, @User_ID, @Picture, @Date)";
                    command.Parameters.AddWithValue("@Post_ID", Post.Post_ID);
                    command.Parameters.AddWithValue("@User_ID", Post.User_ID);
                    command.Parameters.AddWithValue("@Picture", Post.Picture);
                    command.Parameters.AddWithValue("@Date", Post.Date);
                    command.ExecuteNonQuery();
                    return Post;
                }
            }
        }

        public C_Reference AddReference(C_Reference Reference)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Reference.Reference_ID = Guid.NewGuid();
                    command.CommandText = "insert into References (Reference_ID, Comment_ID, User_ID) values (@Reference_ID, @Comment_ID, @User_ID)";
                    command.Parameters.AddWithValue("@Reference_ID", Reference.Reference_ID);
                    command.Parameters.AddWithValue("@Comment_ID", Reference.Comment_ID);
                    command.Parameters.AddWithValue("@User_ID", Reference.User_ID);
                    command.ExecuteNonQuery();
                    return Reference;
                }
            }
        }

        public C_User AddUser(C_User User)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    User.User_ID = Guid.NewGuid();
                    command.CommandText = "insert into Users (User_ID, User_Name) values (@User_ID, @User_Name)";
                    command.Parameters.AddWithValue("@User_ID", User.User_ID);
                    command.Parameters.AddWithValue("@User_Name", User.User_Name);
                    command.ExecuteNonQuery();
                    return User;
                }
            }
        }

        //Removal from BD--------------------------------------------------------------
        public int DeleteComment(Guid Comment_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Comments WHERE Comment_ID = @Comment_ID";
                    command.Parameters.AddWithValue("@Comment_ID", Comment_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;//количество удаленных объектов
                }
            }
        }

        public int DeleteHashtag(Guid Hashtag_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Hashtags WHERE Hashtag_ID = @Hashtag_ID";
                    command.Parameters.AddWithValue("@Hashtag_ID", Hashtag_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        public int DeleteLike(Guid Like_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Likes WHERE Like_ID = @Like_ID";
                    command.Parameters.AddWithValue("@Like_ID", Like_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        public int DeleteMark(Guid Mark_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Marks WHERE Mark_ID = @Mark_ID";
                    command.Parameters.AddWithValue("@Mark_ID", Mark_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        public int DeletePost(Guid Post_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Posts WHERE Post_ID = @Post_ID";
                    command.Parameters.AddWithValue("@Post_ID", Post_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        public int DeleteReference(Guid Reference_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE References WHERE Reference_ID = @Reference_ID";
                    command.Parameters.AddWithValue("@Reference_ID", Reference_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        public int DeleteUser(Guid User_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE Users WHERE User_ID = @User_ID";
                    command.Parameters.AddWithValue("@User_ID", User_ID);
                    int RemovalNumber = command.ExecuteNonQuery();
                    return RemovalNumber;
                }
            }
        }

        //Reading from BD--------------------------------------------------------------
        public C_Comment GetComment(Guid Comment_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Comment_ID, User_ID, Post_ID, Date, Comment_text FROM Comments WHERE Comment_ID = @Comment_ID";
                    command.Parameters.AddWithValue("@Comment_ID", Comment_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_Comment
                        {
                            Comment_ID = reader.GetGuid(0),
                            User_ID = reader.GetGuid(1),
                            Post_ID = reader.GetGuid(2),
                            Date = reader.GetDateTime(3),
                            Comment_text = reader.GetString(4)
                        };
                    }
                }
            }
        }

        public C_Hashtag GetHashtag(Guid Hashtag_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Hashtag_ID, Post_ID, Hashtag_text FROM Hashtags WHERE Hashtag_ID = @Hashtag_ID";
                    command.Parameters.AddWithValue("@Hashtag_ID", Hashtag_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_Hashtag
                        {
                            Hashtag_ID = reader.GetGuid(0),
                            Post_ID = reader.GetGuid(1),
                            Hashtag_text = reader.GetString(2)
                        };
                    }
                }
            }
        }

        public C_Like GetLike(Guid Like_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Like_ID, User_ID, Post_ID FROM Likes WHERE Like_ID = @Like_ID";
                    command.Parameters.AddWithValue("@Like_ID", Like_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_Like
                        {
                            Like_ID = reader.GetGuid(0),
                            User_ID = reader.GetGuid(1),
                            Post_ID = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public C_Mark GetMark(Guid Mark_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Mark_ID, Post_ID, User_ID FROM Marks WHERE Mark_ID = @Mark_ID";
                    command.Parameters.AddWithValue("@Mark_ID", Mark_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_Mark
                        {
                            Mark_ID = reader.GetGuid(0),
                            Post_ID = reader.GetGuid(1),
                            User_ID = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public C_Post GetPost(Guid Post_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Post_ID, User_ID, Picture, Date FROM Posts WHERE Post_ID = @Post_ID";
                    command.Parameters.AddWithValue("@Post_ID", Post_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var Post = new C_Post
                        {
                        };
                        Post.Post_ID = reader.GetGuid(0);
                        Post.User_ID = reader.GetGuid(1);
                        long bytes = reader.GetBytes(2, 0, Post.Picture, 0, Post.Picture.Length);
                        Post.Date = reader.GetDateTime(3);
                        return Post;

                      /*  return new C_Post
                        {
                            Post_ID = reader.GetGuid(0),
                            User_ID = reader.GetGuid(1),
                            Picture = (byte[]) reader["Picture"],
                            Date = reader.GetDateTime(3)
                        };*/
                    }
                }
            }
        }

        public C_Reference GetReference(Guid Reference_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Reference_ID, Comment_ID, User_ID FROM References WHERE Reference_ID = @Reference_ID";
                    command.Parameters.AddWithValue("@Reference_ID", Reference_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_Reference
                        {
                            Reference_ID = reader.GetGuid(0),
                            Comment_ID = reader.GetGuid(1),
                            User_ID = reader.GetGuid(2)
                        };
                    }
                }
            }
        }

        public C_User GetUser(Guid User_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT User_ID, User_Name FROM Users WHERE User_ID = @User_ID";
                    command.Parameters.AddWithValue("@User_ID", User_ID);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new C_User
                        {
                            User_ID = (Guid)reader["User_ID"]/*.GetGuid(0)*/,
                            User_Name = (String)reader["User_Name"]/*.GetString(1)*/,
                        };
                    }
                }
            }
        }

        //--------------------------------------------------------------
    }
}
