using Laboratorio_IPO.Dominio;
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

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaInfoExcursionistas.xaml
    /// </summary>
    public partial class VentanaInfoExcursionistas : Page
    {
		private VentanaPrincipal ventanaPadre;
		public VentanaInfoExcursionistas(VentanaPrincipal ventana)
		{
			ventanaPadre = ventana;
			InitializeComponent();
			lstExcursionistas.Items.Clear();
			foreach (Excursionista aux in Excursionista.todosExcursionistas)
			{
					lstExcursionistas.Items.Add(aux.Nombre);
			}
		}
		public VentanaInfoExcursionistas()
        {
            InitializeComponent();
        }

		private void lstExcursionistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstExcursionistas.SelectedItem != null)
			{
				txtNombre.IsEnabled = false;
				txtApellido.IsEnabled = false;
				txtCorreo.IsEnabled = false;
				txtEdad.IsEnabled = false;
				txttelefono.IsEnabled = false;
				lstProximas.Items.Clear();
				lstRealizadas.Items.Clear();
				Excursionista seleccionado = null;
				foreach (Excursionista aux in Excursionista.todosExcursionistas)
				{
					if (lstExcursionistas.SelectedItem.Equals(aux.Nombre))
					{
						seleccionado = aux;
					}
				}
				txtNombre.Text = seleccionado.Nombre;
				txtApellido.Text = seleccionado.Apellidos;
				txtCorreo.Text = seleccionado.Correo;
				txttelefono.Text = seleccionado.Telefono.ToString();
				txtEdad.Text = seleccionado.Edad.ToString();
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
				foreach (Ruta aux in seleccionado.Rutas)
				{
					lstRealizadas.Items.Add(aux.Nombre);
				}
				var random = new Random(Environment.TickCount);
				int[] noRepetir = new int[random.Next(1, 5)];
				for (int i = 0; i < noRepetir.Length; i++)
				{
					int y = random.Next(0, Ruta.todosRutas.Count);
					bool control;
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
            txtEdad.Clear();
			txttelefono.Clear();
			txtCorreo.Clear();
            lstRealizadas.Items.Clear();
            lstProximas.Items.Clear();
			lstExcursionistas.UnselectAll();
            imgExcursionista.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Imagenes\usuarioFoto.png");
			txtNombre.IsEnabled = true;
			txtApellido.IsEnabled = true;
			txtCorreo.IsEnabled = true;
			txtEdad.IsEnabled = true;
			txttelefono.IsEnabled = true;
		}

		private void btnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (lstExcursionistas.SelectedItem != null)
			{
				Excursionista eliminado = null;
				bool eliminar = false;
				foreach (Excursionista aux in Excursionista.todosExcursionistas)
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
					Excursionista.todosExcursionistas.Remove(eliminado);
					lstExcursionistas.Items.Remove(eliminado.Nombre);
					btnLimpiar_Click(sender, e);
				}
			}
		}

		private void btnAñadir_Click(object sender, RoutedEventArgs e)
		{
			bool existente = true;
			foreach (Excursionista aux in Excursionista.todosExcursionistas)
			{
				if (txtNombre.Text.Equals(aux.Nombre))
				{
					existente = false;
				}
			}
			if (lstExcursionistas.SelectedItem == null)
			{
				if (txtNombre.Text != "" && txtApellido.Text != "" && txtCorreo.Text != "" && txtEdad.Text != "" && txttelefono.Text != "" && existente)
				{
					Excursionista nuevoexcur = new Excursionista(txtNombre.Text, txtApellido.Text, @"..\..\Imagenes\usuarioFoto.png", Convert.ToInt32(txtEdad.Text), long.Parse(txttelefono.Text), new Ruta[0], txtCorreo.Text);
					Excursionista.todosExcursionistas.Add(nuevoexcur);
					lstExcursionistas.Items.Add(nuevoexcur.Nombre);
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
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13 || ascci == 64)
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

		private void txtEdad_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57 || ascci == 13)
            {
                e.Handled = false;
                txtEdad.BorderBrush = Brushes.Green;
                txtEdad.Background = Brushes.LightGreen;
            }
            else
            {
                e.Handled = true;
                txtEdad.BorderBrush = Brushes.Red;
                txtEdad.Background = Brushes.LightCoral;
            }
        }

		private void txttelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

			if (ascci >= 48 && ascci <= 57 || ascci == 13)
			{
				e.Handled = false;
				txttelefono.BorderBrush = Brushes.Green;
				txttelefono.Background = Brushes.LightGreen;
			}
			else
			{
				e.Handled = true;
				txttelefono.BorderBrush = Brushes.Red;
				txttelefono.Background = Brushes.LightCoral;
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
		public void seleccionExcursionistaEspecifico(string seleccionado) {
			lstExcursionistas.SelectedItem=seleccionado;
		}
	}
}
