using Laboratorio_IPO.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaInformaciónRuta.xaml
    /// </summary>
    public partial class VentanaInformaciónRuta : Page
    {
        public VentanaInformaciónRuta(string r)
        {
            InitializeComponent();
            Ruta ruta=null;
			foreach (Ruta aux in Ruta.todosRutas)
			{
				if (r.Equals(aux.Nombre))
				{
					ruta = aux;
				}
			}
            txtProvincia.Text = ruta.Provincia;
            txtOrigen.Text = ruta.Origen;
            txtDestino.Text = ruta.Destino;
            txtHora.Text=ruta.FechaYHora.Hour.ToString();
            txtNivelDificultad.Text=ruta.Dificultad.ToString();
            txtMaterial.Text = ruta.Material;
            txtTiempo.Text=ruta.Duracion.ToString();
            txtComida.Text=ruta.ComidaIncluida.ToString();
            txtGuia.Text = ruta.Guia.Nombre;
            txtFecha.Text=ruta.FechaYHora.Date.ToString();
			//txtFecha.SelectedDate = ruta.FechaYHora.Date;
			var converter = new ImageSourceConverter();
			imgRuta.Source = (ImageSource)converter.ConvertFromString(ruta.Mapa);
            foreach (Excursionista excur in Excursionista.todosExcursionistas) {
                foreach (Ruta x in excur.Rutas) { 
                    if(ruta.Nombre.Equals(x.Nombre)) {
                        lstExcursionistas.Items.Add(excur.Nombre);
                    }
                }
            }
		}
    }
}
