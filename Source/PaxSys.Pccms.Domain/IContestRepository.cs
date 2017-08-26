using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.Domain
{
    public interface IContestRepository : IRepository<Contest>
    {
        Contest GetDetailedContest(int id);
    }
}