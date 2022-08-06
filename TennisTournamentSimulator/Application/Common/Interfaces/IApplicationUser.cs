using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationUser
    {
        string UserName { get; set; }
        string DisplayName { get; set; }
        string Photo { get; set; }
    }
}
