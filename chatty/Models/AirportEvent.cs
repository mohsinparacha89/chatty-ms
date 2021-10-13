using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace chatty.Models
{
    public class AirportEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public string AircraftType { get; set; }
        public bool IsInternational { get; set; }
    }
}
