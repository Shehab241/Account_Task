using Account_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Interfaces
{
    public interface IUsersRepositories 
    {
        IEnumerable <users> GetAll();

        int Add(users item);

        int Update(users item);
        users Get(int id);
        void Delete(users item);
    }
}
