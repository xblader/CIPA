using CIPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;

namespace CIPA.Persistence
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        static ConcurrentDictionary<string, T> _todos = new ConcurrentDictionary<string, T>();

        public Repository()
        {
            var newEntity = Activator.CreateInstance<T>();
            newEntity.Name = "Item1";
            Add(newEntity);
        }

        public IEnumerable<T> GetAll()
        {
            return _todos.Values;
        }

        public void Add(T item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public T Find(string key)
        {
            T item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public T Remove(string key)
        {
            T item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(T item)
        {
            _todos[item.Key] = item;
        }
    }
}
