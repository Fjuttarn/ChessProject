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

namespace Chess2._0
{
    /// <summary>
    /// Interaction logic for ChooseColor.xaml
    /// </summary>
    public partial class ChooseColor : Window
    {
        public ChooseColor()
        {
            InitializeComponent();
        }

        string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private void white_Click(object sender, RoutedEventArgs e)
        {
            Color = "white";
            Close();
        }

        private void black_Click(object sender, RoutedEventArgs e)
        {
            Color = "black";
            Close();
        }
    }
}
