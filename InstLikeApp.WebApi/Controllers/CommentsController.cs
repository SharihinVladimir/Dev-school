using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstLikeApp.Model;

namespace InstLikeApp.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private const string ConnectionString = "Data Source=vladimir-pc; Initial Catalog=InstLikeApp2; Integrated Security=True";
        private readonly I_DataLayer _dataLayer;

        public CommentsController()
        {
            _dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
        }

        [HttpPost]
        public Comment AddComment(Comment comment)
        {
            return _dataLayer.AddComment(comment);
        }

        [HttpGet]
        [Route("api/comments/{id}")]
        public Comment GetComment(Guid id)
        {
            return _dataLayer.GetComment(id);
        }

        [HttpDelete]
        [Route("api/comments/{id}")]
        public int DeleteComment(Guid id)
        {
            return _dataLayer.DeleteComment(id);
        }
    }
}
