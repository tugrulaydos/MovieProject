using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Scenario
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
