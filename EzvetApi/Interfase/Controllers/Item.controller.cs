using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EzvetApi.Domain.Model;
using EzvetApi.Application.Internal.OutBoundServices;

namespace EzvetApi.Presentation.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/inventory
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAllItems()
        {
            var items = _itemRepository.GetAll();
            return Ok(items);
        }

        // GET: api/inventory/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = _itemRepository.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        // POST: api/inventories
        [HttpPost]
        public ActionResult<Item> CreateItem([FromBody] Item newItem)
        {
            _itemRepository.Add(newItem);
            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var existingItem = _itemRepository.GetById(id);
            if (existingItem == null) return NotFound();

            updatedItem.Id = id;
            _itemRepository.Update(updatedItem);
            return NoContent();
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var existingItem = _itemRepository.GetById(id);
            if (existingItem == null) return NotFound();

            _itemRepository.Delete(id);
            return NoContent();
        }
    }
}