using System;
using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class Member : Equatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int PersonalScore { get; set; }

        public virtual Group AttendedGroup { get; set; }
        public virtual ICollection<TeamMember> AttendedTeams { get; set; }
        public virtual ICollection<MemberActivityAttendance> ActivityResults { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
