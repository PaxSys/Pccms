using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class MemberActivityAttendance : Equatable
    {
        public int Id { get; set; }
        public virtual Member AttendedMember { get; set; }
        public virtual Activity Activity { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
