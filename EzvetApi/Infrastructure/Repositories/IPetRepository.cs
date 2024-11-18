using System.Collections.Generic;
using EzvetApi.Domain.Model;

namespace EzvetApi.Infrastructure.Repositories
{
    public interface IPetRepository
    {
        // Método para obtener todos los pets
        IEnumerable<Pet> GetAll();

        // Método para obtener un pet por ID
        Pet GetById(int id);

        // Método para crear un nuevo pet
        void Add(Pet pet);

        // Método para actualizar un pet existente
        void Update(Pet pet);

        // Método para eliminar un pet por ID
        void Delete(int id);
    }
}