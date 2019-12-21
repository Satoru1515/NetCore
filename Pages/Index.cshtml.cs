using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JonaDemo.Models;
using JonaDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JonaDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUserRepository _user_repository;

        public User _user { get; set; }

      

        public IndexModel(ILogger<IndexModel> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _user_repository = userRepository;
        }

        public IActionResult OnGet()
        {
            this._user = _user_repository.GetUserLogged();
            if(this._user.Name == null)
            {
                return RedirectToPage("/Account/Login");
            }
            return Page();
        }

        
        
    }
}
