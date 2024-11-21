using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Cliente
	{
		[Key]
		public int IdCliente { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Teléfono { get; set; }
		public string Email { get; set; }

		// Relación: Un Cliente puede tener muchas Reservas
		public ICollection<Reserva> Reservas { get; set; }
	}
}
