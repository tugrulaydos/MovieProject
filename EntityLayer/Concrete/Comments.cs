﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }        
        public string CommentContent { get; set; }        
        public int UserID { get; set; }
        public int FilmID { get; set; }
        public int? ParentID { get; set; }

        public Film FilmFK { get; set; }

        public User UserFK { get; set; }

        

    }
}
