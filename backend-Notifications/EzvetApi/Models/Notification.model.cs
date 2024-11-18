
using System;

namespace EzvetApi.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Type { get; set; } 
        public string PetName { get; set; } 
    }
}
