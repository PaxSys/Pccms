using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.Json
{
    public abstract class JsonRepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly string _filePath;

        protected JsonRepositoryBase(string filePath)
        {
            Guard.ArgumentNotDefault(filePath, nameof(filePath));
                
            _filePath = filePath;
        }
            
        public T[] Get()
        {
            return Read();
        }

        public T Get(int id)
        {
            return Read().FirstOrDefault(x => x.Id == id);
        }

        public void Store(T item)
        {
            Write(contests =>
            {
                contests.RemoveAll(x => x.Id == item.Id);
                contests.Add(item);
            });
        }

        public void Remove(T item)
        {
            Write(contests =>
            {
                contests.RemoveAll(x => x.Id == item.Id);
            });
        }
        
        protected T[] Read()
        {
            using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                string itemsString;  
                
                using (var streamReader = new StreamReader(fileStream))
                    itemsString = streamReader.ReadToEnd();
                
                var contests = JsonConvert.DeserializeObject<List<T>>(itemsString) ?? new List<T>();
                return contests.ToArray();
            }
        }

        protected void Write(Action<List<T>> action)
        {
            using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                string contestsString;  
                
                using (var streamReader = new StreamReader(fileStream))
                    contestsString = streamReader.ReadToEnd();
                
                var contests = JsonConvert.DeserializeObject<List<T>>(contestsString) ?? new List<T>();
                action(contests);
                contestsString = JsonConvert.SerializeObject(contests);

                using (var streamWriter = new StreamWriter(fileStream))
                    streamWriter.WriteLine(contestsString);
            }
        }
    }
}