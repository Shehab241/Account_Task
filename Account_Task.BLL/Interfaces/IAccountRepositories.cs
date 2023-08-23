using Account_Task.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Interfaces
{
    public interface IAccountRepositories:IGenericRepository<Account>
    {
        public  IQueryable<Account> searchUser(string searchValue);

        public bool AccountNumberValid(string accountNumber);
        public bool IsAccountNumberUnique(string accountNumber);
        public Task<int> getId(string accountNumber);
    }
}
