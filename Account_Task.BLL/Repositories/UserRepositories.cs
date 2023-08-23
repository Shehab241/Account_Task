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
    public class UserRepositories : GenericRepository<users>, IUsersRepositories

    {
        private readonly ApplicationContext _context;

        public UserRepositories(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<users> searchUser(string searchValue)

        => _context.Users.Where(u => u.Email.ToLower(). Contains(searchValue.ToLower())
                                   || u.Username.ToLower().Contains(searchValue.ToLower())
                                    ||u.Id.ToString().Contains(searchValue.ToLower())
                                   
            );

        public bool IsUsernameUnique(string username,int id )
        {
            // Check your data  (e.g., database) for existing usernames
            bool isUnique = _context.Users.Any(u => u.Username == username&&u.Id!=id );
            return isUnique;
        } 
        public bool IsEmailUnique(string email,int id )
        {
            bool isUnique = _context.Users.Any(u => u.Email == email && u.Id != id);
            return isUnique;
        }

        public async Task<int> getId(string userNumber)
        {
            int id = 0;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userNumber);
            if (user != null)
            {
                id = user.Id;
            }
            return id;
        }







    }
}
