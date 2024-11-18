using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ModelsDb
{
    [Table("products")]
    public class ProductsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_category")]
        public Guid Id_Category { get; set; }

        [Column("name")]

        public string Name { get; set; }

        [Column("product")]

        public decimal Product { get; set; }

        [Column("pathImg")]

        public int PathImage { get; set; }


        [Column("createdAt", TypeName = "timestamp")]

        public DateTime CreatedAt { get; set; }

        public OrdersDb OderDb { get; set; }

        public CategoryDb CategoryDb { get; set; }

        public PictureProductDb PictureProduc { get; set; }

    }
}
