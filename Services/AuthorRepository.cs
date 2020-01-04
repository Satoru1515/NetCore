using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        List<Author> Authors;

        public AuthorRepository()
        {
            this.Authors = new List<Author>();
        }

        public Author AddAuthor(Author author)
        {
             this.Authors.Add(author);

            return author;
        }

        public Author EditAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAllAuthors()
        {
            return this.Authors;
        }

        public Author GetAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
