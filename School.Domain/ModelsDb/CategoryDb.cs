using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EllipticCurve.Utils;
using School.Domain.Enum;

namespace School.Domain.ModelsDb
{
    [Table("category")]
    public class CategoryDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        public string Description { get; set; }

        [Column("pathImg")]

        public int PathImage { get; set; }


        [Column("createdAt", TypeName = "timestamp")]

        public DateTime CreatedAt { get; set; }

        [Column("Id_product")]

        public Guid Id_Product { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<ProductsDb> Products { get; set; }
    }
}
