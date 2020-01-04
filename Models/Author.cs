﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Models
{
    public class Author
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string UrlProfileImage { get; set; }


        [Required]
        public IFormFile ProfileImage { get; set; }
    }
}
