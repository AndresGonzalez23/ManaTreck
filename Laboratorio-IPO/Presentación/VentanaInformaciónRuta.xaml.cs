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
using System.Xml.Linq;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaInformaciónRuta.xaml
    /// </summary>
    public partial class VentanaInformaciónRuta : Page
    {
        private Ruta ruta;
        private VentanaPrincipal ventanaPadre;
        public VentanaInformaciónRuta(string r, VentanaPrincipal ventana)
        {
            InitializeComponent();
            //Ruta ruta=null;
            ventanaPadre = ventana;
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
            txtHora.Text = ruta.FechaYHora.TimeOfDay.ToString();
            txtNivelDificultad.Text = ruta.Dificultad.ToString();
            txtMaterial.Text = ruta.Material;
            txtTiempo.Text = ruta.Duracion.ToString();
            if (ruta.ComidaIncluida)
            {
                txtComida.Text = "Incluida";
                txtComidaR.Text = "Incluida";
            }
            else
            {
                txtComida.Text = "No incluida";
                txtComidaR.Text = "No incluida";
            }
            txtGuia.Text = ruta.Guia.Nombre;
            txtFecha.Text = ruta.FechaYHora.Date.ToString();
            txtAcceso.Text = ruta.FormaAcceso;
            txtVuelta.Text = ruta.FormaVuelta;
            //txtFecha.SelectedDate = ruta.FechaYHora.Date;
            txtProvinciaR.Text = ruta.Provincia;
            txtOrigenR.Text = ruta.Origen;
            txtDestinoR.Text = ruta.Destino;
            txtHoraR.Text = ruta.FechaYHora.TimeOfDay.ToString();
            txtNivelDificultadR.Text = ruta.Dificultad.ToString();
            txtMaterialR.Text = ruta.Material;
            txtTiempoR.Text = ruta.Duracion.ToString();
            txtGuiaR.Text = ruta.Guia.Nombre;
            txtFechaR.Text = ruta.FechaYHora.Date.ToString();
            txtAccesoR.Text = ruta.FormaAcceso;
            txtVueltaR.Text = ruta.FormaVuelta;
            var converter = new ImageSourceConverter();
            imgRuta.Source = (ImageSource)converter.ConvertFromString(ruta.Mapa);
            imgRutaR.Source = (ImageSource)converter.ConvertFromString(ruta.Mapa);
            foreach (Excursionista excur in Excursionista.todosExcursionistas)
            {
                foreach (Ruta x in excur.Rutas)
                {
                    if (ruta.Nombre.Equals(x.Nombre))
                    {
                        lstExcursionistas.Items.Add(excur.Nombre);
                        lstExcursionistasR.Items.Add(excur.Nombre);
                    }
                }
            }
            //------------------------------------------------------------------------------------------
            var random = new Random(Environment.TickCount);
            for (int i = 0; i < 3; i++)
            {
                ruta.Realizadas.Add(new Ruta(i.ToString(), ruta.Provincia, ruta.Origen, ruta.Destino, new TimeSpan(random.Next(1, 6), random.Next(0, 60), 00), new DateTime(random.Next(1995, 2023), random.Next(1, 13), random.Next(1, 28), random.Next(1, 24), random.Next(0, 60), 00), random.Next(1, 6), Guia.todosGuias[random.Next(0, Guia.todosGuias.Count)], random.Next(5, 15), Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].FormaAcceso, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].FormaVuelta, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].Material, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].ComidaIncluida, ruta.Pdi, ruta.Foto, ruta.Mapa));
                ruta.Proximas.Add(new Ruta(i.ToString(), ruta.Provincia, ruta.Origen, ruta.Destino, new TimeSpan(random.Next(1, 6), random.Next(0, 60), 00), new DateTime(random.Next(1995, 2023), random.Next(1, 13), random.Next(1, 28), random.Next(1, 24), random.Next(0, 60), 00), random.Next(1, 6), Guia.todosGuias[random.Next(0, Guia.todosGuias.Count)], random.Next(5, 15), Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].FormaAcceso, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].FormaVuelta, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].Material, Ruta.todosRutas[random.Next(0, Ruta.todosRutas.Count)].ComidaIncluida, ruta.Pdi, ruta.Foto, ruta.Mapa));
            }
            ruta.Realizadas.Add(new Ruta(3.ToString(), ruta.Provincia, ruta.Origen, ruta.Destino, ruta.Duracion, ruta.FechaYHora, ruta.Dificultad, ruta.Guia, ruta.NumExcursionistas, ruta.FormaAcceso, ruta.FormaVuelta, ruta.Material, ruta.ComidaIncluida, ruta.Pdi, ruta.Foto, ruta.Mapa));
            foreach (Ruta x in ruta.Realizadas)
            {
                lstExcursionesRealizadas.Items.Add(x.Nombre);
            }
            foreach (Ruta x in ruta.Proximas)
            {
                lstProximasExcursiones.Items.Add(x.Nombre);
            }
        }
        private void txtProvincia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 44 || ascci == 45 || ascci == 13)
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
        private void txtTiempo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comprobarFormatoHora(txtTiempo.Text) == true)
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
                if (horaComprobada != elemento)
                {
                    prueba = true;
                }
                else
                {
                    prueba = false;
                }
            }
            return prueba;
        }

        private void btnPDIR_Click(object sender, RoutedEventArgs e)
        {
            VentanaPDI ventanaPDI = new VentanaPDI(ruta.Nombre);
            ventanaPDI.Visibility = Visibility.Visible;
        }

        private void btnPDI_Click(object sender, RoutedEventArgs e)
        {
            VentanaPDI ventanaPDI = new VentanaPDI(ruta.Nombre);
            ventanaPDI.Visibility = Visibility.Visible;
        }

        private void btnLimpiarR_Click(object sender, RoutedEventArgs e)
        {
            txtProvinciaR.Clear();
            txtOrigenR.Clear();
            txtHoraR.Clear();
            txtDestinoR.Clear();
            txtTiempoR.Clear();
            txtNivelDificultadR.Clear();
            txtComidaR.Clear();
            txtGuiaR.Clear();
            txtMaterialR.Clear();
            txtAccesoR.Clear();
            txtVueltaR.Clear();
            txtIncidencias.Clear();
            lstExcursionistasR.Items.Clear();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtProvincia.Clear();
            txtOrigen.Clear();
            txtHora.Clear();
            txtDestino.Clear();
            txtTiempo.Clear();
            txtNivelDificultad.Clear();
            txtComida.Clear();
            txtGuia.Clear();
            txtMaterial.Clear();
            txtAcceso.Clear();
            txtVuelta.Clear();
            lstProximasExcursiones.UnselectAll();
            lstExcursionistas.Items.Clear();
        }

        private void lstProximasExcursiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstProximasExcursiones.SelectedItem != null)
            {
                Ruta select = null;
                foreach (Ruta x in ruta.Proximas)
                {
                    if (x.Nombre.Equals(lstProximasExcursiones.SelectedItem))
                    {
                        select = x;
                        txtProvincia.Text = x.Provincia;
                        txtOrigen.Text = x.Origen;
                        txtDestino.Text = x.Destino;
                        txtHora.Text = x.FechaYHora.TimeOfDay.ToString();
                        txtNivelDificultad.Text = x.Dificultad.ToString();
                        txtMaterial.Text = x.Material;
                        txtTiempo.Text = x.Duracion.ToString();
                        if (x.ComidaIncluida)
                        {
                            txtComida.Text = "Incluida";
                        }
                        else
                        {
                            txtComida.Text = "No incluida";
                        }
                        txtGuia.Text = x.Guia.Nombre;
                        txtFecha.Text = x.FechaYHora.Date.ToString();
                        txtAcceso.Text = x.FormaAcceso;
                        txtVuelta.Text = x.FormaVuelta;
                        btnBorrar.IsEnabled = true;
                    }
                }
                var random = new Random(Environment.TickCount);
                int[] noRepetir = new int[select.NumExcursionistas];
                lstExcursionistas.Items.Clear();
                for (int i = 0; i < noRepetir.Length; i++)
                {
                    int y = random.Next(0, Excursionista.todosExcursionistas.Count);
                    bool control;
                    do
                    {
                        control = false;
                        foreach (int n in noRepetir)
                        {
                            if (n == y)
                            {
                                control = true;
                                y = random.Next(0, Excursionista.todosExcursionistas.Count);
                            }
                        }
                    } while (control);
                    lstExcursionistas.Items.Add(Excursionista.todosExcursionistas[y].Nombre);
                    noRepetir[i] = y;
                }
            }
        }

        private void lstExcursionesRealizadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstExcursionesRealizadas.SelectedItem != null)
            {
                Ruta select = null;
                foreach (Ruta x in ruta.Realizadas)
                {
                    if (x.Nombre.Equals(lstExcursionesRealizadas.SelectedItem))
                    {
                        select = x;
                        txtProvinciaR.Text = x.Provincia;
                        txtOrigenR.Text = x.Origen;
                        txtDestinoR.Text = x.Destino;
                        txtHoraR.Text = x.FechaYHora.TimeOfDay.ToString();
                        txtNivelDificultadR.Text = x.Dificultad.ToString();
                        txtMaterialR.Text = x.Material;
                        txtTiempoR.Text = x.Duracion.ToString();
                        if (x.ComidaIncluida)
                        {
                            txtComidaR.Text = "Incluida";
                        }
                        else
                        {
                            txtComidaR.Text = "No incluida";
                        }
                        txtGuiaR.Text = x.Guia.Nombre;
                        txtFechaR.Text = x.FechaYHora.Date.ToString();
                        txtAccesoR.Text = x.FormaAcceso;
                        txtVueltaR.Text = x.FormaVuelta;
                        btnBorrarR.IsEnabled = true;
                    }
                }
                var random = new Random(Environment.TickCount);
                int[] noRepetir = new int[select.NumExcursionistas];
                lstExcursionistasR.Items.Clear();
                for (int i = 0; i < noRepetir.Length; i++)
                {
                    int y = random.Next(0, Excursionista.todosExcursionistas.Count);
                    bool control;
                    do
                    {
                        control = false;
                        foreach (int n in noRepetir)
                        {
                            if (n == y)
                            {
                                control = true;
                                y = random.Next(0, Excursionista.todosExcursionistas.Count);
                            }
                        }
                    } while (control);
                    lstExcursionistasR.Items.Add(Excursionista.todosExcursionistas[y].Nombre);
                    noRepetir[i] = y;
                }
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (lstProximasExcursiones.SelectedItem != null)
            {
                Ruta eliminada = null;
                bool eliminar = false;
                foreach (Ruta aux in ruta.Proximas)
                {
                    if (lstProximasExcursiones.SelectedItem.Equals(aux.Nombre))
                    {
                        eliminada = aux;
                        eliminar = true;
                    }
                }
                if (eliminar)
                {
                    lstProximasExcursiones.UnselectAll();
                    ruta.Proximas.Remove(eliminada);
                    lstProximasExcursiones.Items.Remove(eliminada.Nombre);
                    btnLimpiar_Click(sender, e);
                }
            }
            btnBorrar.IsEnabled = false;
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (lstExcursionistas.SelectedItem == null)
            {
                bool exisguia = false;
                Guia select = null;
                foreach (Guia aux in Guia.todosGuias)
                {
                    if (aux.Nombre.Equals(txtGuia.Text))
                    {
                        exisguia = true;
                        select = aux;
                    }
                }
                if (txtProvincia.Text != "" && txtOrigen.Text != "" && txtDestino.Text != "" && txtHora.Text != "" && txtTiempo.Text != "" && txtNivelDificultad.Text != "" && (txtComida.Text != "" || txtComida.Text != "true" || txtComida.Text != "false") && txtFecha.Text != "" && txtGuia.Text != "" && txtMaterial.Text != "" && txtAcceso.Text != "" && txtVuelta.Text != "" && exisguia)
                {
                    Ruta nuevaruta = new Ruta(ruta.Proximas.Count.ToString(), txtProvincia.Text, txtOrigen.Text, txtDestino.Text, txtTiempo.Text, txtFecha.Text + "/" + txtHora.Text, Convert.ToInt32(txtNivelDificultad.Text), select, 10, txtAcceso.Text, txtVuelta.Text, txtMaterial.Text, Convert.ToBoolean(txtComida.Text), ruta.Pdi, ruta.Foto, ruta.Mapa);
                    ruta.Proximas.Add(nuevaruta);
                    lstProximasExcursiones.Items.Add(nuevaruta.Nombre);
                }
                else
                {
                    MessageBox.Show(" Falta por rellenar algun campo\n El formato no es correcto\n El guia no existe", "Error al añadir");
                }
            }
        }

        private void btnBorrarR_Click(object sender, RoutedEventArgs e)
        {
            if (lstExcursionesRealizadas.SelectedItem != null)
            {
                Ruta eliminada = null;
                bool eliminar = false;
                foreach (Ruta aux in ruta.Realizadas)
                {
                    if (lstExcursionesRealizadas.SelectedItem.Equals(aux.Nombre))
                    {
                        eliminada = aux;
                        eliminar = true;
                    }
                }
                if (eliminar)
                {
                    lstExcursionesRealizadas.UnselectAll();
                    ruta.Realizadas.Remove(eliminada);
                    lstExcursionesRealizadas.Items.Remove(eliminada.Nombre);
                    txtProvinciaR.Clear();
                    txtOrigenR.Clear();
                    txtHoraR.Clear();
                    txtDestinoR.Clear();
                    txtTiempoR.Clear();
                    txtNivelDificultadR.Clear();
                    txtComidaR.Clear();
                    txtGuiaR.Clear();
                    txtMaterialR.Clear();
                    txtAccesoR.Clear();
                    txtVueltaR.Clear();
                    txtIncidencias.Clear();
                    lstExcursionistasR.Items.Clear();
                }
            }
            btnBorrarR.IsEnabled = false;
        }

        private void lstExcursionistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstExcursionistas.SelectedItem != null)
            {
                ventanaPadre.seleccionExcursionistaEspecifico(lstExcursionistas.SelectedItem.ToString());
            }
            lstExcursionistas.UnselectAll();
        }

        private void lstExcursionistasR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstExcursionistasR.SelectedItem != null)
            {
                ventanaPadre.seleccionExcursionistaEspecifico(lstExcursionistasR.SelectedItem.ToString());
            }
            lstExcursionistasR.UnselectAll();
        }

        private void btnIraGuias_Click(object sender, RoutedEventArgs e)
        {
            bool existe = false;
            foreach (Guia x in Guia.todosGuias)
            {
                if (txtGuia.Text.Equals(x.Nombre)) { existe = true; }
            }
            if (existe)
            {
                ventanaPadre.seleccionGuiaEspecifico(txtGuia.Text);
            }
        }

        private void btnIraGuiasR_Click(object sender, RoutedEventArgs e)
        {
            bool existe = false;
            foreach (Guia x in Guia.todosGuias)
            {
                if (txtGuia.Text.Equals(x.Nombre)) { existe = true; }
            }
            if (existe)
            {
                ventanaPadre.seleccionGuiaEspecifico(txtGuia.Text);
            }
        }
    }
}
