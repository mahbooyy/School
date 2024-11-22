using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Orders
    {

        public Guid Id { get; set; }

        public Guid Id_User { get; set; }

        public Guid Id_Product { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
