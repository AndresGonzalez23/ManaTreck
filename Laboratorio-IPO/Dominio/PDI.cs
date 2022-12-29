using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_IPO.Dominio
{
	internal class PDI
	{
		public static List<PDI> todosPDIs=new List<PDI>();
		private string _nombre;
		private string _foto;
		private string _descripcion;
		private string _tipologia;
		public PDI(string nombre, string foto, string descripcion, string tipologia) {
			Nombre = nombre;
			Foto = foto;
			Descripcion= descripcion;
			Tipologia= tipologia;
		}
		public PDI(string nombre, string foto)
		{
			Nombre = nombre;
			Foto = foto;
			Descripcion = "";
			Tipologia = "";
		}
		public void actualizar(string foto, string descripcion, string tipologia)
		{
			Foto = foto;
			Descripcion = descripcion;
			Tipologia = tipologia;
		}

		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Foto { get => _foto; set => _foto = value; }
		public string Descripcion { get => _descripcion; set => _descripcion = value; }
		public string Tipologia { get => _tipologia; set => _tipologia = value; }
	}
}
