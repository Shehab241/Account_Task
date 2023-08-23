using Account_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Interfaces
{
    public interface IUsersRepositories :IGenericRepository<users>
    {
    
    public IQueryable<users> searchUser(string searchValue);

        public bool IsUsernameUnique(string username,int id );
        public bool IsEmailUnique(string email,int id);
        public int getId(string userNumber);

    }
}
