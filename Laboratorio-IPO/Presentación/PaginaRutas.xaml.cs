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
    /// Lógica de interacción para PaginaRutas.xaml
    /// </summary>
    public partial class PaginaRutas : Page
    {
        public Page[] paginasRutas = new Page[] { new VentanaInformaciónRuta()};
        public PaginaRutas()
        {
            InitializeComponent();
        }

        private void btnRuta1_Click(object sender, RoutedEventArgs e)
        {
            FrameRutas.Content = paginasRutas[0];
        }

		//Hola probando
    }
}
