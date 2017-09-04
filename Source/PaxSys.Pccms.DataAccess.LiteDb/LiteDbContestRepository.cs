using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.LiteDb
{
    public class LiteDbContestRepository : LiteDbRepositoryBase<Contest>, IContestRepository
    {
        public LiteDbContestRepository(string directoryPath) : base(directoryPath)
        {
        }

        public Contest GetDetailedContest (int id)
        {
            Guard.ArgumentNotDefault(id, nameof(id));

            return Get(id);            
        }
    }
}
