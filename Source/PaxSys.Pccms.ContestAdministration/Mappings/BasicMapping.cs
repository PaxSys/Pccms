using PaxSys.Pccms.ContestAdministration.Models;
using PaxSys.Pccms.ContestAdministration.Models.Basic;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.ContestAdministration.Mappings
{
    public static class BasicMapping
    {
        public static ContestViewModel MapBasicContestViewModel(Contest model)
        {
            return new ContestViewModel
            {
                Id = model.Id,
                Description = model.Description,
                Date = model.ContestDate,
                IsOver = model.IsOver,
            };
        }

        public static BasicGroupViewModel MapBasicGroupViewModel(Group model)
        {
            return new BasicGroupViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                GroupScore = model.GroupScore,
                Locale = model.Locale
            };
        }

        public static BasicActivityViewModel MapBasicActivityViewModel(Activity model)
        {
            return new BasicActivityViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }


    }
}