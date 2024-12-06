using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class ProductsFilter
    {
        public Guid Id_Category { get; set; }

        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }

        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
    }
}
