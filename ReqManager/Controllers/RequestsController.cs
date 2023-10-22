using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReqManager.Models;

namespace ReqManager.Controllers
{
    public class Requests : Controller
    {

        private static IList<RequestModel> reqs = new List<RequestModel>()
        {
            new RequestModel(){Id = 1 , ShortDescription = "Laptop issue", Description = "My laptop can't turn on, please help me", Comment = " ", Status = RequestStatus.Open, Created = DateTime.Now},
            new RequestModel(){Id = 2 , ShortDescription = "Headphones dies", Description = "Please replace my headset", Comment = " ", Status = RequestStatus.Open, Created = DateTime.Now},
            new RequestModel(){Id = 3 , ShortDescription = "External display", Description = "I need 2nd monitor for my work", Comment = " ", Status = RequestStatus.InProgress, Created = DateTime.Now},
        };

        // GET: Requests
        public ActionResult Index()
        {
            return View(reqs);
        }

        // GET: Requests/Details/5
        public ActionResult Details(int id)
        {
            return View(reqs.FirstOrDefault(x => x.Id == id));
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
            requestmodel.Id = reqs.Count + 1;
            reqs.Add(requestmodel);
            return RedirectToAction("Index");
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            return View(reqs.FirstOrDefault(x => x.Id == id));
        }

        // POST: Requests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestModel requestmodel)
        {
            RequestModel requestmodel1 = reqs.FirstOrDefault(x => x.Id == id);
            requestmodel1.Description = requestmodel.Description;
            requestmodel1.ShortDescription = requestmodel.ShortDescription;
            requestmodel1.Comment = requestmodel.Comment;
            requestmodel1.Status = requestmodel.Status;
            requestmodel1.Created = requestmodel.Created;

            return RedirectToAction("Index");
        }

            // GET: Requests/Delete/5
            public ActionResult Delete(int id)
        {
            return View(reqs.FirstOrDefault(x => x.Id == id));
        }

        // POST: Requests/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RequestModel requestmodel)
        {
            RequestModel requestmodel1 = reqs.FirstOrDefault(x => x.Id == id);
            reqs.Remove(requestmodel1);
            return RedirectToAction("index");

        }
    }
}
