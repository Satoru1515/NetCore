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
    public class IndexModel : PageModel
    {
        public List<Post> posts { get; set; }
        private IPostRepository _postRepository;

        public IndexModel(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        public void OnGet()
        {
            this.posts = _postRepository.GetAllPost();
        }


    }
}