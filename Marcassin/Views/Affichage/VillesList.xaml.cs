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
	/// Logique d'interaction pour VillesList.xaml
	/// </summary>
	public partial class VillesList : Page {

		string ItemName = "Ville";
		AffichageController c = new AffichageController();

		public VillesList() {
			InitializeComponent();
			Lv_ville.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterVille();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_ville.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterVille(Lv_ville.SelectedItem as Ville) {
					Title = "Modifier Ville",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Ville pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_ville.SelectedItem != null) {
				VilleController a = new VilleController();
				a.SupprVille(Lv_ville.SelectedItem as Ville);
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Ville pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            VillesList Vil = new VillesList();
            this.NavigationService.Navigate(Vil);
        }
	}
}
