using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Category
    {

        public Guid Id { get; set; }
            
        public string Description { get; set; }

        public int PathImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid Id_Product { get; set; }
        public string Name { get; set; }

    }
}
