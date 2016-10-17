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
            //arrange
            var User = new C_User
            {
                User_Name = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addUser = dataLayer.AddUser(User);
            var getUser = dataLayer.GetUser(addUser.User_ID);
            var isDeleted = dataLayer.DeleteUser(getUser.User_ID);
            //asserts
            Assert.AreEqual(addUser.User_ID, getUser.User_ID);
            Assert.AreEqual(addUser.User_Name, getUser.User_Name);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Post()
        {
            //arrange
            var Post = new C_Post
            {
                User_ID = Guid.NewGuid(),
                Picture = Guid.NewGuid().ToByteArray(),
                Date = DateTime.Now
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addPost = dataLayer.AddPost(Post);
            var getPost = dataLayer.GetPost(addPost.Post_ID);
            var isDeleted = dataLayer.DeletePost(getPost.Post_ID);
            //asserts
            Assert.AreEqual(addPost.Post_ID, getPost.Post_ID);
            Assert.AreEqual(addPost.User_ID, getPost.User_ID);
            //Assert.AreEqual(addPost.Picture, getPost.Picture);
            //Assert.AreEqual(addPost.Date, getPost.Date);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Comment()
        {
            //arrange
            var Comment = new C_Comment
            {
                User_ID = Guid.NewGuid(),
                Post_ID = Guid.NewGuid(),
                Date = DateTime.Now,
                Comment_text = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addComment = dataLayer.AddComment(Comment);
            var getComment = dataLayer.GetComment(addComment.Comment_ID);
            int isDeleted = dataLayer.DeleteComment(getComment.Comment_ID);
            //asserts
            Assert.AreEqual(addComment.Comment_ID, getComment.Comment_ID);
            Assert.AreEqual(addComment.User_ID, getComment.User_ID);
            Assert.AreEqual(addComment.Post_ID, getComment.Post_ID);
            //Assert.AreEqual(addComment.Date, getComment.Date);
            Assert.AreEqual(addComment.Comment_text, getComment.Comment_text);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Like()
        {
            //arrange
            var Like = new C_Like
            {
                User_ID = Guid.NewGuid(),
                Post_ID = Guid.NewGuid(),
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addLike = dataLayer.AddLike(Like);
            var getLike = dataLayer.GetLike(addLike.Like_ID);
            int isDeleted = dataLayer.DeleteLike(getLike.Like_ID);
            //asserts
            Assert.AreEqual(addLike.Like_ID, getLike.Like_ID);
            Assert.AreEqual(addLike.User_ID, getLike.User_ID);
            Assert.AreEqual(addLike.Post_ID, getLike.Post_ID);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Mark()
        {
            //arrange
            var Mark = new C_Mark
            {
                User_ID = Guid.NewGuid(),
                Post_ID = Guid.NewGuid(),
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addMark = dataLayer.AddMark(Mark);
            var getMark = dataLayer.GetMark(addMark.Mark_ID);
            int isDeleted = dataLayer.DeleteMark(getMark.Mark_ID);
            //asserts
            Assert.AreEqual(addMark.Mark_ID, getMark.Mark_ID);
            Assert.AreEqual(addMark.User_ID, getMark.User_ID);
            Assert.AreEqual(addMark.Post_ID, getMark.Post_ID);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Hashtag()
        {
            //arrange
            var Hashtag = new C_Hashtag
            {
                Post_ID = Guid.NewGuid(),
                Hashtag_text = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addHashtag = dataLayer.AddHashtag(Hashtag);
            var getHashtag = dataLayer.GetHashtag(addHashtag.Hashtag_ID);
            int isDeleted = dataLayer.DeleteHashtag(getHashtag.Hashtag_ID);
            //asserts
            Assert.AreEqual(addHashtag.Hashtag_ID, getHashtag.Hashtag_ID);
            Assert.AreEqual(addHashtag.Post_ID, getHashtag.Post_ID);
            Assert.AreEqual(addHashtag.Hashtag_text, getHashtag.Hashtag_text);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void Should_Add_Get_Delete_Reference()
        {
            //arrange
            var Reference = new C_Reference
            {
                Comment_ID = Guid.NewGuid(),
                User_ID = Guid.NewGuid()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var addReference = dataLayer.AddReference(Reference);
            var getReference = dataLayer.GetReference(addReference.Reference_ID);
            int isDeleted = dataLayer.DeleteReference(getReference.Reference_ID);
            //asserts
            Assert.AreEqual(addReference.Reference_ID, getReference.Reference_ID);
            Assert.AreEqual(addReference.Comment_ID, getReference.Comment_ID);
            Assert.AreEqual(addReference.User_ID, getReference.User_ID);
            Assert.IsNotNull(isDeleted);
        }
    }
}
