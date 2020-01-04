using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public interface IPostRepository
    {
        Post AddPost(Post post);
        Post EditPost(Post post);
        List<Post> GetAllPost();
    }
}
