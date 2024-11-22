using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Products
    {

        public Guid Id { get; set; }

        public Guid Id_Category { get; set; }

        public string Name { get; set; }

        public decimal Product { get; set; }

        public int PathImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }
    }
}
