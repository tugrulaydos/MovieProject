﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User:IdentityUser<int>
    {
        public ICollection<Comment> comments { get; set; }

    }
}
