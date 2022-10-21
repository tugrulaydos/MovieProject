using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Film
    {
        [Key]
        public int ID { get; set; }

        [StringLength(75)]
        public string Name { get; set; }
        public string ?Scenerio { get; set; }
        public string ?Producer { get; set; }
        public string ?Director { get; set; }
        public double IMDBRaiting { get; set; }
        public string Story { get; set; }        
        public string? İmageUrl { get; set; }       
        public ICollection<Comment> _Comment { get; set; }
        public ICollection<Category> Categories { get; set; }

        public ICollection<Artist> Artists { get; set; }


      

    }
}
