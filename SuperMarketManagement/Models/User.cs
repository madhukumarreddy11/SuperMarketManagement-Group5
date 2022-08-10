using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }   
        public int RoleId { get; set; }


    }
}
