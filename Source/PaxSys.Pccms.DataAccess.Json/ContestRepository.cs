using System.IO;
using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.DataAccess.Json
{
    public class JsonContestRepository : JsonRepositoryBase<Contest>, IContestRepository
    {
        private const string FileName = "contests.json";
                
        public JsonContestRepository(string directoryPath) : base(Path.Combine(directoryPath, FileName))
        {
        }

        public Contest GetDetailedContest(int id)
        {
            return Get(id);
        }
    }
}