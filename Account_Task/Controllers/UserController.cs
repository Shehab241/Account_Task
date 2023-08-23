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
   

        public UserController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public  IActionResult Index(string searchValue)
        {
          
            if (string.IsNullOrEmpty(searchValue))
            {
                var user =  _unitOfWork.usersRepositories.GetAll();
                
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

        public IActionResult Create(users users,string SaveContinue)
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
                 _unitOfWork.usersRepositories.Add(users);
                 _unitOfWork.Compelete();
                return RedirectToAction(nameof(Index));
            }

            
        }

        public  IActionResult Detail(int? id,string Viewname="Detail")
        {
            if(id is  null)
                return BadRequest();
            var user =  _unitOfWork.usersRepositories.Get(id.Value);
            if(user == null)
                return NotFound();
            return View(Viewname, user);
        }
        public IActionResult Edit( int? id)
        {
           
            return  Detail(id,"Edit");
           
        }

        
        [HttpPost]
        public  IActionResult Edit(users users, string? SaveContinue)
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
                           _unitOfWork.Compelete();
                           return View(users);
                       }
                            _unitOfWork.usersRepositories.Update(users);
                            _unitOfWork.Compelete();
                    return RedirectToAction(nameof(Index));
                   }
                   catch (Exception ex)
                   {
                       ModelState.AddModelError(string.Empty, ex.Message);
                   }

            }

            return View(users);
        }

        public IActionResult Delete(int? id)
        {
            return  Detail(id, "Delete");
        }

        [HttpPost]
        public  IActionResult Delete(users users)
        {
          
            try
            {
                users.Status = Status.Deleted;
                var rec =_unitOfWork.accountRepositories.Get(users.Id);
                if(rec != null) { rec.Status = Status.Deleted; }
                
                _unitOfWork.usersRepositories.Update(users);
                _unitOfWork.Compelete();
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
