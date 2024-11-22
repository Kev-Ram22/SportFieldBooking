using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
	public class Reserva
	{
		[Key]
		public int IdReserva { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHoraInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHoraFin { get; set; }
		public string Estado { get; set; } // Reservado, Cancelado, Completado

        public int IdCampo { get; set; } // FK
        public Campo Campo { get; set; }
        public int IdCliente { get; set; } // FK
        public Cliente Cliente { get; set; }

        public ICollection<Pago> Pagos { get; set; }
    }
}
