using TabloidMVC.Models;
using TabloidMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TabloidMVC.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepo;
        public UserProfilesController(
            IUserProfileRepository userProfileRepository) 
        {
             _userProfileRepo = userProfileRepository;
        }
        // GET: UserProfilesController
        public ActionResult Index()
        {
            List<UserProfile> userProfiles = _userProfileRepo.GetAllUserProfiles();

            foreach (var userProfile in userProfiles)
            {
                var fullName = userProfile.FullName;
            }

            return View(userProfiles);
        }

        // GET: UserProfilesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfilesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfilesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfilesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfilesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfilesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfilesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
