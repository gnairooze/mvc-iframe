using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_iframe.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(int? id)
        {
            Models.Contact contact = GetContact(id);

            return View(contact);
        }

        public ActionResult Upload(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            Models.Contact contact = GetContact(333);

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/") + fileName); //File will be saved in application root
                ViewBag.Message = "File uploaded";
            }

            return View();
        }

        private Models.Contact GetContact(int? age)
        {
            int defaultAge = 29;

            return new Models.Contact()
            {
                Age = (age.HasValue)?age.Value:defaultAge,
                Name = "T. Adel",
                Phones = new List<string>() { "01222222", "01111111", "010000000", "0155555555" }
            };
        }
    }
}