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
using System.Windows.Shapes;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaPDI.xaml
    /// </summary>
    public partial class VentanaPDI : Window
    {
        Ruta selected;
        public VentanaPDI(String ruta)
        {
            InitializeComponent();
			foreach (Ruta aux in Ruta.todosRutas)
			{
				if (ruta.Equals(aux.Nombre))
				{
					selected = aux;
				}
			}
			var converter = new ImageSourceConverter();
			switch (selected.Pdi.Length) {
            case 0:
					MessageBox.Show("No se encuentra ningun PDI en esta ruta", "Error al buscar PDIs");
					break;
            case 1:
					txtNombre2.Text = selected.Pdi[0].Nombre;
					txtDescripcion2.Text = selected.Pdi[0].Descripcion;
                    txtTipologia2.Text = selected.Pdi[0].Tipologia;
					imgPDI2.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[0].Foto);
					break;
            case 2:
					txtNombre2.Text = selected.Pdi[0].Nombre;
					txtDescripcion2.Text = selected.Pdi[0].Descripcion;
					txtTipologia2.Text = selected.Pdi[0].Tipologia;
					imgPDI2.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[0].Foto);
					txtNombre1.Text = selected.Pdi[1].Nombre;
					txtDescripcion1.Text = selected.Pdi[1].Descripcion;
					txtTipologia1.Text = selected.Pdi[1].Tipologia;
					imgPDI1.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[1].Foto);
					break;
			case 3:
					txtNombre2.Text = selected.Pdi[0].Nombre;
					txtDescripcion2.Text = selected.Pdi[0].Descripcion;
					txtTipologia2.Text = selected.Pdi[0].Tipologia;
					imgPDI2.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[0].Foto);
					txtNombre1.Text = selected.Pdi[1].Nombre;
					txtDescripcion1.Text = selected.Pdi[1].Descripcion;
					txtTipologia1.Text = selected.Pdi[1].Tipologia;
					imgPDI1.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[1].Foto);
					txtNombre3.Text = selected.Pdi[2].Nombre;
					txtDescripcion3.Text = selected.Pdi[2].Descripcion;
					txtTipologia3.Text = selected.Pdi[2].Tipologia;
					imgPDI3.Source = (ImageSource)converter.ConvertFromString(selected.Pdi[2].Foto);
					break;
			default:
					MessageBox.Show("No se encuentra ningun PDI en esta ruta", "Error al buscar PDIs");
					break;
            }
		}
    }
}
