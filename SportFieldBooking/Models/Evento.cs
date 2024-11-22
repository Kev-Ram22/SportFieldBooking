using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Evento
	{
		[Key]
		public int IdEvento { get; set; }
		public string NombreEvento { get; set; }
		public DateTime FechaEvento { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFin { get; set; }
		public string Descripción { get; set; }

        // Relación
        public int IdCampo { get; set; } // FK
        public Campo Campo { get; set; }
	}
}
