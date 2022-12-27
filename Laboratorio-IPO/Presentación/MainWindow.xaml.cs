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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string usuario = "usuario";
        private string password = "usuario";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (ComprobarEntrada(txtUsuario.Text, usuario,
                                    txtUsuario))/*imgCheckUsuario*/
                {

                    //habilita el hueco de contraseña
                    txtContrasena.IsEnabled = true;
                    txtContrasena.Focus();

                    //bloquea el usuario para que no se pueda modificar
                    txtUsuario.IsEnabled = false;
                }
            }
        }

        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido,
                                         Control componenteEntrada)/*Image imagenFeedBack*/
        {
            Boolean valido = false;
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                //imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightCoral;
                // imagen al lado de la entrada de usuario --> cross
                //imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void txtContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(txtContrasena.Password, password,
                                    txtContrasena)) /*imgCheckContrasena*/
            {
                btnLogin.Focus();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario) /*imgCheckUsuario*/
                &&
                ComprobarEntrada(txtContrasena.Password, password,
                txtContrasena)) /*imgCheckContrasena*/
            {
                VentanaPrincipal ventana = new VentanaPrincipal();
                ventana.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }

        private void VentanaLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Quitar y cambiar

            MessageBox.Show("Gracias por usar nuestra aplicación...", "Adiós");
            App.Current.Shutdown();
        }
    }
}
