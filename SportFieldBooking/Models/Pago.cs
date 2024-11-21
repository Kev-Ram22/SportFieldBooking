using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportFieldBooking.Models
{
	public class Pago
	{
		[Key]
		public int IdPago { get; set; }
		public int IdReserva { get; set; } // FK
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Monto { get; set; }
		public DateTime FechaPago { get; set; }
		public string MétodoPago { get; set; } // Tarjeta, Efectivo

		// Relación
		public Reserva Reserva { get; set; }
	}
}
