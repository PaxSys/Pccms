using System;
using System.Collections.Generic;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.Domain.Models
{
    public class Contest : Equatable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ContestDate { get; set; }
        public bool IsOver { get; set; }

        public virtual int OwnerId { get; set; }

        public virtual ICollection<Group> AttendingGroups { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
