using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepo ExperienceRepo;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public ExperienceController(IExperienceRepo _ExperienceRepo, IWebHostEnvironment _WebHostEnvironment)
        {
            ExperienceRepo = _ExperienceRepo;
            WebHostEnvironment = _WebHostEnvironment;
        }

        //index
        public IActionResult Index(string search)
        {
            List<Experience> ExperienceList;

            if (!string.IsNullOrEmpty(search))
            {
                ExperienceList = ExperienceRepo.Search(search);
            }
            else
            {
                ExperienceList = ExperienceRepo.GetAll();
            }
            return View("Index", ExperienceList);
        }

        public IActionResult Experiences(string search)
        {
            List<Experience> ExperienceList;

            if (!string.IsNullOrEmpty(search))
            {
                ExperienceList = ExperienceRepo.Search(search);
            }
            else
            {
                ExperienceList = ExperienceRepo.GetAll();
            }
            return View("Experiences", ExperienceList);
        }

        //details
        public IActionResult Details(int Id)
        {
            Experience ExperienceDetails = ExperienceRepo.GetById(Id);
            return View("Details", ExperienceDetails);
        }

        //new
        [HttpGet]
        public IActionResult New()
        {
            Experience ExperienceNew = new Experience();

            return View("New", ExperienceNew);
        }

        [HttpPost]
        public IActionResult SaveNew(Experience experiencenew, IFormFile FileImages)
        {
            if (ModelState.IsValid)
            {
                if (FileImages != null && FileImages.Length > 0)
                {
                    var filePath = Path.Combine(WebHostEnvironment.WebRootPath, "Images/Experience/", FileImages.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        FileImages.CopyTo(stream);
                    }

                    experiencenew.Image = FileImages.FileName;
                }

                ExperienceRepo.Insert(experiencenew);
                ExperienceRepo.Save();

                return RedirectToAction("Index", "Experience");
            }

            return View("New", experiencenew);
        }

        //edit
        public IActionResult Edit(int id)
        {
            Experience ExperienceEdit = ExperienceRepo.GetById(id);
            return View("Edit", ExperienceEdit);
        }

        [HttpPost]
        public IActionResult SaveEdit(Experience ExperienceReq, IFormFile? FileImages)
        {
            if (ModelState.IsValid)
            {
                Experience ExperienceDb = ExperienceRepo.GetById(ExperienceReq.Id);
                ExperienceDb.Name = ExperienceReq.Name;
                ExperienceDb.Description = ExperienceReq.Description;
                ExperienceDb.Price = ExperienceReq.Price;  
                ExperienceDb.Duration = ExperienceReq.Duration;
                ExperienceDb.Image = ExperienceReq.Image;

                ViewData["ImageFileName"] = ExperienceDb.Image;


                ExperienceRepo.Update(ExperienceDb);
                ExperienceRepo.Save();
                return RedirectToAction("Index", "Experience");
            }
            return View("Edit", ExperienceReq);
        }

        //delete
        public IActionResult Delete(int id)
        {
            Experience ExperienceDelete = ExperienceRepo.GetById(id);

            if (ExperienceDelete == null)
            {
                return NotFound(); 
            }
            return View("Delete", ExperienceDelete);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Experience experience = ExperienceRepo.GetById(id);

            if (experience == null)
            {
                return NotFound(); 
            }

            ExperienceRepo.Delete(experience.Id);
            ExperienceRepo.Save();

            return RedirectToAction("Index", "Experience");
        }
    }
}
