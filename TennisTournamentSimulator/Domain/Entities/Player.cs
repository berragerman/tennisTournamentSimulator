using Domain.Common;

namespace Domain.Entities
{
    public class Player : AuditableEntity
    {
        public int Abillity { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Reaction { get; set; }
        public int Lucky { get; set; }
    }
}
