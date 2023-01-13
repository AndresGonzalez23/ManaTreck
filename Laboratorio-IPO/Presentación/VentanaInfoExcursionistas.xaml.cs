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
	}
}
