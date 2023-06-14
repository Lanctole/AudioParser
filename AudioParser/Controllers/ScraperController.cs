using AudioParser.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace AudioParser.Controllers
{
    public class ScraperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Parse(string url,string saveDir)
        {
            AudioSaver saver = new AudioSaver(url,saveDir);
            //ViewBag.Message = "Done";
            //var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
            return Json( "Done");
            //var web = new HtmlWeb();
            //var doc = web.Load(url);
            //var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
            //var description = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"]?.Value;
            //var keywords = doc.DocumentNode.SelectSingleNode("//meta[@name='keywords']")?.Attributes["content"]?.Value;
            //return Json(new { title, description, keywords });
        }
    }
}
