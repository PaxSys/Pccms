using System.Linq;
using PaxSys.Pccms.ContestAdministration.Models.Detailed;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.ContestAdministration.Mappings
{
    public static class DetailedMapping
    {
        public static DetailedContestViewModel MapDetailedContestViewModel(Contest model)
        {
            return new DetailedContestViewModel
            {
                Id = model.Id,
                Description = model.Description,
                ContestDate = model.ContestDate,
                IsOver = model.IsOver,
                Activities = model.Activities.Select(BasicMapping.MapBasicActivityViewModel).ToList(),
                Groups = model.AttendingGroups.Select(BasicMapping.MapBasicGroupViewModel).ToList(),
            };
        }
    }
}