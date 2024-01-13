using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReqManager.Models;
using System.Linq;
using System.Security.Claims;

namespace ReqManager.Controllers
{
    public class RequestsController : Controller
    {
        private readonly RequestDbContext _context;

        public RequestsController(RequestDbContext context)
        {
            _context = context;
        }

        // GET: Requests
        [Authorize]
        public IActionResult Index()
        {
            var reqs = _context.Requests.ToList();
            return View(reqs);
        }

        // GET: Requests/Details/5
        public ActionResult Details(int id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == id);
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestModel requestmodel)
        {
            if (ModelState.IsValid)
            {
                requestmodel.Created = DateTime.Now;
                requestmodel.Status = RequestStatus.Open;

                requestmodel.CreatedBy = User.Identity.Name;

                _context.Requests.Add(requestmodel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestmodel);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == id);
            return View(request);
        }

        // POST: Requests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestModel requestmodel)
        {
            if (ModelState.IsValid)
            {
                var existingRequest = _context.Requests.FirstOrDefault(x => x.Id == id);
                existingRequest.Description = requestmodel.Description;
                existingRequest.ShortDescription = requestmodel.ShortDescription;
                existingRequest.Comment = requestmodel.Comment;
                existingRequest.Status = requestmodel.Status;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestmodel);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == id);
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var request = _context.Requests.FirstOrDefault(x => x.Id == id);
            _context.Requests.Remove(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
