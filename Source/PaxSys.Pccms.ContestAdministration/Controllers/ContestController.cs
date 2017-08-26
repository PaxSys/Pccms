using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaxSys.Pccms.ContestAdministration.Mappings;
using PaxSys.Pccms.Domain;

namespace PaxSys.Pccms.ContestAdministration.Controllers
{
    public class ContestController : Controller
    {
        private readonly IContestRepository _contestRepository;
        
        public ContestController(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository;
        }

        public IActionResult Index()
        {
            var contests = _contestRepository.Get();
            var contestsVm = contests.Select(BasicMapping.MapBasicContestViewModel).ToArray();

            return View(contestsVm);
        }

        public IActionResult Details(int id)
        {
            var contest = _contestRepository.GetDetailedContest(id);
            var contestVm = DetailedMapping.MapDetailedContestViewModel(contest);

            return View(contestVm);
        }
    }
}