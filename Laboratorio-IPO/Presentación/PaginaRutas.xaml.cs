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
using Laboratorio_IPO.Dominio;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para PaginaRutas.xaml
    /// </summary>
    public partial class PaginaRutas : Page
    {
        public  Page[] paginasRutas = new Page[Ruta.todosRutas.Count];
        private VentanaPrincipal ventanaPadre;
        public PaginaRutas(VentanaPrincipal ventana)
        {
            ventanaPadre = ventana;
            InitializeComponent();
			var converter = new ImageSourceConverter();
			img1.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[0].Foto);
			img2.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[1].Foto);
			img3.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[2].Foto);
			img4.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[3].Foto);
			img5.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[4].Foto);
			img6.Source = (ImageSource)converter.ConvertFromString(@Ruta.todosRutas[5].Foto);
			lbl1.Content = Ruta.todosRutas[0].Nombre;
			lbl2.Content = Ruta.todosRutas[1].Nombre;
			lbl3.Content = Ruta.todosRutas[2].Nombre;
			lbl4.Content = Ruta.todosRutas[3].Nombre;
			lbl5.Content = Ruta.todosRutas[4].Nombre;
			lbl6.Content = Ruta.todosRutas[5].Nombre;
            for (int i=0;i<Ruta.todosRutas.Count;i++) {
                paginasRutas[i] = new VentanaInformaciónRuta(Ruta.todosRutas[i].Nombre);
            }
		}

        private void btnRuta1_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[0];
        }

        private void btnRuta2_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[1];
        }

        private void btnRuta3_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[2];
        }

        private void btnRuta4_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[3];
        }

        private void btnRuta5_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[4];
        }

        private void btnRuta6_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadre.MainFrame.Content = paginasRutas[5];
        }
        public void seleccionRutaEspecifica(String ruta, int realizada){
            if(realizada == 0){
				for (int i = 0; i < Ruta.todosRutas.Count; i++)
				{
                    if (ruta.Equals(Ruta.todosRutas[i].Nombre)) {
						ventanaPadre.MainFrame.Content = paginasRutas[i];
					}
				}
			}
			else if(realizada == 1){
				for (int i = 0; i < Ruta.todosRutas.Count; i++)
				{
					if (ruta.Equals(Ruta.todosRutas[i].Nombre))
					{
						ventanaPadre.MainFrame.Content = paginasRutas[i];
					}
				}
			}
		}
    }
}
