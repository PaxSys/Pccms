using System;
using System.Collections.Generic;
using PaxSys.Pccms.ContestAdministration.Models.Basic;

namespace PaxSys.Pccms.ContestAdministration.Models.Detailed
{
    public class DetailedContestViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ContestDate { get; set; }
        public bool IsOver { get; set; }

        public BasicUserViewModel OwnerUser { get; set; }
        public List<BasicGroupViewModel> Groups { get; set; }
        public List<BasicActivityViewModel> Activities { get; set; }
    }
}