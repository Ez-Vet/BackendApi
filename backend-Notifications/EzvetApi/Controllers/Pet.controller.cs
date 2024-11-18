using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EzvetApi.Models;

namespace EzvetApi.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private static List<Pet> _pets = new List<Pet>
        {
            new Pet { Id = 1, Name = "Luna", Species = "Perro", Age = 3, Gender = "Hembra", Description = "Pastor alemán muy juguetona y leal" },
            new Pet { Id = 2, Name = "Simba", Species = "Gato", Age = 5, Gender = "Macho", Description = "Gato siamés, independiente pero cariñoso" },
            new Pet { Id = 3, Name = "Rex", Species = "Perro", Age = 2, Gender = "Macho", Description = "Labrador enérgico, adora los paseos largos" },
            new Pet { Id = 4, Name = "Nala", Species = "Gato", Age = 4, Gender = "Hembra", Description = "Gata persa, tranquila y hogareña" },
            new Pet { Id = 5, Name = "Milo", Species = "Conejo", Age = 1, Gender = "Macho", Description = "Conejo enano, sociable y curioso" }
        };

        // GET: api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetAllPets() => Ok(_pets);

        // GET: api/pets/{id}
        [HttpGet("{id}")]
        public ActionResult<Pet> GetPetById(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            return pet == null ? NotFound() : Ok(pet);
        }

        // POST: api/pets
        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody] Pet newPet)
        {
            newPet.Id = _pets.Count > 0 ? _pets.Max(p => p.Id) + 1 : 1;
            _pets.Add(newPet);
            return CreatedAtAction(nameof(GetPetById), new { id = newPet.Id }, newPet);
        }

        // PUT: api/pets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePet(int id, [FromBody] Pet updatedPet)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null) return NotFound();

            pet.Name = updatedPet.Name;
            pet.Species = updatedPet.Species;
            pet.Age = updatedPet.Age;
            pet.Gender = updatedPet.Gender;
            pet.Description = updatedPet.Description;
            return NoContent();
        }

        // DELETE: api/pets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null) return NotFound();

            _pets.Remove(pet);
            return NoContent();
        }  
    }
}