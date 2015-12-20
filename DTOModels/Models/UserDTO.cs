using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class UserDTO
    {
        private const int WorkFactor = 13;
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }
        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", WorkFactor);
        }

    }
}
