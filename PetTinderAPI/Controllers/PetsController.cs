using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetTinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace PetTinderAPI.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private PetTinderAPIContext _db;
        private readonly IHostingEnvironment hostingEnvironment;

        public PetsController(PetTinderAPIContext db, IHostingEnvironment environment)
        {
            _db = db;
            hostingEnvironment = environment;
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _db.Pets.Add(pet);
            //create pet's subdirectory for photos
            var photoDirectory = Path.Combine(hostingEnvironment.WebRootPath, "uploads", $"{pet.Name.ToLower()}{pet.PetId}");
            Directory.CreateDirectory(photoDirectory);
            _db.SaveChanges();
        }

        // GET api/pets/{id}
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _db.Pets.FirstOrDefault(entry => entry.PetId == id);
        }

        // PUT api/pets/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            pet.PetId = id;
            _db.Entry(pet).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // PATCH api/pets/{id}
        [HttpPatch("{id}")]
        public void UpdateAge(int id, [FromBody] int age)
        {
            Pet pet = _db.Pets.FirstOrDefault(p => p.PetId == id);
            pet.Age = age;
            _db.Entry(pet).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/pets/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var petToDelete = _db.Pets.FirstOrDefault(entry => entry.PetId == id);
            _db.Pets.Remove(petToDelete);
            _db.SaveChanges();
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get(string species, string gender, string name, string breed, string bio)
        {
            var query = _db.Pets.AsQueryable();

            if(species != null)
            {
                query = query.Where(entry => entry.Species.ToLower().Contains(species.ToLower()));
            }
            if(gender != null)
            {
                query = query.Where(entry => entry.Gender.ToLower().Contains(gender.ToLower()));
            }
            if(name != null)
            {
                query = query.Where(entry => entry.Name.ToLower().Contains(name.ToLower()));
            }
            if(breed != null)
            {
                query = query.Where(entry => entry.Breed.ToLower().Contains(breed.ToLower()));
            }
            if(bio != null)
            {
                query = query.Where(entry => entry.Bio.ToLower().Contains(bio.ToLower()));
            }
            
            return query.ToList();
        }

        [HttpGet("{id}/photo")]
        public IActionResult GetPhoto(int id)
        {
            Pet pet = _db.Pets.FirstOrDefault(entry => entry.PetId == id);
            string path = $"wwwroot/uploads/{pet.Name.ToLower()}{pet.PetId}/{pet.Name.ToLower()}_{pet.PetId}_1.jpg";
            FileStream stream = System.IO.File.Open(@path, System.IO.FileMode.Open);
            return File(stream, "image/jpg");
        }

        [HttpPost("{id}/upload")]
        public async Task Upload([FromForm] IFormFile file, int id)
        {
            System.Console.WriteLine(">>>>>>   UPLOAD TRIGGERED   <<<<<<");
            Pet pet = _db.Pets.FirstOrDefault(entry => entry.PetId == id);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads", $"{pet.Name.ToLower()}{pet.PetId}");
            System.Console.WriteLine(">>>>>>    PATH: " + uploads);
            if(file.Length > 0)
            {
                using(var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
    }
}