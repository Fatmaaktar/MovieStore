﻿using MovieStore.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models.DTO
{
    public class MovieListVm
    {
        public IQueryable<Movie> MovieList { get; set; }
    }
}
