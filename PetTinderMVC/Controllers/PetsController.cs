using Microsoft.AspNetCore.Mvc;
using PetTinderMVC.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System;

namespace PetTinderMVC.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private readonly PetTinderMVCContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public PetsController(UserManager<ApplicationUser> userManager, PetTinderMVCContext db, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _db = db;
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            var allPets = Pet.GetPets();
            return View(allPets);
        }

        public ActionResult Details(int id)
        {
            System.Console.WriteLine(">>>>>>>>>>>> GOT TO: MVC PETS CONTROLLER DETAILS METHOD <<<<<<<<<<<<<<<<<<<");
            var pet = Pet.GetPet(id);
            var photo = Pet.GetPhoto(pet, 1);
            ViewBag.Photo = pet.TestPhoto;
            ViewBag.ArrayLength = pet.TestPhoto.Length;
            return View(pet);
        }

        public ActionResult Edit(int id)
        {
            var pet = Pet.GetPet(id);
            return View(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Pet pet)
        {
            await Pet.EditPet(pet);
            return RedirectToAction("Details", new { id = pet.PetId });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pet pet)
        {
            await Pet.CreatePet(pet);
            //create pet's subdirectory for photos
            var photoDirectory = Path.Combine(hostingEnvironment.WebRootPath, "uploads", $"{pet.Name.ToLower()}{pet.PetId}");
            Directory.CreateDirectory(photoDirectory);
            return RedirectToAction("Details", new { id = pet.PetId });
        }
    }
}