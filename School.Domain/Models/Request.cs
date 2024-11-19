using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Models
{
    public class Request
    {
    
        public Guid Id { get; set; }

        
        public Guid Id_User { get; set; }

 
        public string PathImage { get; set; }

  

        public string Description { get; set; }



        public string Status { get; set; }


        public DateTime CreatedAt { get; set; }
    }
}
