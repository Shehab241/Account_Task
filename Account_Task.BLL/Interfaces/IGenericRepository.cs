using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Interfaces
{
     public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();


        T Get(int? id);

        void Add(T item);

        void Update(T item);
        void Delete(T item);
    }
}
