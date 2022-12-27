using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;

namespace Laboratorio_IPO.Dominio
{
	internal class Guia
	{
		public static Guia[] todosGuias;
		private string _nombre;
		private string _apellidos;
		private string _foto;
		private string _idiomas;
		private string _disponibilidad;
		private long _telefono;
		private string _correo;
		private int _excursionesRealizadas;
		private int _excursionesPorRealizar;
		private double _puntuacionMedia;
		public Guia(string nombre, string apellidos, string foto, string idiomas, string disponibilidad, long telefono, string correo, int realizadas, int porRealizar, double puntuacionMedia)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			Foto = foto;
			Idiomas = idiomas;
			Disponibilidad = disponibilidad;
			Telefono = telefono;
			Correo = correo;
			ExcursionesRealizadas = realizadas;
			ExcursionesPorRealizar = porRealizar;
			PuntuacionMedia = puntuacionMedia;
		}
		public Guia(string nombre, string apellidos, string idiomas, string disponibilidad, long telefono, string correo, int realizadas, int porRealizar, double puntuacionMedia)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			Foto = "/"+nombre;
			Idiomas = idiomas;
			Disponibilidad = disponibilidad;
			Telefono = telefono;
			Correo = correo;
			ExcursionesRealizadas = realizadas;
			ExcursionesPorRealizar = porRealizar;
			PuntuacionMedia = puntuacionMedia;
		}
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Apellidos { get => _apellidos; set => _apellidos = value; }
		public string Foto { get => _foto; set => _foto = value; }
		public string Idiomas { get => _idiomas; set => _idiomas = value; }
		public string Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }
		public long Telefono { get => _telefono; set => _telefono = value; }
		public string Correo { get => _correo; set => _correo = value; }
		public int ExcursionesRealizadas { get => _excursionesRealizadas; set => _excursionesRealizadas = value; }
		public int ExcursionesPorRealizar { get => _excursionesPorRealizar; set => _excursionesPorRealizar = value; }
		public double PuntuacionMedia { get => _puntuacionMedia; set => _puntuacionMedia = value; }
	}
}
