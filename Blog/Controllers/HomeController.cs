using Blog.Models;
using Business;
using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //  Repository<Article> repoArticle = new Repository<Article>();
        ArticleManager repoArticle = new ArticleManager();
        //Repository<Author> repoAuthor = new Repository<Author>();
        AuthorManager repoAuthor = new AuthorManager();
        // GET: Home
        public ActionResult Index()
        {


           //Test test=new Test();

           
            var articleList = repoArticle.List();
     

            ViewBag.Keywords = "Yazilim , Ticaret, Ekonomi";
            ViewBag.Description = "Test bolg tasarim uygulamasi";
            ViewBag.Title = "Blog Site| Anasayfa";
       
            
            return View(articleList);
        }

        public ActionResult Authors()
        {

            var articleList = repoArticle.List();
            var authorList = articleList.GroupBy(u => new { u.Author }).Select(grp => grp.FirstOrDefault()).ToList();
            ViewBag.AuthorList = authorList.ToList();
            return View();
        }
        public ActionResult Detail(string linkUrl)
        {
            if (linkUrl == null)
            {
                return RedirectToAction("", "");
            }
            ViewBag.Title = "Makale | Detay Sayfasi";
            ArticleViewModel articleModel = (from article in repoArticle.List()
                                             join author in repoAuthor.List() on article.Author equals author.NameSurname
                                             where article.ArticleUrl == linkUrl
                                             select new ArticleViewModel
                                             {
                                                 //Article
                                                 ArticleUrl = article.ArticleUrl,
                                                 ArticleCategory = article.CategoryName,
                                                 ArticleDate = article.ArticleDate,
                                                 Content = article.Content,
                                                 Title = article.Title,
                                                 ArticleReading = article.ReadingCount,
                                                 ArticleTags = article.Tags.Split(','),
                                                 // Author 
                                                 //AuthorAbout = author.AuthorAbout,
                                                 AuthorFacebook = author.FacebookAdress,
                                                 AuthorImageUrl = author.Image,
                                                 AuthorInstagram = author.InstegramAdress,
                                                 AuthorName = author.NameSurname,
                                                 AuthorTwitter = author.TwitterAdress,

                                             }).FirstOrDefault();

            return View(articleModel);
        }

        public ActionResult TopArticle()
        {
            var articleList=repoArticle.List().OrderByDescending(x => x.ReadingCount).Take(3).ToList();
            return View();
        }

        public ActionResult Create()
        {
            Article article = new Article()
            {
                ArticleDate = "10 Şubat 2018",
                Author = "Önceki Yazılımcı",
                ReadingCount = 50,
                CategoryName = "Seyahat",
                Content = "Şanlıurfa'nın güneydoğusunda kalan Harran Ovası, günümüze taşıdığı tarihi değerleriyle bilgi veriyor ve coğrafyasıyla eşsiz bir güzellik sunuyor.",
                ImageUrl = "/Content/img/blog/2.jpg",
                IsActive = true,
                Tags = "Seyahat, Eğlence, Alışveriş, Yazılım, Hello World",
                ArticleUrl = "urfa'nin-sakli-cenneti-harran-ovasi",
                Title = "Seyahat Etmenin Faydaları"
               




            };
            repoArticle.Insert(article);
            repoArticle.Insert(article);
            repoArticle.Insert(article);

            return View();
        }
    }
}