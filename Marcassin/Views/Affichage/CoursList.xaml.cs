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
	/// Logique d'interaction pour CoursList.xaml
	/// </summary>
	public partial class CoursList : Page {

		string ItemName = "Cours";
		AffichageController c = new AffichageController();

		public CoursList() {
			InitializeComponent();
			Lv_cours.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterCours();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_cours.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterCours(Lv_cours.SelectedItem as Cour) {
					Title = "Modifier Cours",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Cours pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_cours.SelectedItem != null) {
				CoursController a = new CoursController();
				a.SupprCours(Lv_cours.SelectedItem as Cour);
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Cours pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            CoursList Cou = new CoursList();
            this.NavigationService.Navigate(Cou);
        }
	}
}
