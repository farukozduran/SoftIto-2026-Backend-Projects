using Microsoft.AspNetCore.Mvc;
using Project.Cinema.Data;
using Project.Cinema.Models;

namespace Project.Cinema.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AnnouncementList()
        {
            var announcements = _context.Announcements.OrderByDescending(a => a.PublishDate).ToList();
            return new JsonResult(announcements);
        }

        public JsonResult ActiveAnnouncementList()
        {
            var announcements = _context.Announcements.Where(a => a.IsActive).OrderByDescending(a => a.PublishDate).ToList();
            return new JsonResult(announcements);
        }

        [HttpPost]
        public JsonResult AddAnnouncement(Announcement announcement)
        {
            Announcement newAnnouncement = new Announcement()
            {
                Title = announcement.Title,
                Content = announcement.Content,
                PublishDate = announcement.PublishDate,
                IsActive = announcement.IsActive
            };

            _context.Announcements.Add(newAnnouncement);
            _context.SaveChanges();

            return new JsonResult("Duyuru başarıyla eklendi.");
        }

        public JsonResult EditAnnouncement(int id)
        {
            var announcement = _context.Announcements.Find(id);
            if(announcement is null)
            {
                return new JsonResult(null);
            }

            return new JsonResult(announcement);
        }

        [HttpPost]
        public JsonResult UpdateAnnouncement(Announcement announcement)
        {
            var existingAnnouncement = _context.Announcements.Find(announcement.AnnouncementId);

            if(existingAnnouncement is null)
            {
                return new JsonResult("Duyuru bulunamadı.");
            }

            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Content = announcement.Content;
            existingAnnouncement.PublishDate = announcement.PublishDate;
            existingAnnouncement.IsActive = announcement.IsActive;

            _context.Announcements.Update(existingAnnouncement);
            _context.SaveChanges();

            return new JsonResult("Duyuru başarıyla güncellendi.");
        }

        [HttpPost]
        public JsonResult DeleteAnnouncement(int id)
        {
            var announcement = _context.Announcements.Find(id);
            if(announcement == null)
            {
                return new JsonResult("Duyuru bulunamadı.");
            }

            _context.Announcements.Remove(announcement);
            _context.SaveChanges();

            return new JsonResult("Duyuru başarıyla silindi.");
        }
    }
}
