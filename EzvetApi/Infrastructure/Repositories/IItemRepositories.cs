using System.Collections.Generic;
using EzvetApi.Domain.Model;

namespace EzvetApi.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        // Método para obtener todos los Item
        IEnumerable<Item> GetAll();

        // Método para obtener un Item por ID
        Item GetById(int id);

        // Método para crear un nuevo Item
        void Add(Item item);

        // Método para actualizar un Item existente
        void Update(Item item);

        // Método para eliminar un Item por ID
        void Delete(int id);
    }
}