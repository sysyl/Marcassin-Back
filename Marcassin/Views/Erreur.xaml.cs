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
using System.Windows.Shapes;

namespace Marcassin.Views {
	/// <summary>
	/// Logique d'interaction pour Erreur.xaml
	/// </summary>
	public partial class Erreur : Window {
		public Erreur(string message) {
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			InitializeComponent();
			Message.Content = message;
		}

		private void Btn_ok_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
