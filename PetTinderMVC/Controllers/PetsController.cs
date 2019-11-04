using Microsoft.AspNetCore.Mvc;
using PetTinderMVC.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PetTinderMVC.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private readonly PetTinderMVCContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PetsController(UserManager<ApplicationUser> userManager, PetTinderMVCContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var allPets = Pet.GetPets();
            return View(allPets);
        }

        public ActionResult Details(int id)
        {
            var pet = Pet.GetPet(id);
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
            return RedirectToAction("Details", new { id = pet.PetId });
        }
    }
}