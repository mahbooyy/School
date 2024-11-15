using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Enum
{
    public enum Status
    {
        [Description("Не рассмотрено")]
        NotConsidered = 0,
        [Description("Одобренно")]
        Approved,
        [Description("Отказано")]
        Denied,
    }
}
