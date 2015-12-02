using CIPA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPA.Persistence
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(string key);
        T Remove(string key);
        void Update(T item);
    }
}
