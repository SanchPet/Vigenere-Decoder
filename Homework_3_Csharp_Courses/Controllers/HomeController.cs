using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework_3_Csharp_Courses.Models;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Xunit;
using Microsoft.AspNetCore.Http;
using Xceed.Words.NET;
using Homework_3_Csharp_Courses.Views.Home;

namespace Homework_3_Csharp_Courses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Encrypt()
        {
            return View();
        }

        public IActionResult Decrypt()
        {
            return View();
        }

        public IActionResult Thanks()
        {
            return View();
        }

        public IActionResult SThanks()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DownloadFile(string encodedText, string downlType)
        {
            try
            {
                var stream = new MemoryStream();
                if (downlType == "Download as docx")
                {
                    using (var t = DocX.Create(stream))
                    {
                        t.InsertParagraph(encodedText);
                        t.Save();
                    }
                    stream.Position = 0;
                    return File(stream, "application/vnd.ms-word", "result.docx");
                }
                else if (downlType == "Download as txt")
                {
                    using (var t = new StreamWriter(stream))
                    {
                        t.Write(encodedText.ToCharArray());
                        t.Flush();
                        stream.Position = 0;
                        return File(new MemoryStream(stream.ToArray()), "text/plain", "result.txt");
                    }
                }
                else throw new Exception("Неизвестная ошибка");
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult DecryptFile(IFormFile UsersFile, string Key, string InputText, bool Rus)
        {
            if (UsersFile != null)
            {
                try
                {
                    if (Rus)
                    {
                        ViewBag.Result = EncryptOperations.Decoder(EncryptOperations.ParseWord(UsersFile), Key, "Rus");
                    }
                    else
                    {
                        ViewBag.Result = EncryptOperations.Decoder(EncryptOperations.ParseWord(UsersFile), Key, "Eng");
                    }
                }
                catch(Exception e)
                {
                    return Content(e.Message);
                }
            }          
            else
            {
                try
                {
                    if (Rus)
                    {
                        ViewBag.Result = EncryptOperations.Decoder(InputText, Key, "Rus");
                    }
                    else
                    {
                        ViewBag.Result = EncryptOperations.Decoder(InputText, Key, "Eng");
                    }
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
            }
            ViewBag.BaseValue = InputText;
            ViewBag.Key = Key;
            return View("Decrypt");
        }

        [HttpPost]
        public IActionResult EncryptFile(IFormFile UsersFile, string InputText, string Key, bool Rus)
        {
            if (UsersFile != null)
            {
                try
                {
                    if (Rus)
                    {
                        ViewBag.Result = EncryptOperations.Encoder(EncryptOperations.ParseWord(UsersFile), Key, "Rus");
                    }
                    else
                    {
                        ViewBag.Result = EncryptOperations.Encoder(EncryptOperations.ParseWord(UsersFile), Key, "Eng");
                    }
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
            }
            else
            {
                try
                {
                    if (Rus)
                    {
                        ViewBag.Result = EncryptOperations.Encoder(InputText, Key, "Rus");
                    }
                    else
                    {
                        ViewBag.Result = EncryptOperations.Encoder(InputText, Key, "Eng");
                    }
                }
                catch(Exception e)
                {
                    return Content(e.Message);
                }
            }
            ViewBag.BaseValue = InputText;
            ViewBag.Key = Key;
            return View("Decrypt");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
   
    
}
