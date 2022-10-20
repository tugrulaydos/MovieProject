﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FilmCategory
    {           
        public int FilmID { get; set; }
        public int CategoryID { get; set; }
        public  Film Film { get; set; }
        public Category Category { get; set; }
    }
}
