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
    public class AuthorFormModel : PageModel
    {
        private IAuthorRepository _authorRepository;

        private IHostingEnvironment _env;

        [BindProperty]
        public Author author { get; set; }


        public AuthorFormModel(IAuthorRepository authorRepository, IHostingEnvironment hostingEnvironment)
        {
            this._authorRepository = authorRepository;
            this._env = hostingEnvironment;
        }
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            ImageUpload(this.author.ProfileImage);
            this._authorRepository.AddAuthor(this.author);
            return RedirectToPage("/Authors/AuthorList");
        }


        // IMAGE UPLOAD FUNCTION
        public async void ImageUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\AuthorImage\";
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

                this.author.UrlProfileImage = filePath;

            }
        }
        // END IMAGE UPLOAD FUNCTION


    }
}