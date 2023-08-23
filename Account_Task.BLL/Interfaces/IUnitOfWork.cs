using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IAccountRepositories accountRepositories { get; set; }

        public IUsersRepositories usersRepositories { get; set; }
        Task<int> Compelete();

    }
}
