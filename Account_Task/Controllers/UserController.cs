using Account_Task.BLL.Interfaces;
using Account_Task.BLL.Repositories;
using Account_Task.DAL.Context;
using Account_Task.DAL.Enums;
using Account_Task.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Principal;

namespace Account_Task.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private IUsersRepositories _userRepositories;
        //private readonly IAccountRepositories _accountRepositories;

        public UserController( IUnitOfWork unitOfWork
           /* IUsersRepositories usersRepositories
            ,IAccountRepositories accountRepositories*/)
        {
            _unitOfWork = unitOfWork;
            //_userRepositories = usersRepositories;
            //_accountRepositories = accountRepositories;
            
        }

        public async Task<IActionResult> Index(string searchValue)
        {
          
            if (string.IsNullOrEmpty(searchValue))
            {
                var user = await _unitOfWork.usersRepositories.GetAll();
                
                return View(user);
            }
            else
            {
              
                var user = _unitOfWork.usersRepositories.searchUser(searchValue);
                return View(user);
            }
            
        }

      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(users users,string SaveContinue)
        {
            if (_unitOfWork.usersRepositories.IsUsernameUnique(users.Username,users.Id))
            {
                ModelState.AddModelError("Username", "This username is already taken.");
                return View(users);
            }
            else if (_unitOfWork.usersRepositories.IsEmailUnique(users.Email,users.Id))
            {
                ModelState.AddModelError("Email","This email address is already in use.");
                return View(users);
            }
            else
            { 
                await _unitOfWork.usersRepositories.Add(users);
                await _unitOfWork.Compelete();
                return RedirectToAction(nameof(Index));
            }

            
        }

        public async Task<IActionResult> Detail(int? id,string Viewname="Detail")
        {
            if(id is  null)
                return BadRequest();
            var user = await _unitOfWork.usersRepositories.Get(id.Value);
            if(user == null)
                return NotFound();
            return View(Viewname, user);
        }
        public async Task<IActionResult> Edit( int? id)
        {
           
            return await Detail(id,"Edit");
           
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(users users, string? SaveContinue)
        {
            if (ModelState.IsValid)
            {
                 if (_unitOfWork.usersRepositories.IsUsernameUnique(users.Username,users.Id))
                     {
                         ModelState.AddModelError("Username", "This username is already taken.");
                         return View(users);
                     }
                 else if (_unitOfWork.usersRepositories.IsEmailUnique(users.Email, users.Id))
                     {
                         ModelState.AddModelError("Email", "This email address is already in use.");
                         return View(users);
                     }
                   try
                   {
                       if (!string.IsNullOrEmpty(SaveContinue))
                       {
                           _unitOfWork.usersRepositories.Update(users);
                         await _unitOfWork.Compelete();
                           return View(users);
                       }
                            _unitOfWork.usersRepositories.Update(users);
                       await _unitOfWork.Compelete();
                    return RedirectToAction(nameof(Index));
                   }
                   catch (Exception ex)
                   {
                       ModelState.AddModelError(string.Empty, ex.Message);
                   }

            }

            return View(users);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Detail(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(users users)
        {
          
            try
            {
                users.Status = Status.Deleted;
                var rec =await _unitOfWork.accountRepositories.Get(users.Id);
                if(rec != null) { rec.Status = Status.Deleted; }
                
                _unitOfWork.usersRepositories.Update(users);
                await _unitOfWork.Compelete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(users);
            }

           
        }

    }
}
