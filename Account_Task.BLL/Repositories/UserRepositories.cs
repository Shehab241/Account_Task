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
    public class UserRepositories : IUsersRepositories
        
    {
        private readonly ApplicationContext _context;

        public UserRepositories(ApplicationContext context)
        {
            _context = context;
        }
        public int Add(users item)
        {
            _context.Users.Add(item);
             return _context.SaveChanges();
        }

        public void Delete(users item)
        {
            _context.Users.Remove(item);
        }

        public users Get(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<users> GetAll()
        {
            return _context.Users.ToList();
        }

        public int Update(users item)
        {
            _context.Users.Update(item);
            return _context.SaveChanges() ;
        }

       
    }
}
