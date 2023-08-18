using Account_Task.BLL.Interfaces;
using Account_Task.BLL.Repositories;
using Account_Task.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Account_Task.Controllers
{
    public class UserController : Controller
    {
        private IUsersRepositories _userRepositories;

        public UserController( IUsersRepositories usersRepositories)
        {
            _userRepositories = usersRepositories;
        }

        public IActionResult Index()
        {

            var user = _userRepositories.GetAll();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(users users)
        {
            if(ModelState.IsValid)
            {
                _userRepositories.Add(users);
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        public IActionResult Detail(int? id)
        {
            if(id is  null)
                return BadRequest();
            var user = _userRepositories.Get(id.Value);
            if(user == null)
                return NotFound();
            return View(user);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var user = _userRepositories.Get(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
           
        }
        [HttpPost]
        public IActionResult Edit(users users)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _userRepositories.Update(users);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                   ModelState.AddModelError(string.Empty, ex.Message);
                }
              
            }
            return View(users);
        }
    }
}
