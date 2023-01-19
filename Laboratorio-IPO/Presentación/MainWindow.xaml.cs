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
using System.Xml;
using Laboratorio_IPO.Dominio;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage imagCheck = new BitmapImage(new Uri("/imagenes/check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/imagenes/cross.png", UriKind.Relative));

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
                                    txtUsuario, imgCheckUsuario))
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
                                         Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightCoral;
                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void txtContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(txtContrasena.Password, password,
                                    txtContrasena, imgCheckContrasena))
            {
                btnLogin.Focus();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario, imgCheckUsuario)
                &&
                ComprobarEntrada(txtContrasena.Password, password,
                txtContrasena, imgCheckContrasena))
            {
				CargarContenidoXML();
				VentanaPrincipal ventana = new VentanaPrincipal();
                ventana.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void VentanaLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
		private void CargarContenidoXML()
		{
            // Cargar contenido de prueba
            string foto;
			XmlDocument doc = new XmlDocument();
			var fichero = Application.GetResourceStream(new Uri("Persistencia/Guias/guias.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				
                if (File.Exists(@"..\..\Persistencia\Guias\" + node.Attributes["Nombre"].Value + ".jpg"))
                {
                    foto = @"..\..\Persistencia\Guias\" + node.Attributes["Nombre"].Value + ".jpg";
				}
                else if (File.Exists(@"..\..\Persistencia\Guias\" + node.Attributes["Nombre"].Value + ".jpeg"))
                {
                    foto = @"..\..\Persistencia\Guias\" + node.Attributes["Nombre"].Value + ".jpeg";
				}
                else {
                    foto = "";
				}
				Guia nuevoGuia = new Guia(node.Attributes["Nombre"].Value, node.Attributes["Apellidos"].Value, foto, node.Attributes["Idiomas"].Value, node.Attributes["RestriccionesDisponibilidad"].Value, long.Parse(node.Attributes["Telefono"].Value), node.Attributes["Correo"].Value, Convert.ToInt32(node.Attributes["ExcursionesRealizadas"].Value), Convert.ToInt32(node.Attributes["ExcursionesPorRealizar"].Value), double.Parse(node.Attributes["PuntuacionMedia"].Value));
                Guia.todosGuias.Add(nuevoGuia);
			}
            string mapa;
			doc = new XmlDocument();
			fichero = Application.GetResourceStream(new Uri("Persistencia/Rutas/rutas.xml", UriKind.Relative));
			doc.Load(fichero.Stream);
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				if (File.Exists(@"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + ".jpg"))
				{
					foto = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + ".jpg";
				}
				else if (File.Exists(@"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + ".jpeg"))
				{
					foto = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + ".jpeg";
					
				}
				else
				{
					foto = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + ".png";
				}
				if (File.Exists(@"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + "_Mapa.jpg"))
				{
					mapa = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + "_Mapa.jpg";
				}
				else if (File.Exists(@"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + "_Mapa.jpeg"))
				{
					mapa = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + "_Mapa.jpeg";
				}
				else
				{
					mapa = @"..\..\Persistencia\Rutas\" + node.Attributes["Nombre"].Value + "_Mapa.png";
				}
				Guia guiaDeRuta=null;
                PDI[] puntInter = null;
                foreach(Guia g in Guia.todosGuias){
                    if(g.Nombre.Equals(node.Attributes["Guia"].Value)){
                        guiaDeRuta = g;
                    }
                }
                String[] p = node.Attributes["pdi"].Value.Split(',');
                puntInter=new PDI[p.Length];
                for(int i = 0; i<p.Length ; i++){
                    puntInter[i]=new PDI(p[i].Trim(), node.Attributes["Nombre"].Value);
					PDI.todosPDIs.Add(puntInter[i]);
				}
				Ruta nuevaRuta = new Ruta(node.Attributes["Nombre"].Value, node.Attributes["Provincia"].Value, node.Attributes["Origen"].Value, node.Attributes["Destino"].Value, node.Attributes["Duracion"].Value, node.Attributes["Fecha"].Value + "/" + node.Attributes["Hora"].Value, Convert.ToInt32(node.Attributes["NivelDificultad"].Value),guiaDeRuta, Convert.ToInt32(node.Attributes["Numero_excursionistas"].Value), node.Attributes["FormaAcceso"].Value, node.Attributes["FormaVuelta"].Value, node.Attributes["Material"].Value, Convert.ToBoolean(node.Attributes["ComidaIncluida"].Value), puntInter, foto, mapa);
				Ruta.todosRutas.Add(nuevaRuta);
			}
			doc = new XmlDocument();
			fichero = Application.GetResourceStream(new Uri("Persistencia/PDI/PDI.xml", UriKind.Relative));
			doc.Load(fichero.Stream);
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				foto = "";
				foreach (PDI p in PDI.todosPDIs)
				{
					if (p.Nombre.Equals(node.Attributes["Nombre"].Value)&&p.Foto.Equals(node.Attributes["Ruta"].Value))
					{
						p.actualizar(foto, node.Attributes["Descripcion"].Value, node.Attributes["Tipologia"].Value);
					}
				}
			}
			doc = new XmlDocument();
			fichero = Application.GetResourceStream(new Uri("Persistencia/Excursionistas/excursionistas.xml", UriKind.Relative));
			doc.Load(fichero.Stream);
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				if (File.Exists(@"..\..\Persistencia\Excursionistas\" + node.Attributes["Nombre"].Value + ".jpg"))
				{
					foto = @"..\..\Persistencia\Excursionistas\" + node.Attributes["Nombre"].Value + ".jpg";
				}
				else if (File.Exists(@"..\..\Persistencia\Excursionistas\" + node.Attributes["Nombre"].Value + ".jpeg"))
				{
					foto = @"..\..\Persistencia\Excursionistas\" + node.Attributes["Nombre"].Value + ".jpeg";
				}
				else
				{
					foto = @"..\..\Persistencia\Excursionistas\" + node.Attributes["Nombre"].Value + ".png";
				}
				String[] r = node.Attributes["ListadoRutas"].Value.Split(',');
				Ruta[] excursiones = new Ruta[r.Length];
				for (int i = 0; i < r.Length; i++)
				{
					foreach (Ruta x in Ruta.todosRutas)
					{
						if (x.Nombre.Equals(r[i].Trim()))
						{
							excursiones[i]=x;
						}
					}
				}
				Excursionista nuevoExcur = new Excursionista(node.Attributes["Nombre"].Value, node.Attributes["Apellidos"].Value, foto, Convert.ToInt32(node.Attributes["Edad"].Value), long.Parse(node.Attributes["Telefono"].Value),excursiones, node.Attributes["Correo"].Value);
				Excursionista.todosExcursionistas.Add(nuevoExcur);
			}
			foreach (Ruta x in Ruta.todosRutas) {
				int i = 1;
				foreach (PDI y in x.Pdi) {
					if (File.Exists(@"..\..\Persistencia\PDI\" + x.Nombre +i.ToString()+ ".jpg"))
					{
						foto = @"..\..\Persistencia\PDI\" + x.Nombre + i.ToString() + ".jpg";
					}
					else if (File.Exists(@"..\..\Persistencia\PDI\" + x.Nombre + i.ToString() + ".jpeg"))
					{
						foto = @"..\..\Persistencia\PDI\" + x.Nombre + i.ToString() + ".jpeg";
					}
					else
					{
						foto = @"..\..\Persistencia\PDI\" + x.Nombre + i.ToString() + ".png";
					}
					i++;
					y.Foto= foto;
				}
			}
		}

		private void btnCancelar_Click(object sender, RoutedEventArgs e)
		{
            MessageBox.Show("Gracias por usar nuestra aplicación...", "Adiós");
            App.Current.Shutdown();
        }
	}
}
