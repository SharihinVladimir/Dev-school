using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstLikeApp.Model
{
    public class C_Like
    {
        public Guid Like_ID { get; set; }
        public Guid User_ID { get; set; }
        public Guid Post_ID { get; set; }
    }
}
