using PaxSys.Pccms.ContestAdministration.Models.Basic;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.ContestAdministration.Mappings
{
    public static class BasicMapping
    {
        public static BasicContestViewModel MapBasicContestViewModel(Contest model)
        {
            return new BasicContestViewModel()
            {
                Id = model.Id,
                Description = model.Description,
                ContestDate = model.ContestDate,
                IsOver = model.IsOver,
            };
        }

        public static BasicGroupViewModel MapBasicGroupViewModel(Group model)
        {
            return new BasicGroupViewModel()
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
            return new BasicActivityViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }


    }
}