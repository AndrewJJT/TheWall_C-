using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context){
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(User newUser){
            if (ModelState.IsValid){
                
                if (dbContext.users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                //Hash the password
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                //Add new user to database
                dbContext.Add(newUser);
                HttpContext.Session.SetString("UserFirstName", newUser.FirstName);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Wall"); //TODO change to whatever the page after sign in 

                }
            }
            else{
                return View("Index");
            }
        }

        public IActionResult ProcessLogin(LoginUser loginUser){
            if (ModelState.IsValid)
            {
            var userFoundInDb = dbContext.users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            
            // check if email exist....
            if (userFoundInDb == null){
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return RedirectToAction("Login");
            }
            
            // then check if password match....
            var hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(loginUser, userFoundInDb.Password, loginUser.LoginPassword);

            if(result == 0){
                ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
                return RedirectToAction("Login");
            }
            
            //when both email and password check out, get session and login in 
            HttpContext.Session.SetString("UserFirstName", userFoundInDb.FirstName);
            HttpContext.Session.SetInt32("UserId", userFoundInDb.UserId);
            return RedirectToAction("Wall"); //TODO change to whatever the page after sign in 
            }

            else{
                return View("Index");
            }

        }

        [HttpGet("Wall")]  //TODO modify logic based on the exam 
        public IActionResult Wall(){
            if(HttpContext.Session.GetInt32("UserFirstName") != null){
                
                ViewBag.currentUserFirstName = HttpContext.Session.GetString("UserFirstName");

                int? currentUserId = HttpContext.Session.GetInt32("UserId");
                int currentLoginId = (int) currentUserId;
                
                ViewBag.UserId = currentLoginId;

                List<Message> allMessages = dbContext.messages.Include(m => m.Creator).Include(mc => mc.Comments).OrderByDescending(d => d.CreatedAt).ToList();
                ViewBag.allmessages = allMessages;

                List<Comment> allComments = dbContext.comments.Include(c => c.Message).Include(cw => cw.User).OrderByDescending(d => d.CreatedAt).ToList();
                ViewBag.allcomments = allComments;

                return View();
            }
            else{
                return RedirectToAction("Index");
            }
        }

        [HttpPost("ProcessAddMessage")]
        public IActionResult ProcessAddMessage(IndexViewModel indexmodeldata){
            
            // ViewBag.UserId = (int) HttpContext.Session.GetInt32("UserId");

            int? currentUserId = HttpContext.Session.GetInt32("UserId");
            int currentLoginId = (int) currentUserId;
                
            ViewBag.UserId = currentLoginId;

            Message newMessage = indexmodeldata.IndexMessage;

            if(ModelState.IsValid){

                dbContext.messages.Add(newMessage);
                dbContext.SaveChanges();
                return RedirectToAction("Wall");
            }
            else{
                return View("Wall");
            }
        }

        [HttpPost("ProcessAddComment")]
        public IActionResult ProcessAddComment(IndexViewModel indexmodeldata){
            
            ViewBag.UserId = (int) HttpContext.Session.GetInt32("UserId");

            Comment newComment = indexmodeldata.IndexComment;

            if(ModelState.IsValid){

                dbContext.comments.Add(newComment);
                dbContext.SaveChanges();
                return RedirectToAction("Wall");
            }
            else{
                return View("Wall");
            }
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
