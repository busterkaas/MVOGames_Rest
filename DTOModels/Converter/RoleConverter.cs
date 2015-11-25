using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class RoleConverter : AbstractDTOConverter<Role, RoleDTO>
    {
        public override RoleDTO Convert(Role item)
        {
            var roleDTO = new RoleDTO()
            {
                Id = item.Id,
                RoleName = item.RoleName
            };
            return roleDTO;
        }

        public override Role Reverse(RoleDTO item)
        {
            var role = new Role()
            {
                Id = item.Id,
                RoleName = item.RoleName
            };
            return role;
        }
    }
}
