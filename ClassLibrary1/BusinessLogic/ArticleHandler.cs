using System;
using DataModels;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using DAL;

namespace Library.BusinessLogic
{
    public class ArticleHandler
    {
        private IConfiguration _configuration;

        public ArticleHandler(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public ArticleHandler() { }
        public Article[] GetAllArticlesFromDB() 
        {
            DataAccess da = new DataAccess(_configuration);
            return da.GetAllArticlesFromDB();
        }
        public object AddArticle(Article article)
        {
            DataAccess db = new DataAccess(_configuration);

            var articles = db.AddArticleToDatabase(article);

            return articles;
        }
    }
}
