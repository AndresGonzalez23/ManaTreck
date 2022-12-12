using Laboratorio_IPO.Presentación;
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
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public Page[] paginas = new Page[] {new PaginaRutas()};
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Ventana_Principal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Gracias por usar nuestra aplicación...", "Adiós");
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCerrarMenu.Visibility = Visibility.Visible;
            btnMenu.Visibility = Visibility.Collapsed;
        }

        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCerrarMenu.Visibility = Visibility.Collapsed;
            btnMenu.Visibility= Visibility.Visible; 
        }

        private void btnRutas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paginas[0];
        }
    }
}
