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
    public class AccountRepositories : GenericRepository<Account>, IAccountRepositories
    {
        private readonly ApplicationContext _context;

        public AccountRepositories(ApplicationContext context):base(context)
        {
           _context = context;
        }

        public IQueryable<Account> searchUser(string searchValue)

        {
            
            return _context.Account.Where(u => u.Account_Number.Contains(searchValue.ToLower())
                                   || u.UsersId.ToString().Contains(searchValue)
                                    || u.Id.ToString().Contains(searchValue)).Include(u=>u.Users);
            
        }
        public bool IsAccountNumberUnique(string accountNumber )
        {
            bool isUnique = _context.Account.Any(A => A.Account_Number == accountNumber);    
            
            return isUnique;
        }
        public  bool AccountNumberValid(string accountNumber)
        {
            bool isvaild= accountNumber.Length == 7 && accountNumber.All(char.IsDigit);
            return isvaild;
        }
        public  int getId(string accountNumber)
        {
            int id = 0;
            var user =  _context.Account.FirstOrDefault(u => u.Account_Number == accountNumber);
            if (user != null)
            {
                id = user.Id;
            }
            return id;
        }
    }
}
