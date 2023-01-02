﻿using System;
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

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaInfoGuias.xaml
    /// </summary>
    public partial class VentanaInfoGuias : Page
    {
        public VentanaInfoGuias()
        {
            InitializeComponent();
            lstExcursionistas.Items.Clear();
			foreach (Guia aux in Guia.todosGuias)
			{
                lstExcursionistas.Items.Add(aux.Nombre);
            }
        }

		private void lstExcursionistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            Guia seleccionado=null;
			foreach (Guia aux in Guia.todosGuias)
			{
                if (lstExcursionistas.SelectedItem.Equals(aux.Nombre)) {
                    seleccionado= aux;
                }
			}
            txtNombre.Text= seleccionado.Nombre;
            txtApellido.Text = seleccionado.Apellidos;
            txtCorreo.Text = seleccionado.Correo;
            txtTelefono.Text = seleccionado.Telefono.ToString();
            txtDisponibilidad.Text = seleccionado.Disponibilidad;
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
			lstProximas.Items.Clear();
			lstRealizadas.Items.Clear();
			foreach (Ruta aux in Ruta.todosRutas)
			{
				if (aux.Guia.Nombre.Equals(lstExcursionistas.SelectedItem))
				{
					lstRealizadas.Items.Add(aux.Nombre);
				}
			}
			var random = new Random(Environment.TickCount);
			int[] noRepetir=new int[seleccionado.ExcursionesPorRealizar];
			for (int i = 0; i < seleccionado.ExcursionesPorRealizar; i++)
			{
				int y = random.Next(0, Ruta.todosRutas.Count);
				bool control=false;
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
}
