using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using HotelManagement_MVC.ViewModel;
using HotelManagement_MVC.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NuGet.Protocol.Core.Types;

namespace HotelManagement_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepo ExperienceRepo;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IExperienceTypeRepo experienceTypeRepo;

        public ExperienceController(IExperienceRepo _ExperienceRepo,IExperienceTypeRepo _ExperienceTypeRepo, IWebHostEnvironment _WebHostEnvironment)
        {
            ExperienceRepo = _ExperienceRepo;
            WebHostEnvironment = _WebHostEnvironment;
            experienceTypeRepo= _ExperienceTypeRepo;
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

            //List<ExperienceWithTypesViewModel> listexperienceVM = new List<ExperienceWithTypesViewModel>();
            //foreach (var experience in ExperienceList)
            //{
            //    ExperienceWithTypesViewModel experienceVM = new ExperienceWithTypesViewModel();
            //    experienceVM.ExperienceId = experience.Id;
            //    experienceVM.Type= experience.Type;
            //    experienceVM.Price = experience.Price;
            //    experienceVM.CoverImage = experience.CoverImage;
            //    experienceVM.Image = experience.Image;
            //    listexperienceVM.Add(experienceVM);
            //}

            //experienceVM.Experiences = ExperienceList;

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
            //ExperienceWithTypesViewModel experienceVM = new ExperienceWithTypesViewModel();
            //experienceVM.Experiences = ExperienceList;

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
            //Experience ExperienceNew = new Experience();
            //List<Experience> ExperienceList = ExperienceRepo.GetAll();
            List<ExperienceType> ExperiencetypeList = experienceTypeRepo.GetAll();
            ExperienceWithTypesViewModel experienceVM = new ExperienceWithTypesViewModel(); 
            //experienceVM.Experiences = ExperienceList;
            experienceVM.Type = ExperiencetypeList;
            return View("New", experienceVM);
        }

        [HttpPost]
        public IActionResult SaveNew(ExperienceWithTypesViewModel experiencenew, IFormFile FileImage, IFormFile FileCoverImage)
        {
            List<Experience> ExperienceList = ExperienceRepo.GetAll();
            List<ExperienceType> ExperiencetypeList = experienceTypeRepo.GetAll();
            Experience ExperienceDb = ExperienceRepo.GetById(experiencenew.ExperienceId);
            //experiencenew.Experiences = ExperienceList;
            experiencenew.Type = ExperiencetypeList;
            experiencenew.Price = ExperienceDb.Price;
            experiencenew.ExperienceId = ExperienceDb.Id;
            experiencenew.ExperienceName = ExperienceDb.Name;
            experiencenew.Description = ExperienceDb.Description;
            experiencenew.Duration = ExperienceDb.Duration;

            if (ModelState.IsValid)
            {
                if (FileImage != null && FileImage.Length > 0)
                {
                    var imageFilePath = Path.Combine(WebHostEnvironment.WebRootPath, "Images/Experience/", FileImage.FileName);

                    using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    {
                        FileImage.CopyTo(stream);
                    }

                    experiencenew.Image = FileImage.FileName;
                }

                if (FileCoverImage != null && FileCoverImage.Length > 0)
                {
                    var coverImageFilePath = Path.Combine(WebHostEnvironment.WebRootPath, "Images/Experience/", FileCoverImage.FileName);

                    using (var stream = new FileStream(coverImageFilePath, FileMode.Create))
                    {
                        FileCoverImage.CopyTo(stream);
                    }

                    experiencenew.CoverImage = FileCoverImage.FileName;
                }

                experienceTypeRepo.Insert(experiencenew);
                experienceTypeRepo.Save();

                return RedirectToAction("Index", "Experience");
            }

            return View("New", experiencenew);
        }

        //[HttpPost]
        //public IActionResult SaveNew(Experience experiencenew, IFormFile FileImages)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (FileImages != null && FileImages.Length > 0)
        //        {
        //            var filePath = Path.Combine(WebHostEnvironment.WebRootPath, "Images/Experience/", FileImages.FileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                FileImages.CopyTo(stream);
        //            }

        //            experiencenew.Image = FileImages.FileName;
        //            experiencenew.CoverImage = FileImages.FileName;
        //        }

        //        ExperienceRepo.Insert(experiencenew);
        //        ExperienceRepo.Save();

        //        return RedirectToAction("Index", "Experience");
        //    }

        //    return View("New", experiencenew);
        //}

        //edit
        public IActionResult Edit(int id)
        {
            Experience ExperienceEdit = ExperienceRepo.GetById(id);
            //List<Experience> ExperienceList = ExperienceRepo.GetAll();
            List<ExperienceType> ExperiencetypeList = experienceTypeRepo.GetAll();
            ExperienceWithTypesViewModel experienceVM = new ExperienceWithTypesViewModel();
            //experienceVM.Experiences = ExperienceList;
            experienceVM.Type = ExperiencetypeList;
            experienceVM.Price = ExperienceEdit.Price;
            experienceVM.ExperienceId = ExperienceEdit.Id;
            experienceVM.Image=ExperienceEdit.Image;
            experienceVM.CoverImage=ExperienceEdit.CoverImage;
            experienceVM.ExperienceName = ExperienceEdit.Name;
            experienceVM.Description = ExperienceEdit.Description;
            experienceVM.Duration = ExperienceEdit.Duration;
            return View("Edit", experienceVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(ExperienceWithTypesViewModel ExperienceReq, IFormFile? FileImage, IFormFile? FileCoverImage)
        {
            //ExperienceReq.Experiences != null && ExperienceReq.Type != null && ExperienceReq.Price != null
            //    && ExperienceReq.ExperienceId != 0 && ExperienceReq.ExperienceName != null
            //    && ExperienceReq.Description != null && ExperienceReq.Duration != null
            //    && ExperienceReq.CoverImage != null && ExperienceReq.Image != null
            //List<Experience> ExperienceList = ExperienceRepo.GetAll();

            Experience ExperienceDb = ExperienceRepo.GetById(ExperienceReq.ExperienceId);

            if (ModelState.IsValid)
            {
                //ExperienceReq.Experiences = ExperienceList;
                //ExperienceReq.Type = ExperiencetypeList;
                ExperienceDb.TypeId = ExperienceReq.TypeId;
                ExperienceDb.Price = ExperienceReq.Price;
                ExperienceDb.Id = ExperienceReq.ExperienceId;       
                ExperienceDb.Name = ExperienceReq.ExperienceName;
                ExperienceDb.Description = ExperienceReq.Description;
                ExperienceDb.Duration = ExperienceReq.Duration;

                //ViewData["ImageFileName"] = ExperienceDb.Image;
                ViewData["CoverImageFileName"] = ExperienceDb.CoverImage;

                ExperienceRepo.Update(ExperienceDb);
                ExperienceRepo.Save();
                return RedirectToAction("Index");

            }
            List<ExperienceType> ExperiencetypeList = experienceTypeRepo.GetAll();
            ExperienceReq.Type = ExperiencetypeList;
            //ExperienceReq.Image = ExperienceDb.Image;
            //ExperienceReq.CoverImage = ExperienceDb.CoverImage;
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
