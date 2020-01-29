﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            var articles = new[]{
                new Article {
                    Author = "Donna",
                    Title = "Test title",
                    Body = "Testing body",
                    DateCreated = DateTime.Now
                },
                new Article {
                    Author = "Donna",
                    Title = "Test title",
                    Body = "Testing body",
                    DateCreated = DateTime.Now
                }
            };
            return View();
        }
        public IActionResult Example()
        {
            Article article = new Article
            {
                Author = "Donna",
                Title = "Test title",
                Body = "Testing body",
                DateCreated = DateTime.Now
            };
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article article)
        {
            article.DateCreated = DateTime.Now;
            return View(article);
        }
    }
}