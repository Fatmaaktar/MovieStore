﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models.Domain
{
    public class Movie
    {

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }

        public string? ReleaseYear { get; set; }
        
        public string? MovieImage { get; set; }
        [Required]
        public string? Cast { get; set; }
        [Required]
        public string? Director { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int> Genres { get; set; }
        public IEnumerable<SelectListItem> GenreList;
    }
}