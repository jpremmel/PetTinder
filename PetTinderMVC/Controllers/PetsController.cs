using Microsoft.AspNetCore.Mvc;
using PetTinderMVC.Models;
using System.Threading.Tasks;

namespace PetTinderMVC.Controllers
{
    public class PetsController : Controller
    {
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
    }
}