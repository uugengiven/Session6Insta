using Session6Instagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session6Instagram.Controllers
{
    public class PhotoController : Controller
    {
        public ActionResult UploadPhoto()
        {
            InstagramDbContext database = new InstagramDbContext();
            var users = database.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public string SavePhoto(string photo, int userId, string caption)
        {
            InstagramDbContext database = new InstagramDbContext();
            Photo temp_photo = new Photo();
            temp_photo.Picture = photo;
            temp_photo.Caption = caption;
            temp_photo.PhotoUser = database.Users.Find(userId);
            temp_photo.Date = DateTime.Now;
            database.Photos.Add(temp_photo);
            database.SaveChanges();

            return "I worked?";
        }

        public ActionResult Feed()
        {
            var database = new InstagramDbContext();
            return View(database.Photos.ToList());
        }
    }
}