using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Linq;
using EzvetApi.Models;


namespace EzvetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private static List<Notification> _notifications = new List<Notification>
        {
        };
        
        // GET: api/notifications
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetAllNotifications()
        {
            return Ok(_notifications);
        }

        // GET: api/notifications/{id}
        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var notification = _notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        // POST: api/notifications
        [HttpPost]
        public ActionResult<Notification> CreateNotification([FromBody] Notification newNotification)
        {
            newNotification.Id = _notifications.Count > 0 ? _notifications.Max(n => n.Id) + 1 : 1;
            _notifications.Add(newNotification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = newNotification.Id }, newNotification);
        }

        // PUT: api/notifications/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNotification(int id, [FromBody] Notification updatedNotification)
        {
            var notification = _notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            notification.Description = updatedNotification.Description;
            notification.Date = updatedNotification.Date;
            notification.Time = updatedNotification.Time;
            return NoContent();
        }

        // DELETE: api/notifications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            var notification = _notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            _notifications.Remove(notification);
            return NoContent();
        }
    }

}