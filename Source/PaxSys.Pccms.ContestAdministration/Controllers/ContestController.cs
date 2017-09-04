using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using PaxSys.Pccms.ContestAdministration.Mappings;
using PaxSys.Pccms.ContestAdministration.Models;
using PaxSys.Pccms.ContestAdministration.Models.Contest;
using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.ContestAdministration.Controllers
{
    public class ContestController : Controller
    {
        private readonly IContestRepository _contestRepository;
        
        public ContestController(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contests = _contestRepository.Get();
            var contestsVm = contests.Select(BasicMapping.MapBasicContestViewModel).ToArray();

            return View(contestsVm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contest = _contestRepository.GetDetailedContest(id);
            var contestVm = DetailedMapping.MapDetailedContestViewModel(contest);

            return View(contestVm);
        }

        [HttpGet]
        public IActionResult AddContest()
        {
            var viewModel = new AddContestViewModel();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContest([FromForm] AddContestViewModel viewModel)
        {
            var contest = new Contest
            {
                Description = viewModel.Description,
                ContestDate = viewModel.Date
            };
            
            _contestRepository.Store(contest);
            
            return RedirectToAction(nameof(Index));
        }
    }
}