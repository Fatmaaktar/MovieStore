﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;
using MovieStoreMvc.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    //[Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IFileService _fileService;
        private readonly IGenreService _genService;

        public MovieController(IGenreService genservice,IMovieService movieService, IFileService fileService)
        {
            _movieService = movieService;
            _fileService = fileService;
            _genService = genservice;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            var fileResult = this._fileService.SaveImage(model.ImageFile);
            if (fileResult.Item1 == 0)
            {
                TempData["msg"] = "File could not saved";
            }
            var imageName = fileResult.Item2;
            model.MovieImage = imageName;
            var result = _movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "Successfully Added";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error On Server Side";
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _movieService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Movie model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Successfully Added";
                return RedirectToAction(nameof(MovieList));
            }
            else
            {
                TempData["msg"] = "Error On Server Side";
                return View(model);
            }
        }

        public IActionResult MovieList()
        {
            var data = this._movieService.List(); //.toList()
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);
            return RedirectToAction(nameof(MovieList));
        }
    }
}
