using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstLikeApp.Model;

namespace InstLikeApp.Tests
{
    [TestClass]
    public class DataLayerSqlTest
    {
        private const string _connectionString = "Data Source=vladimir-pc; Initial Catalog=InstLikeApp2; Integrated Security=True";

        [TestMethod]
        public void ShouldAddGetDeleteUser()
        {
            //arrange
            var user = new User
            {
                UserName = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addUser = dataLayer.AddUser(user);
            var getUser = dataLayer.GetUser(addUser.UserId);
            var isDeleted = dataLayer.DeleteUser(getUser.UserId);
            //asserts
            Assert.AreEqual(addUser.UserId, getUser.UserId);
            Assert.AreEqual(addUser.UserName, getUser.UserName);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeletePost()
        {
            //arrange
            var post = new Post
            {
                UserId = Guid.NewGuid(),
                Picture = Guid.NewGuid().ToByteArray(),
                Date = DateTime.Now
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addPost = dataLayer.AddPost(post);
            var getPost = dataLayer.GetPost(addPost.PostId);
            var isDeleted = dataLayer.DeletePost(getPost.PostId);
            //asserts
            Assert.AreEqual(addPost.PostId, getPost.PostId);
            Assert.AreEqual(addPost.UserId, getPost.UserId);
            //Assert.AreEqual(addPost.Picture, getPost.Picture);
            //Assert.AreEqual(addPost.Date, getPost.Date);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeleteComment()
        {
            //arrange
            var comment = new Comment
            {
                UserId = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
                Date = DateTime.Now,
                CommentText = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addComment = dataLayer.AddComment(comment);
            var getComment = dataLayer.GetComment(addComment.CommentId);
            int isDeleted = dataLayer.DeleteComment(getComment.CommentId);
            //asserts
            Assert.AreEqual(addComment.CommentId, getComment.CommentId);
            Assert.AreEqual(addComment.UserId, getComment.UserId);
            Assert.AreEqual(addComment.PostId, getComment.PostId);
            //Assert.AreEqual(addComment.Date, getComment.Date);
            Assert.AreEqual(addComment.CommentText, getComment.CommentText);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeleteLike()
        {
            //arrange
            var like = new Like
            {
                UserId = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addLike = dataLayer.AddLike(like);
            var getLike = dataLayer.GetLike(addLike.LikeId);
            int isDeleted = dataLayer.DeleteLike(getLike.LikeId);
            //asserts
            Assert.AreEqual(addLike.LikeId, getLike.LikeId);
            Assert.AreEqual(addLike.UserId, getLike.UserId);
            Assert.AreEqual(addLike.PostId, getLike.PostId);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeleteMark()
        {
            //arrange
            var mark = new Mark
            {
                UserId = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addMark = dataLayer.AddMark(mark);
            var getMark = dataLayer.GetMark(addMark.MarkId);
            int isDeleted = dataLayer.DeleteMark(getMark.MarkId);
            //asserts
            Assert.AreEqual(addMark.MarkId, getMark.MarkId);
            Assert.AreEqual(addMark.UserId, getMark.UserId);
            Assert.AreEqual(addMark.PostId, getMark.PostId);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeleteHashtag()
        {
            //arrange
            var hashtag = new Hashtag
            {
                PostId = Guid.NewGuid(),
                HashtagText = Guid.NewGuid().ToString()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addHashtag = dataLayer.AddHashtag(hashtag);
            var getHashtag = dataLayer.GetHashtag(addHashtag.HashtagId);
            int isDeleted = dataLayer.DeleteHashtag(getHashtag.HashtagId);
            //asserts
            Assert.AreEqual(addHashtag.HashtagId, getHashtag.HashtagId);
            Assert.AreEqual(addHashtag.PostId, getHashtag.PostId);
            Assert.AreEqual(addHashtag.HashtagText, getHashtag.HashtagText);
            Assert.IsNotNull(isDeleted);
        }

        [TestMethod]
        public void ShouldAddGetDeleteReference()
        {
            //arrange
            var reference = new Reference
            {
                CommentId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(_connectionString);
            var addReference = dataLayer.AddReference(reference);
            var getReference = dataLayer.GetReference(addReference.ReferenceId);
            int isDeleted = dataLayer.DeleteReference(getReference.ReferenceId);
            //asserts
            Assert.AreEqual(addReference.ReferenceId, getReference.ReferenceId);
            Assert.AreEqual(addReference.CommentId, getReference.CommentId);
            Assert.AreEqual(addReference.UserId, getReference.UserId);
            Assert.IsNotNull(isDeleted);
        }
    }
}
