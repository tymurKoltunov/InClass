using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DataModels;
using Library.BusinessLogic;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    public class ArticleController : Controller
    {
        private IConfiguration _configuration;

        public ArticleController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

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

            ArticleHandler handler = new ArticleHandler(_configuration);

            var newArticle = handler.AddArticle(article);


            return RedirectToAction("Listing");

            
        }
        public IActionResult Listing()
        {
            ArticleHandler ah = new ArticleHandler(_configuration);
            var articles = ah.GetAllArticlesFromDB();
            return View(articles);
        }
    }
}