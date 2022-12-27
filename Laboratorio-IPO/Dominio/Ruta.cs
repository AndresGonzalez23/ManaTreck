using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_IPO.Dominio
{
	internal class Ruta
	{
		public static Ruta[] todosRutas;
		private string _nombre;
		private string _provincia;
		private string _origen;
		private string _destino;
		private TimeSpan _duracion;
		private DateTime _fechaYHora;
		private int _dificultad;
		private Guia _guia;
		private int _numExcursionistas;
		private string _formaAcceso;
		private string _formaVuelta;
		private string _material;
		private bool _comidaIncluida;
		private PDI[] _pdi;
		private string _foto;
		private string _mapa;
		public Ruta(string nombre, string provincia, string origen, string destino, TimeSpan duracion, DateTime fechaYHora, int dificultad, Guia guia, int numExcursionistas, string formaAcceso, string formaVuelta, string material, bool comidaIncluida, PDI[] pdi, string foto, string mapa) {
			Nombre = nombre;
			Provincia = provincia;
			Origen = origen;
			Destino = destino;
			Duracion = duracion;
			FechaYHora= fechaYHora;
			Dificultad= dificultad;
			Guia = guia;
			NumExcursionistas = numExcursionistas;
			FormaAcceso= formaAcceso;
			FormaVuelta= formaVuelta;
			Material= material;
			ComidaIncluida= comidaIncluida;
			Pdi = pdi;
			Foto = foto;
			Mapa = mapa;
		}
		public Ruta(string nombre, string provincia, string origen, string destino, TimeSpan duracion, DateTime fechaYHora, int dificultad, Guia guia, int numExcursionistas, string formaAcceso, string formaVuelta, string material, bool comidaIncluida, PDI[] pdi)
		{
			Nombre = nombre;
			Provincia = provincia;
			Origen = origen;
			Destino = destino;
			Duracion = duracion;
			FechaYHora = fechaYHora;
			Dificultad = dificultad;
			Guia = guia;
			NumExcursionistas = numExcursionistas;
			FormaAcceso = formaAcceso;
			FormaVuelta = formaVuelta;
			Material = material;
			ComidaIncluida = comidaIncluida;
			Pdi = pdi;
			Foto = "/"+nombre;
			Mapa = "/" + nombre+"_Mapa";
		}
		public Ruta(string nombre, string provincia, string origen, string destino, string duracion, string fechaYHora, int dificultad, Guia guia, int numExcursionistas, string formaAcceso, string formaVuelta, string material, bool comidaIncluida, PDI[] pdi, string foto, string mapa)
		{
			Nombre = nombre;
			Provincia = provincia;
			Origen = origen;
			Destino = destino;
			string[] partes =duracion.Split(':');
			Duracion = new TimeSpan(Int32.Parse(partes[0]), Int32.Parse(partes[1]), Int32.Parse(partes[2]));
			partes = fechaYHora.Split('/');
			partes[4] =partes[3].Split(':')[1];
			partes[3] = partes[3].Split(':')[0];
			FechaYHora = new DateTime(Int32.Parse(partes[2]), Int32.Parse(partes[1]), Int32.Parse(partes[0]), Int32.Parse(partes[3]), Int32.Parse(partes[4]), 0);
			Dificultad = dificultad;
			Guia = guia;
			NumExcursionistas = numExcursionistas;
			FormaAcceso = formaAcceso;
			FormaVuelta = formaVuelta;
			Material = material;
			ComidaIncluida = comidaIncluida;
			Pdi = pdi;
			Foto = foto;
			Mapa = mapa;
		}
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Provincia { get => _provincia; set => _provincia = value; }
		public string Origen { get => _origen; set => _origen = value; }
		public string Destino { get => _destino; set => _destino = value; }
		public TimeSpan Duracion { get => _duracion; set => _duracion = value; }
		public DateTime FechaYHora { get => _fechaYHora; set => _fechaYHora = value; }
		public int Dificultad { get => _dificultad; set => _dificultad = value; }
		public int NumExcursionistas { get => _numExcursionistas; set => _numExcursionistas = value; }
		public string FormaAcceso { get => _formaAcceso; set => _formaAcceso = value; }
		public string FormaVuelta { get => _formaVuelta; set => _formaVuelta = value; }
		public string Material { get => _material; set => _material = value; }
		public bool ComidaIncluida { get => _comidaIncluida; set => _comidaIncluida = value; }
		public string Foto { get => _foto; set => _foto = value; }
		internal Guia Guia { get => _guia; set => _guia = value; }
		internal PDI[] Pdi { get => _pdi; set => _pdi = value; }
		public string Mapa { get => _mapa; set => _mapa = value; }
	}
}
