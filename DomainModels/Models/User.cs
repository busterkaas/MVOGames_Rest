using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class User
    {
        public User()
        {
            Crews = new List<Crew>();
            Applications = new List<CrewApplication>();
        }
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
        [Required, DataType(DataType.Password)]
        public string PasswordHash { get; set; }

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
        public List<Crew> Crews { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<CrewApplication> Applications { get; set; }
    }
}
