﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstLikeApp.Model
{
    public class Mark
    {
        public Guid MarkId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
