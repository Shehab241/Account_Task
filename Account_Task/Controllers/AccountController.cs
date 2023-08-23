using Account_Task.BLL.Interfaces;
using Account_Task.BLL.Repositories;
using Account_Task.DAL.Enums;
using Account_Task.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Security.Principal;

namespace Account_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        
        
        
        public AccountController( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;     
        }

        public  IActionResult Index(string searchValue)
        {

            if (string.IsNullOrEmpty(searchValue))
            {
                var account =  _unitOfWork.accountRepositories.GetAll();

                return View(account);
            }
            else
            {
                var account = _unitOfWork.accountRepositories.searchUser(searchValue);
                return View(account);
            }
        }

        public IActionResult Create()
        {
            try
            {
                
                 ViewBag.User = _unitOfWork.usersRepositories.GetAll();
                
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpPost]

        
        public IActionResult Create(Account account)
        {
            if (!_unitOfWork.accountRepositories.AccountNumberValid(account.Account_Number))
            {
                
                TempData["Message"] = "This AccountNumber is not in vaild.";
                return RedirectToAction(nameof(Index));
            }
                 if (_unitOfWork.accountRepositories.IsAccountNumberUnique(account.Account_Number))
                 {
                    
                    int id =  _unitOfWork.accountRepositories.getId(account.Account_Number);
                    var rec=  _unitOfWork.accountRepositories.Get(id);
                    if (rec.Status == Status.Deleted)
                    {
                       
                        _unitOfWork.accountRepositories.Add(account);
                        _unitOfWork.Compelete();
                    return RedirectToAction(nameof(Index));
                     }
                else
                    {
                     ModelState.AddModelError("AccountNumber", "This AccountNumber is already taken.");
                     TempData["Message"] = "This AccountNumber is already taken.";
                     return RedirectToAction(nameof(Index));

                    }
                }
                 _unitOfWork.accountRepositories.Add(account);
                 _unitOfWork.Compelete();
                return RedirectToAction(nameof(Index));
            }

        public IActionResult Detail(int? id, string Viewname = "Detail")
        {
            if (id is null)
                return BadRequest();
            var account =  _unitOfWork.accountRepositories.Get(id.Value);
            if (account == null)
                return NotFound();
            return View(Viewname, account);
        }
        public  IActionResult Edit(int? id)
        {
           
            ViewBag.User =  _unitOfWork.usersRepositories.GetAll();
            return  Detail(id, "Edit");
             
        }

        [HttpPost]
        public  IActionResult Edit(Account account)
        {

                try
                {
                    _unitOfWork.accountRepositories.Update(account);
                    _unitOfWork.Compelete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            
            return View(account);
        }

        public  IActionResult Delete(int? id)
        {
            return Detail(id, "Delete");
        }

        [HttpPost]
        public  IActionResult Delete(Account account)
        {
            
            try
            {
                account.Status=Status.Deleted;
                
                _unitOfWork.accountRepositories.Update(account);
                _unitOfWork.Compelete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(account);
            }


        }
     
    }
}
