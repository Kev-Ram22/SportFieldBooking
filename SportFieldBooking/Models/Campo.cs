using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Campo
	{
		[Key]
		public int IdCampo { get; set; }
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		public string Ubicación { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal TarifaHora { get; set; }

		public ICollection<Reserva> Reservas { get; set; }
		public ICollection<Evento> Eventos { get; set; }
	}
}
