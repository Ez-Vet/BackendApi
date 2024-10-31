using System;

namespace EzvetApi.Models
{

    public class Appointment
    {
        public int Id { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public bool Status { get; set; }
        public History History { get; set; }
    }
    public class History
    {
        public string Diagnosis { get; set; }
        public string ReasonConsultation { get; set; }
        public string Treatment { get; set; }
        public string Observations { get; set; }
    }
}