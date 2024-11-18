using System.Collections.Generic;
using System.Linq;
using EzvetApi.Domain.Model;

namespace EzvetApi.Application.Internal.QueryServices
{
    public class PetQueryService : IPetQueryService
    {
        private readonly List<Pet> _pets;

        public PetQueryService()
        {
            _pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Luna", Species = "Perro", Age = 3, Gender = "Hembra", Description = "Pastor alemán muy juguetona y leal" },
                new Pet { Id = 2, Name = "Simba", Species = "Gato", Age = 5, Gender = "Macho", Description = "Gato siamés, independiente pero cariñoso" }
            };
        }

        public IEnumerable<Pet> GetAllPets() => _pets;

        public Pet GetPetById(int id) => _pets.FirstOrDefault(p => p.Id == id);
    }
}