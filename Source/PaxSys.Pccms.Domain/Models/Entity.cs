using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public abstract class Entity : Equatable
    {
        public int Id { get; set; }

        protected sealed override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}