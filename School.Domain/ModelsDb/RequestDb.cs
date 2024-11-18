using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.ModelsDb
{
    [Table("request")]
    public class RequestDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_user")]

        public Guid Id_User { get; set; }

        [Column("pathImage")]

        public string PathImage { get; set; }

        [Column("description")]

        public string Description { get; set; }

        [Column("status")]

        public string Status { get; set; }

        [Column("createdAt", TypeName = "timestamp")]

        public DateTime CreatedAt { get; set; }

       public UserDb UserDb { get; set; }
    }
}
