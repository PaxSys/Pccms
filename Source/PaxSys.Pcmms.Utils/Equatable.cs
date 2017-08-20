using System.Collections.Generic;
using System.Linq;

namespace PaxSys.Pcmms.Utils
{
    public abstract class Equatable
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public sealed override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            if (GetType() != obj.GetType())
                return false;

            var domainObject = (Equatable) obj;

            return GetEqualityComponents().SequenceEqual(domainObject.GetEqualityComponents());
        }

        public sealed override int GetHashCode()
        {
            unchecked
            {
                return GetEqualityComponents().Aggregate(17,
                    (current, item) => current * 23 + (item != null ? item.GetHashCode() : 0));
            }
        }

        public static bool operator ==(Equatable first, Equatable second)
        {
            if (ReferenceEquals(first, second))
                return true;

            if (ReferenceEquals(first, null))
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(Equatable first, Equatable second)
        {
            return !(first == second);
        }
    }
}
