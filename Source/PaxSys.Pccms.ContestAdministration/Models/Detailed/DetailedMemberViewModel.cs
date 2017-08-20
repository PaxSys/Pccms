using System;
using PaxSys.Pccms.ContestAdministration.Models.Basic;

namespace PaxSys.Pccms.ContestAdministration.Models.Detailed
{
    public class DetailedMemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int PersonalScore { get; set; }
        public virtual BasicGroupViewModel AttendedGroup { get; set; }
    }
}