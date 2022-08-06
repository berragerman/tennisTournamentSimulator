using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Inactive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
