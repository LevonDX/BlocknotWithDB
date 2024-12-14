using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not EntityBase entity)
                return false;

            return Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !left.Equals(right);
        }
    }
}
