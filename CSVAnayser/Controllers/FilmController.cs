using CSVAnayser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;


namespace CSVAnayser.Controllers
{
    public class FilmController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new List<FilmModel>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<FilmModel> film = new List<FilmModel>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);


                bool titles = true;
              

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {

                    List<string> movieCatagories = new List<string>();
                    if (!string.IsNullOrEmpty(row) && titles==false)
                        {

                        foreach (string catagory in (row.Split(',')[2]).Split('|'))
                        {
                            movieCatagories.Add(catagory);
                        }


                        film.Add(new FilmModel
                        {
                            movieId = Convert.ToInt32(row.Split(',')[0]),
                            title = row.Split(',')[1],
                            categories = movieCatagories


                        });
                    }
                    titles = false;
                }
            }

            return View(film);
        }
    }
}
