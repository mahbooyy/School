using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.ModelsDb;
using School.Domain.Enum;


namespace School.Domain.ModelsDb
{
    [Table("user")]
        public class UserDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("login")]

        public string Login { get; set; }

        [Column("password")]

        public string Password { get; set; }

        [Column("email")]

        public string Email { get; set; }

        [Column("role")]

        public Role Role { get; set; }

        [Column("pathImage")]

        public string PathImage { get; set; }

        [Column("createdAt", TypeName = "timestamp")]

        public DateTime CreatedAt { get; set; }

        public ICollection<RequestDb> requestDbs { get; set; }

        public ICollection<OrdersDb> ordersDb { get; set; }
    }
}
