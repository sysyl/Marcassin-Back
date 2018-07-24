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
using Marcassin.Controller;
using Marcassin.Model;

namespace Marcassin
{
	/// <summary>
	/// Logique d'interaction pour PageAjouterPays.xaml
	/// </summary>
	public partial class PageAjouterPays : Window
    {
		private string Action;
		private int Id;

		public PageAjouterPays()
        {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			Action = "add";
		}

		public PageAjouterPays(Pay a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Pays.Text = a.nomPays;
			Id = a.id_Pays;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			PaysController a = new PaysController();
			if (Action == "add") {
				a.InsertPays(txt_Pays.Text);
			} else {
				a.ModifyPays(Id, txt_Pays.Text);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
