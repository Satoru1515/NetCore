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
    public class AuthorListModel : PageModel
    {
        private IAuthorRepository _authorRepository;

        public List<Author> authors { get; set; }
        public AuthorListModel(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }
        public void OnGet()
        {
            this.authors = _authorRepository.GetAllAuthors();
        }
    }
}