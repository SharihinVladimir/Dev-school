using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstLikeApp.Model;

namespace InstLikeApp.WebApi.Controllers
{
    public class PostsController : ApiController
    {
        private const string ConnectionString = "Data Source=vladimir-pc; Initial Catalog=InstLikeApp2; Integrated Security=True";
        private readonly I_DataLayer _dataLayer;

        public PostsController()
        {
            _dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
        }

        [HttpPost]
        public Post AddPost(Post post)
        {
            return _dataLayer.AddPost(post);
        }

        [HttpGet]
        [Route("api/posts/{id}")]
        public Post GetPost(Guid id)
        {
            return _dataLayer.GetPost(id);
        }

        [HttpDelete]
        [Route("api/posts/{id}")]
        public int DeletePost(Guid id)
        {
            return _dataLayer.DeletePost(id);
        }
    }
}
