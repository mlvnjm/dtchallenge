using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DealerTrack.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DealerTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Deal>());
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    var fileManager = new CsvFileManager();
                    return View("Index", fileManager.ParseFileData(file));
                }
                catch
                {
                    return RedirectToAction("Error");
                }

            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
