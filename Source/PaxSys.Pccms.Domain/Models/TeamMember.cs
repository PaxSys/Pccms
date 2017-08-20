using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class TeamMember : Equatable
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TeamId;
            yield return MemberId;
        }
    }
}