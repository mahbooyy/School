using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Oders
    {

        public Guid Id { get; set; }



        public Guid Id_User { get; set; }



        public string Name { get; set; }


        public decimal Price { get; set; }


        public DateTime CreatedAt { get; set; }

    }
}
