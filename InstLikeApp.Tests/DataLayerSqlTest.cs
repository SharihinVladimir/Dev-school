using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstLikeApp.Model;

namespace InstLikeApp.Tests
{
    [TestClass]
    public class DataLayerSqlTest
    {
        private const string ConnectionString = "Data Source=vladimir-pc; Initial Catalog=InstLikeApp2; Integrated Security=True";

        [TestMethod]
        public void Should_Add_Get_Delete_User()
        {
            var User = new C_User
            {
                User_Name = Guid.NewGuid().ToString()
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);

            var addUser = dataLayer.AddUser(User);
            var getUser = dataLayer.GetUser(addUser.User_ID);
            int isDeleted = dataLayer.DeleteUser(getUser.User_ID);

            Assert.AreEqual(addUser.User_ID, getUser.User_ID);
            Assert.AreEqual(addUser.User_Name, getUser.User_Name);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Post()
        {
            var Post = new C_Post
            {
                User_ID = Guid.NewGuid(),
                Picture = Guid.NewGuid().ToByteArray(),
                /*{ },*//*Guid.NewGuid().ToByteArray(),*/
                Date = DateTime.Now
            };

            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);

            var addPost = dataLayer.AddPost(Post);

            Assert.AreEqual(Post.Post_ID, addPost.Post_ID);
        }

        /*[TestMethod]
        public void Should_Add_Get_Delete_Comment()
        {
            var addComment = new C_Comment
            {
                User_ID = Guid.NewGuid(),
                Post_ID = Guid.NewGuid(),
                Date = DateTime.Now,
                Comment_text = Guid.NewGuid().ToString()
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);

            addComment = dataLayer.AddComment(addComment);
            var getComment = dataLayer.GetComment(addComment.Comment_ID);
            int isDeleted = dataLayer.DeleteComment(getComment.Comment_ID);

            Assert.AreEqual(addComment.Comment_ID, getComment.User_ID);
            Assert.AreEqual(addComment.User_ID, getComment.User_ID);
            Assert.AreEqual(addComment.Post_ID, getComment.Post_ID);
            Assert.AreEqual(addComment.Date, getComment.Date);
            Assert.AreEqual(addComment.Comment_text, getComment.Comment_text);
            Assert.IsNotNull(isDeleted);
        }
        */
    }
}
