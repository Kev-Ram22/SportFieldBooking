using SportFieldBooking.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportFieldBooking.Data
{
	public class SportFieldBookingContext : DbContext
	{
		public SportFieldBookingContext(DbContextOptions options) : base(options) { }
		public DbSet<Campo> Campos { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
		public DbSet<Evento> Eventos { get; set; }
		public DbSet<Pago> Pagos { get; set; }
	}
}
