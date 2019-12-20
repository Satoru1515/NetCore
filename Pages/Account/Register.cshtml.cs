using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JonaDemo.Models;
using JonaDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JonaDemo
{
    public class RegisterModel : PageModel
    {
        private IUserRepository _userRepository;

        [BindProperty]
        public User user { get; set; }
         

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        { 
             
        
        }


        public IActionResult OnPost()
        {
            _userRepository.AddUser(user);

            return RedirectToPage("/Account/Login");
        }

        
    }
}