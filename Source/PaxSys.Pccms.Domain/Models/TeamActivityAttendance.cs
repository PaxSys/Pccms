using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class TeamActivityAttendance : Equatable
    {
        public int Id { get; set; }
        public virtual Team AttendedTeam { get; set; }
        public virtual Activity Activity { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
