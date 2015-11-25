using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UserDTO> Users { get; set; }
    }
}
