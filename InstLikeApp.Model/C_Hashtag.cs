using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstLikeApp.Model
{
    public class C_Hashtag
    {
        public Guid Hashtag_ID { get; set; }
        public Guid Post_ID { get; set; }
        public string Hashtag_text { get; set; }
    }
}
