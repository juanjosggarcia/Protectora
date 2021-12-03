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
using System.Windows.Shapes;

namespace Protectora.Presentacion
{
    /// <summary>
    /// Lógica de interacción para GestionPerro.xaml
    /// </summary>
    public partial class GestionPerro : Window
    {
        public GestionPerro()
        {
            InitializeComponent();
            for (int i = 0; i<10; i++)
            {
                spPanelDinamicoPerros.Children.Add(new ControlUsuarioPerro());
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Presentacion.Menu nw = new Presentacion.Menu();
            nw.Show();

            this.Close();
        }

        private void BtnPdrino_Click(object sender, RoutedEventArgs e)
        {
            Padrino Padrinito = new Padrino();
            Padrinito.Show();
        }

        private void BtnAniadir_Click(object sender, RoutedEventArgs e)
        {
            spPanelDinamicoPerros.Children.Add(new ControlUsuarioPerro());
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            int numItems = spPanelDinamicoPerros.Children.Count;
            if (numItems >= 1)
            {
                spPanelDinamicoPerros.Children.RemoveAt(numItems - 1);
            }
        }


    }
}
