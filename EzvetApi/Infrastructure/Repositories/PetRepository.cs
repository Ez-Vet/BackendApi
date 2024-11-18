using System.Collections.Generic;
using System.Linq;
using EzvetApi.Domain.Model;

namespace EzvetApi.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly List<Pet> _pets;

        public PetRepository()
        {
            // Datos de ejemplo en memoria
            _pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Luna", Species = "Perro", Age = 3, Gender = "Hembra", Description = "Pastor alemán muy juguetona y leal" },
                new Pet { Id = 2, Name = "Simba", Species = "Gato", Age = 5, Gender = "Macho", Description = "Gato siamés, independiente pero cariñoso" }
            };
        }

        public IEnumerable<Pet> GetAll() => _pets;

        public Pet GetById(int id) => _pets.FirstOrDefault(p => p.Id == id);

        public void Add(Pet pet)
        {
            pet.Id = _pets.Any() ? _pets.Max(p => p.Id) + 1 : 1;
            _pets.Add(pet);
        }

        public void Update(Pet pet)
        {
            var existingPet = _pets.FirstOrDefault(p => p.Id == pet.Id);
            if (existingPet == null) return;

            existingPet.Name = pet.Name;
            existingPet.Species = pet.Species;
            existingPet.Age = pet.Age;
            existingPet.Gender = pet.Gender;
            existingPet.Description = pet.Description;
        }

        public void Delete(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                _pets.Remove(pet);
            }
        }
    }
}