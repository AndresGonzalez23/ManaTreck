using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Security.Cryptography.X509Certificates;

namespace Laboratorio_IPO.Dominio
{
	internal class Excursionista
	{
		public static List<Excursionista> todosExcursionistas=new List<Excursionista>();
		private string _nombre;
		private string _apellidos;
		private string _foto;
		private string _correo;
		private int _edad;
		private long _telefono;
		private Ruta[] _rutas;
		public Excursionista(string nombre, string apellidos, string foto, int edad, long telefono, Ruta[] rutas, string correo)
		{
			Nombre = nombre;
			Apellidos = apellidos;
			Foto = foto;
			Edad = edad;
			Telefono = telefono;
			Rutas = rutas;
			Correo = correo;
		}

		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Apellidos { get => _apellidos; set => _apellidos = value; }
		public string Foto { get => _foto; set => _foto = value; }
		public int Edad { get => _edad; set => _edad = value; }
		public long Telefono { get => _telefono; set => _telefono = value; }
		internal Ruta[] Rutas { get => _rutas; set => _rutas = value; }
		public string Correo { get => _correo; set => _correo = value; }
	}
}
