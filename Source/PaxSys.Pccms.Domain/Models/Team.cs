using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class Team : Equatable
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public virtual Group RepresentedGroup { get; set; }
        public virtual Activity AttendedActivity { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
