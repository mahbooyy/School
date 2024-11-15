using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using School.Domain.Enum;

namespace School.Domain.ModelsDb
{
    [Table("picture_product")]
    public class PictureProductDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_product")]

        public Guid Id_Product { get; set; }

        [Column("pathImage")]

        public string PathImage { get; set; }

        public ICollection<ProductsDb> Products { get; set; }

    }
}
