using System.ComponentModel.DataAnnotations;

namespace Net_API.Model
{
    public class Donhang
    {
        [Key]
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int Id_product { get; set; }
    }
}
