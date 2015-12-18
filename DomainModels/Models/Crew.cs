using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CrewImgUrl { get; set; }
        public int CrewLeaderId { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<CrewApplication> Applications { get; set; }
    }
}
