using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Campo
	{
		[Key]
		public int IdCampo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public string Ubicación { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "La tarifa por hora es obligatoria.")]
        [Range(0, double.MaxValue, ErrorMessage = "La tarifa debe ser un valor positivo.")]
        public decimal TarifaHora { get; set; }

		public ICollection<Reserva> Reservas { get; set; }
		public ICollection<Evento> Eventos { get; set; }
	}
}
