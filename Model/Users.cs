using System.ComponentModel.DataAnnotations;

namespace Net_API.Model
{
    public class Users
    {
        [Key]
       public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        
    }
}
