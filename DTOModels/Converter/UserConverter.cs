using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class UserConverter : AbstractDTOConverter<User, UserDTO>
    {
        public override UserDTO Convert(User item)
        {
            var userDTO = new UserDTO()
            {
                Id = item.Id,
                Username = item.Username,
                City = item.City,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                HouseNr = item.HouseNr,
                PasswordHash = item.PasswordHash,
                RoleId = item.RoleId,
                StreetName = item.StreetName,
                ZipCode = item.ZipCode
            };
            return userDTO;
            
        }

        public override User Reverse(UserDTO item)
        {
            var user = new User()
            {
                Id = item.Id,
                Username = item.Username,
                City = item.City,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                HouseNr = item.HouseNr,
                PasswordHash = item.PasswordHash,
                RoleId = item.RoleId,
                StreetName = item.StreetName,
                ZipCode = item.ZipCode
            };
            return user;
        }
    }
}
