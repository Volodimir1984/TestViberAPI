using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string IdViber { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Language { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Country { get; set; }
        [Column("Device Type", TypeName = "varchar(30)")]
        public string DeviceType { get; set; }
    }
}
