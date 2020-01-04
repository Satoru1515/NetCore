using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public class PostRepository : IPostRepository
    {
        private List<Post> Posts { get; set; }

        public PostRepository()
        {
            this.Posts = new List<Post>();
        }
         
    
        public Post AddPost(Post post) 
        {
            this.Posts.Add(post);
            return post;
        }

        public Post EditPost(Post post)
        {
            Post actual_post = this.Posts.FirstOrDefault(p => p.Id == post.Id);

            actual_post.Name = post.Name;
            actual_post.Description = post.Description;

            return actual_post;
        }

        public List<Post> GetAllPost()
        {
            return this.Posts.ToList();
        }
    }
}
