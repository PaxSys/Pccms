using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class Activity : Equatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.ActivityType Type { get; set; }
        public Enums.ScoreType ScoreType { get; set; }

        public int FirstPlaceValue { get; set; }
        public int SecondPlaceValue { get; set; }
        public int ThirdPlaceValue { get; set; }

        public virtual Contest OfContest { get; set; }
        public virtual ICollection<MemberActivityAttendance> AttendingMembers { get; set; }
        public virtual ICollection<TeamActivityAttendance> AttendingTeams { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}