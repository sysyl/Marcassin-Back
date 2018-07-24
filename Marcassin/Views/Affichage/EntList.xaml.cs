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
	/// Logique d'interaction pour EntList.xaml
	/// </summary>
	public partial class EntList : Page {

		string ItemName = "Entreprise";
		AffichageController c = new AffichageController();

		public EntList() {
			InitializeComponent();
			Lv_ent.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterEntreprise();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_ent.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterEntreprise(Lv_ent.SelectedItem as Entreprise) {
					Title = "Modifier Entreprise",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Entreprise pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_ent.SelectedItem != null) {
				EntrepriseController a = new EntrepriseController();
				a.SupprEnt(Lv_ent.SelectedItem as Entreprise);
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Entreprise pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            EntList Ent = new EntList();
            this.NavigationService.Navigate(Ent);
        }
	}
}
