using System.Linq;
using EzvetApi.Domain.Model;

namespace EzvetApi.Application.Internal.CommandServices
{
    public class PetCommandService : IPetCommandService
    {
        private readonly List<Pet> _pets;

        public PetCommandService(List<Pet> pets)
        {
            _pets = pets;
        }

        public Pet CreatePet(Pet newPet)
        {
            newPet.Id = _pets.Any() ? _pets.Max(p => p.Id) + 1 : 1;
            _pets.Add(newPet);
            return newPet;
        }

        public bool UpdatePet(int id, Pet updatedPet)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null) return false;

            pet.Name = updatedPet.Name;
            pet.Species = updatedPet.Species;
            pet.Age = updatedPet.Age;
            pet.Gender = updatedPet.Gender;
            pet.Description = updatedPet.Description;

            return true;
        }

        public bool DeletePet(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet == null) return false;

            _pets.Remove(pet);
            return true;
        }
    }
}