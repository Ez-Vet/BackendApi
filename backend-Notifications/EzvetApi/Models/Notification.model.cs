
using System;

namespace EzvetApi.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Type { get; set; } // Tipo: "Cita Pendiente" o "Vacuna Pendiente"
        public string PetName { get; set; } // Nombre de la mascota (si aplica)
    }
}
