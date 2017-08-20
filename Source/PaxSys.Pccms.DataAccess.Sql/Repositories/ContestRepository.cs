using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaxSys.Pccms.DataAccess.Sql.Contexts;
using PaxSys.Pccms.Domain.Models;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.Sql.Repositories
{
    public class ContestRepository : SqlRepositoryBase<ContestAdministrationContext, Contest>
    {
        public ContestRepository(ContestAdministrationContext context) : base(context)
        {
        }

        public Contest GetDetailedContest (int id)
        {
            Guard.ArgumentNotDefault(id, nameof(id));
            
            return Context.Contests.Where(x => x.Id == id)
                .Include(x => x.Activities)
                .Include(x => x.AttendingGroups)
                .FirstOrDefault();
        }

    }
}
