using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EzvetApi.Domain.Model;
using EzvetApi.Application.Internal.OutBoundServices;

namespace EzvetApi.Presentation.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        // GET: api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetAllPets()
        {
            var pets = _petRepository.GetAll();
            return Ok(pets);
        }

        // GET: api/pets/{id}
        [HttpGet("{id}")]
        public ActionResult<Pet> GetPetById(int id)
        {
            var pet = _petRepository.GetById(id);
            return pet == null ? NotFound() : Ok(pet);
        }

        // POST: api/pets
        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody] Pet newPet)
        {
            _petRepository.Add(newPet);
            return CreatedAtAction(nameof(GetPetById), new { id = newPet.Id }, newPet);
        }

        // PUT: api/pets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePet(int id, [FromBody] Pet updatedPet)
        {
            var existingPet = _petRepository.GetById(id);
            if (existingPet == null) return NotFound();

            updatedPet.Id = id;
            _petRepository.Update(updatedPet);
            return NoContent();
        }

        // DELETE: api/pets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            var existingPet = _petRepository.GetById(id);
            if (existingPet == null) return NotFound();

            _petRepository.Delete(id);
            return NoContent();
        }
    }
}