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
        public async Task Add(T item)
        {
           await _context.Set<T>().AddAsync(item);
            
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
  
        }

        public async Task<T> Get(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Account))
            {
              return (IEnumerable<T>) await _context.Account.Include(A=>A.Users).ToListAsync();
            }else
                return await _context.Set<T>().ToListAsync();
        }

       

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            
        }
    }
}
