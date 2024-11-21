using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Reserva
	{
		[Key]
		public int IdReserva { get; set; }
		public int IdCampo { get; set; } // FK
		public int IdCliente { get; set; } // FK
		public DateTime FechaHoraInicio { get; set; }
		public DateTime FechaHoraFin { get; set; }
		public string Estado { get; set; } // Reservado, Cancelado, Completado

		// Relaciones
		public Campo Campo { get; set; }
		public Cliente Cliente { get; set; }
	}
}
