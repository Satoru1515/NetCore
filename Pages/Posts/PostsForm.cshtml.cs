using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JonaDemo.Models;
using JonaDemo.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JonaDemo
{
    public class BooksFormModel : PageModel
    {
        private IPostRepository _postRepository;
        private IAuthorRepository _authorRepository;
        IHostingEnvironment _env;

        public List<Author> authors;


        [BindProperty]
        public Post post { get; set; }

        public BooksFormModel(IPostRepository postRepository, IAuthorRepository authorRepository, IHostingEnvironment hostingEnvironment)
        {
            this._postRepository = postRepository;
            this._authorRepository = authorRepository;
            this._env = hostingEnvironment;
        }

         

        public void OnGet()
        {
            this.authors = _authorRepository.GetAllAuthors();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ImageUpload(post.CoverImage);
            BookUpload(post.UploadedFile);
            _postRepository.AddPost(post);
            return RedirectToPage("/Posts/Index");
        }

        // IMAGE UPLOAD FUNCTION
        public async void ImageUpload(IFormFile file)
        {
            if(file  != null  && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadPath = this._env.WebRootPath + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }  

                //Create unique file nam
                var uniqueFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(uniqueFileName + "." + file.FileName.Split(".")[1].ToLower());
                var fullPath = uploadPath + fileName;


                imagePath = imagePath + @"\";

                var filePath = @".." + Path.Combine(imagePath, fileName);

                using (var filestream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }

                this.post.UrlCoverImage = filePath;
                 
            }     
        }
        // END IMAGE UPLOAD FUNCTION



        // BOOK UPLOAD FUNCTION
        public async void BookUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath  = @"\Upload\Books\";
                var uploadPath = this._env.WebRootPath + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                //Create unique file nam
                var uniqueFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(uniqueFileName + "." + file.FileName.Split(".")[1].ToLower());
                var fullPath = uploadPath + fileName;


                imagePath = imagePath + @"\";

                var filePath = @".." + Path.Combine(imagePath, fileName);

                using (var filestream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }

                this.post.UrlUpoadedFile = filePath;

            }
        }
        // END BOOK UPLOAD FUNCTION




    }
}