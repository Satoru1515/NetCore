using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();

        Author GetAuthor(int id);

        Author AddAuthor(Author author);
        Author EditAuthor(Author author);
    }
}
