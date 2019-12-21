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
    public class LoginModel : PageModel
    {
        private IUserRepository _userRepository;


        [BindProperty]
        public User user { get; set; }

        public string error { get; set; }
        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
     
        }
        
        public IActionResult OnPost()
        {
            var _user = _userRepository.GetUser(user.Email, user.Password);

            if (_user == null)
            {
                this.error = "Incorrect email or passsword";
                return Page();
            }
            else
            {
                _userRepository.SetUserLogged(_user);
                
            }


            return RedirectToPage("/Index");
        }
    }
}