using System.Collections.Generic;
using EzvetApi.Domain.Model;

namespace EzvetApi.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        // Método para obtener todos los items
        IEnumerable<Item> GetAll();

        // Método para obtener un item por ID
        Item GetById(int id);

        // Método para crear un nuevo item
        void Add(Item item);

        // Método para actualizar un item existente
        void Update(Item item);

        // Método para eliminar un item por ID
        void Delete(int id);
    }
}
