using System;
using System.IO;
using System.Linq;
using LiteDB;
using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.LiteDb
{
    public abstract class LiteDbRepositoryBase<T> : IRepository<T>
        where T : Entity
    {
        private const string FilePath = "Contest.db";

        private readonly string _filePath;

        protected LiteDbRepositoryBase(string directoryPath)
        {
            Guard.ArgumentNotDefault(directoryPath, nameof(directoryPath));

            _filePath = Path.Combine(directoryPath, FilePath);
        }

        public T[] Get()
        {
            return ExecuteRead(collection => collection.FindAll().ToArray());
        }

        public T Get(int id)
        {
            Guard.ArgumentNotDefault(id, nameof(id));

            return ExecuteRead(collection => collection.FindOne(x => x.Id == id));
        }

        public void Store(T item)
        {
            Guard.ArgumentNotDefault(item, nameof(item));

            ExecuteWrite(collection => collection.Upsert(item));
        }

        public void Remove(T item)
        {
            Guard.ArgumentNotDefault(item, nameof(item));
            
            ExecuteWrite(collection => collection.Delete(x => x.Id == item.Id));
        }

        private LiteDatabase GetDatabase()
        {
            return new LiteDatabase(_filePath);
        }
        
        protected void ExecuteWrite(Action<LiteCollection<T>> action)
        {
            using (var db = GetDatabase())
            {
                action(db.GetCollection<T>());
            }
        }

        protected TResult ExecuteRead<TResult>(Func<LiteCollection<T>, TResult> func)
        {
            using (var db = GetDatabase())
            {
                return func(db.GetCollection<T>());
            }
        }
    }
}