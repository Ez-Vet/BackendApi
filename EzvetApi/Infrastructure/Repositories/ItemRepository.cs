using System.Collections.Generic;
using System.Linq;
using EzvetApi.Domain.Model;

namespace EzvetApi.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items;

        public ItemRepository()
        {
            // Datos de ejemplo en memoria
            _items = new List<Item>
            {
                new Item { Id = 1, Name = "Galletas Crispicat", Type = "Comida", Quantity = 3},
                new Item { Id = 2, Name = "Correa SiempreContigo", Type = "Correa", Quantity = 5}
            };
        }

        public IEnumerable<Item> GetAll() => _items;

        public Item GetById(int id) => _items.FirstOrDefault(p => p.Id == id);

        public void Add(Item item)
        {
            _items.Id = _items.Any() ? _items.Max(p => p.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Update(Item item)
        {
            var existingItem = _items.FirstOrDefault(p => p.Id == item.Id);
            if (existingItem == null) return;

            existingItem.Name = item.Name;
            existingItem.Type = item.Type;
            existingItem.Quantity = item.Quantity;
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}