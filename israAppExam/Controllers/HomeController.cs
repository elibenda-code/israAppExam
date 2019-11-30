using israAppExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace israAppExam.Controllers
{
    public class HomeController : Controller
    {
        GitHubRipo gitHubRipo = new GitHubRipo();
        List<GItHubList> gItHubList = new List<GItHubList>();
        public ActionResult Index()
        {
            if (Session["GItHubList"] != null)
            {
                gItHubList = Session["GItHubList"] as List<GItHubList>;
                gitHubRipo.gItHubList = gItHubList;
            }

            return View(gitHubRipo);
        }

        [HttpPost]
        public JsonResult SaveGitHubList(string id,string name,string url,string login,string description,string watchers,string language)
        {
            if (Session["GItHubList"] != null)
            {
                gItHubList = Session["GItHubList"] as List<GItHubList>;                
            }
            if (!gItHubList.Where(searchItem => searchItem.id == id).Any())
            {
                gItHubList.Add(new GItHubList
                {
                    id = id,
                    name = name,
                    url = url,
                    login = login,
                    description = description,
                    watchers = watchers,
                    language = language
                });
            }
            Session["GItHubList"] = gItHubList;

            return Json("Add github item to session");
        }
    }
}