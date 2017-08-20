using System;

namespace PaxSys.Pccms.ContestAdministration.Models.Basic
{
    public class BasicContestViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ContestDate { get; set; }
        public bool IsOver { get; set; }
    }
}