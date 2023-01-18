using Laboratorio_IPO.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
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

        private void txtProvincia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 ||ascci==13)
            {
                e.Handled = false;
                txtProvincia.BorderBrush = Brushes.Green;
                txtProvincia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtProvincia.BorderBrush = Brushes.Red;
                txtProvincia.Background = Brushes.LightCoral;
            }
                
        }

        private void txtOrigen_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtOrigen.BorderBrush = Brushes.Green;
                txtOrigen.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtOrigen.BorderBrush = Brushes.Red;
                txtOrigen.Background = Brushes.LightCoral;
            }
        }

        private void txtDestino_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtDestino.BorderBrush = Brushes.Green;
                txtDestino.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtDestino.BorderBrush = Brushes.Red;
                txtDestino.Background = Brushes.LightCoral;
            }
        }

        private void txtComida_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtComida.BorderBrush = Brushes.Green;
                txtComida.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtComida.BorderBrush = Brushes.Red;
                txtComida.Background = Brushes.LightCoral;
            }
        }

        private void txtMaterial_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtMaterial.BorderBrush = Brushes.Green;
                txtMaterial.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtMaterial.BorderBrush = Brushes.Red;
                txtMaterial.Background = Brushes.LightCoral;
            }
        }
        private void txtVuelta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtGuia.BorderBrush = Brushes.Green;
                txtGuia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtGuia.BorderBrush = Brushes.Red;
                txtGuia.Background = Brushes.LightCoral;
            }
        }
        private void txtGuia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtGuia.BorderBrush = Brushes.Green;
                txtGuia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtGuia.BorderBrush = Brushes.Red;
                txtGuia.Background = Brushes.LightCoral;
            }
        }

        private void txtNivelDificultad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 53 || ascci == 13)
            {
                e.Handled = false;
                txtNivelDificultad.BorderBrush = Brushes.Green;
                txtNivelDificultad.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtNivelDificultad.BorderBrush = Brushes.Red;
                txtNivelDificultad.Background = Brushes.LightCoral;
            }
        }
        private void txtVueltaR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtGuia.BorderBrush = Brushes.Green;
                txtGuia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtGuia.BorderBrush = Brushes.Red;
                txtGuia.Background = Brushes.LightCoral;
            }
        }
        private void txtTiempo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57 || ascci == 13 || ascci == 58)
            {
                e.Handled = false;
                txtTiempo.BorderBrush = Brushes.Green;
                txtTiempo.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtTiempo.BorderBrush = Brushes.Red;
                txtTiempo.Background = Brushes.LightCoral;
            }
        }
        private void txtAcceso_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtGuia.BorderBrush = Brushes.Green;
                txtGuia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtGuia.BorderBrush = Brushes.Red;
                txtGuia.Background = Brushes.LightCoral;
            }
        }
        private void txtAccesoR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtGuia.BorderBrush = Brushes.Green;
                txtGuia.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtGuia.BorderBrush = Brushes.Red;
                txtGuia.Background = Brushes.LightCoral;
            }
        }
        private void txtTiempo_LostFocus(object sender, RoutedEventArgs e) {
            if(comprobarFormatoHora(txtTiempo.Text) == true)
            {
                e.Handled = false;
                txtTiempo.BorderBrush = Brushes.Green;
                txtTiempo.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtTiempo.BorderBrush = Brushes.Red;
                txtTiempo.Background = Brushes.LightCoral;
                MessageBox.Show("Formato invadilo, use un formato de correo electronico valido como nombre@gmail.com", "Error de formato");
            }
        }

        public static bool comprobarFormatoHora(string horaComprobada)
        {
            Boolean prueba = true;
            string[] valoresPosibles = {"00:15:00", "00:20:00", "00:30:00", "00:45:00",
                                        "01:00:00", "02:00:00", "03:00:00", "04:00:00", "05:00:00", "06:00:00", "07:00:00",
                                        "01:15:00", "02:15:00", "03:15:00", "04:15:00", "05:15:00", "06:15:00", "07:15:00",
                                        "01:20:00", "02:20:00", "03:20:00", "04:20:00", "05:20:00", "06:20:00", "07:20:00",
                                        "01:30:00", "02:30:00", "03:30:00", "04:30:00", "05:30:00", "06:30:00", "07:30:00",
                                        "01:45:00", "02:45:00", "03:45:00", "04:45:00", "05:45:00", "06:45:00", "07:45:00"};

            foreach (string elemento in valoresPosibles)
            {
                if(horaComprobada != elemento)
                {
                    prueba = true;
                }
                else
                {
                    prueba =false;
                }
            }
            return prueba;
        }

        private void btnPDIR_Click(object sender, RoutedEventArgs e)
        {
            VentanaPDI ventanaPDI = new VentanaPDI();
            ventanaPDI.Visibility = Visibility.Visible;
        }

        private void btnPDI_Click(object sender, RoutedEventArgs e)
        {
            VentanaPDI ventanaPDI = new VentanaPDI();
            ventanaPDI.Visibility = Visibility.Visible;
        }
    }
}
