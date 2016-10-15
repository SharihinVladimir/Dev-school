using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstLikeApp.Model
{
    public class C_Comment
    {
        public Guid Comment_ID { get; set; }
        public Guid User_ID { get; set; }
        public Guid Post_ID { get; set; }
        public DateTime Date { get; set; }
        public string Comment_text { get; set; }
    }
}
