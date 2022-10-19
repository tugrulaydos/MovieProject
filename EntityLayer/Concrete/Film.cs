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
        public int CategoryID { get; set; }
        public int? ScenarioID { get; set; }
        public double IMDBRaiting { get; set; }
        public string Story { get; set; }
        public double Raiting { get; set; }
        public Category CategoryFK { get; set; }
        public ICollection<Comment> _Comment { get; set; }

    }
}
