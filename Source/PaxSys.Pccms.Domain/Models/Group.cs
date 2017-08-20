using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class Group : Equatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }

        public int GroupScore { get; set; }

        public virtual Contest AttendedContest { get; set; }
        public virtual ICollection<Member> GroupMembers { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
