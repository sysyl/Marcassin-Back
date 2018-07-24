using System;
using System.Collections.Generic;
using System.Windows;
using Marcassin.Model;
using Controller;
using Marcassin.Controller;
using Marcassin.Views;
using Marcassin.Views.Affichage;

namespace Marcassin {
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {

		public MainWindow()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			//BadgeList Acc = new BadgeList();
			Acceuil Acc = new Acceuil();
            myFrame.NavigationService.Navigate(Acc);
		}

		
		
	}
}
