using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.ModelsDb
{
    [Table("orders")]
    public class OrdersDb
    {
       [Column("id")]
        public Guid Id { get; set; }

        [Column("id_user")]

        public Guid Id_User { get; set; }

        [Column("id_product")]

        public Guid Id_Product { get; set; }

        [Column("name")]

        public string Name { get; set; }

        [Column("price")]

        public decimal Price { get; set; }

        [Column("createdAt", TypeName = "timestamp")]

        public DateTime CreatedAt { get; set; }

        public ICollection<ProductsDb> ProductsDb { get; set; }

        public ICollection<RequestDb> RequestsDb { get; set; }

        public UserDb UserDb { get; set; }

    }
}
