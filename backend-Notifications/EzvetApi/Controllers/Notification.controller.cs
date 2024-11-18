
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
        private static List<Notification> notifications = new List<Notification>();

        // Obtener todas las notificaciones
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetNotifications()
        {
            return Ok(notifications);
        }

        // Agregar una nueva notificación
        [HttpPost]
        public ActionResult AddNotification(Notification newNotification)
        {
            newNotification.Id = notifications.Count + 1;
            notifications.Add(newNotification);
            return Ok(newNotification);
        }

        // Obtener una notificación específica
        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotification(int id)
        {
            var notification = notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }
    }
}
