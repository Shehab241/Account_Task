using Account_Task.BLL.Interfaces;
using Account_Task.DAL.Context;
using Account_Task.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Repositories
{
    public class GenericRepository <T> :IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().AddAsync(item);
            
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
  
        }

        public  T Get(int? id)
        {
            return  _context.Set<T>().Find(id);
        }

        public  IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Account))
            {
              return (IEnumerable<T>)  _context.Account.Include(A=>A.Users).ToList();
            }else
                return _context.Set<T>().ToList();
        }

       

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            
        }
    }
}
