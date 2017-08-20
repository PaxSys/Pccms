using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PaxSys.Pccms.ContestAdministration.Mappings;
using PaxSys.Pccms.DataAccess.Sql.Contexts;
using PaxSys.Pccms.DataAccess.Sql.Repositories;

namespace PaxSys.Pccms.ContestAdministration.Controllers
{
    public class ContestController : Controller
    {
        private readonly ContestRepository _repository;

        public ContestController()
        {
            _repository = new ContestRepository(DataAccess.Sql.Contexts.ContestAdministrationContext.Create());
        }

        public IActionResult Index()
        {
            var contests = _repository.GetAll();
            var contestsVm = contests.Select(BasicMapping.MapBasicContestViewModel).ToArray();

            return View(contestsVm);
        }

        public IActionResult Details(int id)
        {
            var contest = _repository.GetDetailedContest(id);
            var contestVm = DetailedMapping.MapDetailedContestViewModel(contest);

            return View(contestVm);
        }
    }
}