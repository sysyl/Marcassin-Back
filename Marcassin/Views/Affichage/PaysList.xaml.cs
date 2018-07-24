using Controller;
using Marcassin.Controller;
using Marcassin.Model;
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

namespace Marcassin.Views.Affichage {
	/// <summary>
	/// Logique d'interaction pour PaysList.xaml
	/// </summary>
	public partial class PaysList : Page {

		string ItemName = "Pays";
		AffichageController c = new AffichageController();

		public PaysList() {
			InitializeComponent();
			Lv_pays.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterPays();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_pays.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterPays(Lv_pays.SelectedItem as Pay) {
					Title = "Modifier Pays",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Pays pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_pays.SelectedItem != null) {
				PaysController a = new PaysController();
				a.SupprPays(Lv_pays.SelectedItem as Pay);
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Pays pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            PaysList Pay = new PaysList();
            this.NavigationService.Navigate(Pay);
        }
	}
}
