using System;

namespace PaxSys.Pccms.ContestAdministration.Models
{
    public class ContestViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsOver { get; set; }

        public ContestViewModel()
        {
        }
    }
}