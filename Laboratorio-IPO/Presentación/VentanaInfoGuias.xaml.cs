using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;
using Laboratorio_IPO.Dominio;
using Laboratorio_IPO.Presentación;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaInfoGuias.xaml
    /// </summary>
    public partial class VentanaInfoGuias : Page
    {
        private VentanaPrincipal ventanaPadre;
        public VentanaInfoGuias(VentanaPrincipal ventana)
        {
            ventanaPadre = ventana;
            InitializeComponent();
            lstExcursionistas.Items.Clear();
            foreach (Guia aux in Guia.todosGuias)
            {
                lstExcursionistas.Items.Add(aux.Nombre);
            }
        }

        private void lstExcursionistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstExcursionistas.SelectedItem != null)
            {
                txtNombre.IsEnabled = false;
                txtApellido.IsEnabled = false;
                txtCorreo.IsEnabled = false;
                txtRating.IsEnabled = false;
                txtTelefono.IsEnabled = false;
                lstProximas.Items.Clear();
                lstRealizadas.Items.Clear();
                Guia seleccionado = null;
                foreach (Guia aux in Guia.todosGuias)
                {
                    if (lstExcursionistas.SelectedItem.Equals(aux.Nombre))
                    {
                        seleccionado = aux;
                    }
                }
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellidos;
                txtCorreo.Text = seleccionado.Correo;
                txtTelefono.Text = seleccionado.Telefono.ToString();
                txtRating.Text = seleccionado.PuntuacionMedia.ToString();
                txtDisponibilidad.Items.Clear();
                btnEliminar.IsEnabled = true;
                foreach (String aux in seleccionado.Disponibilidad.Split(','))
                {
                    txtDisponibilidad.Items.Add(aux.Trim());
                }
                txtDisponibilidad.SelectedIndex = 0;
                txtIdiomas.Items.Clear();
                foreach (String aux in seleccionado.Idiomas.Split(','))
                {
                    txtIdiomas.Items.Add(aux.Trim());
                }
                txtIdiomas.SelectedIndex = 1;
                var converter = new ImageSourceConverter();
                imgExcursionista.Source = (ImageSource)converter.ConvertFromString(seleccionado.Foto);
                /*for (int i = 0; i == seleccionado.ExcursionesRealizadas; i++) {
					bool control=false;
					int x = 0;
					while (control) {
						if (Ruta.todosRutas[x].Guia.Nombre.Equals(lstExcursionistas.SelectedItem))
						{
							lstRealizadas.Items.Add(Ruta.todosRutas[x].Nombre);
						}
						else {
							x++;
						}
					}
				}//se haria asi para cargar las excursiones realizadas pero es mejor de la siguiente forma*/
                foreach (Ruta aux in Ruta.todosRutas)
                {
                    if (aux.Guia.Nombre.Equals(lstExcursionistas.SelectedItem))
                    {
                        lstRealizadas.Items.Add(aux.Nombre);
                    }
                }
                var random = new Random(Environment.TickCount);
                int[] noRepetir = new int[seleccionado.ExcursionesPorRealizar];
                for (int i = 0; i < seleccionado.ExcursionesPorRealizar; i++)
                {
                    int y = random.Next(0, Ruta.todosRutas.Count);
                    bool control = false;
                    do
                    {
                        control = false;
                        foreach (int n in noRepetir)
                        {
                            if (n == y)
                            {
                                control = true;
                                y = random.Next(0, Ruta.todosRutas.Count);
                            }
                        }
                    } while (control);
                    lstProximas.Items.Add(Ruta.todosRutas[y].Nombre);
                    noRepetir[i] = y;
                }
                /*foreach (Ruta aux in Ruta.rutasProximas)
				{
					if (aux.Guia.Nombre.Equals(lstExcursionistas.SelectedItem))
					{
						lstProximas.Items.Add(aux.Nombre);
					}
				}// Se haria de esta forma pero no hay excursiones proximas en persistencia*/
            }
        }

        private void lstRealizadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstRealizadas.SelectedItem != null)
            {
                ventanaPadre.seleccionRutaEspecifica(lstRealizadas.SelectedItem.ToString(), 1);
            }
            lstRealizadas.UnselectAll();
        }

        private void lstProximas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstProximas.SelectedItem != null)
            {
                ventanaPadre.seleccionRutaEspecifica(lstProximas.SelectedItem.ToString(), 0);
            }
            lstProximas.UnselectAll();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtDisponibilidad.Items.Clear();
            txtIdiomas.Items.Clear();
            txtRating.Clear();
            txtTelefono.Clear();
            lstRealizadas.Items.Clear();
            lstProximas.Items.Clear();
            lstExcursionistas.UnselectAll();
            imgExcursionista.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Imagenes\usuarioFoto.png");
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtCorreo.IsEnabled = true;
            txtRating.IsEnabled = true;
            txtTelefono.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstExcursionistas.SelectedItem != null)
            {
                Guia eliminado = null;
                bool eliminar = false;
                foreach (Guia aux in Guia.todosGuias)
                {
                    if (lstExcursionistas.SelectedItem.Equals(aux.Nombre))
                    {
                        eliminado = aux;
                        eliminar = true;
                    }
                }
                if (eliminar)
                {
                    lstExcursionistas.UnselectAll();
                    Guia.todosGuias.Remove(eliminado);
                    lstExcursionistas.Items.Remove(eliminado.Nombre);
                    btnLimpiar_Click(sender, e);
                }
            }
            btnEliminar.IsEnabled = false;
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            bool existente = true;
            foreach (Guia aux in Guia.todosGuias)
            {
                if (txtNombre.Text.Equals(aux.Nombre))
                {
                    existente = false;
                }
            }
            if (lstExcursionistas.SelectedItem == null)
            {
                if (txtNombre.Text != "" && txtApellido.Text != "" && txtCorreo.Text != "" && txtRating.Text != "" && txtTelefono.Text != "" && existente)
                {
                    string disponibilidad = Microsoft.VisualBasic.Interaction.InputBox("Inserte los dias disponibles separados por ', '", "Disponibilidad", "Lunes, Martes, Miercoles");
                    string idiomas = Microsoft.VisualBasic.Interaction.InputBox("Inserte los idiomas hablados separados por ', '", "Idiomas", "Español, Ruso, Aleman");
                    Guia nuevoguia = new Guia(txtNombre.Text, txtApellido.Text, @"..\..\Imagenes\usuarioFoto.png", idiomas, disponibilidad, long.Parse(txtTelefono.Text), txtCorreo.Text, 0, 0, double.Parse(txtRating.Text));
                    Guia.todosGuias.Add(nuevoguia);
                    lstExcursionistas.Items.Add(nuevoguia.Nombre);
                }
                else
                {
                    MessageBox.Show("El nombre ya existe o falta por rellenar algun campo", "Error al añadir");
                }
            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtNombre.BorderBrush = Brushes.Green;
                txtNombre.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtNombre.BorderBrush = Brushes.Red;
                txtNombre.Background = Brushes.LightCoral;
            }
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
            {
                e.Handled = false;
                txtApellido.BorderBrush = Brushes.Green;
                txtApellido.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtApellido.BorderBrush = Brushes.Red;
                txtApellido.Background = Brushes.LightCoral;
            }
        }

        private void txtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13 || ascci == 64 || ascci == 46)
            {
                e.Handled = false;
                txtCorreo.BorderBrush = Brushes.Green;
                txtCorreo.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtCorreo.BorderBrush = Brushes.Red;
                txtCorreo.Background = Brushes.LightCoral;
            }
        }

        private void txtRating_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 53 || ascci == 13)
            {
                e.Handled = false;
                txtRating.BorderBrush = Brushes.Green;
                txtRating.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtRating.BorderBrush = Brushes.Red;
                txtRating.Background = Brushes.LightCoral;
            }
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ComprobarFormatoEmail(txtCorreo.Text) == true)
            {
                e.Handled = false;
                txtCorreo.BorderBrush = Brushes.Green;
                txtCorreo.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtCorreo.BorderBrush = Brushes.Red;
                txtCorreo.Background = Brushes.LightCoral;
                MessageBox.Show("Formato invadilo, use un formato de correo electronico valido como nombre@gmail.com", "Error de formato");
            }
        }
        public void seleccionGuiaEspecifico(string guiaselect)
        {
            lstExcursionistas.SelectedItem = guiaselect;
        }
    }
}
