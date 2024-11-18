using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EzvetApi.Models;

namespace EzvetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private static List<Appointment> appointments = new List<Appointment>
        {
            
        };

        // GET: api/appointments
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            return Ok(appointments);
        }

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = appointments.Find(a => a.Id == id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        // POST: api/appointments
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, Appointment updatedAppointment)
        {
            var appointment = appointments.Find(a => a.Id == id);
            if (appointment == null) return NotFound();

            appointment.Pet = updatedAppointment.Pet;
            appointment.Date = updatedAppointment.Date;
            appointment.Time = updatedAppointment.Time;
            appointment.Status = updatedAppointment.Status;
            appointment.History = updatedAppointment.History;

            return NoContent();
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = appointments.Find(a => a.Id == id);
            if (appointment == null) return NotFound();

            appointments.Remove(appointment);
            return NoContent();
        }
    }

}