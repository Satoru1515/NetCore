using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string UrlCoverImage { get; set; }
        public string UrlUpoadedFile { get; set; }

        public int AuthorId { get; set; }

        public IFormFile CoverImage { get; set; }
        public IFormFile UploadedFile { get; set; }

    }
}
