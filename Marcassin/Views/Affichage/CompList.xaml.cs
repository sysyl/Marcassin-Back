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
	/// Logique d'interaction pour CompList.xaml
	/// </summary>
	public partial class CompList : Page {

		string ItemName = "Competence";
		AffichageController c = new AffichageController();

		public CompList() {
			InitializeComponent();
			Lv_comp.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterCompetence();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_comp.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterCompetence(Lv_comp.SelectedItem as Competence) {
					Title = "Modifier Competence",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Competence pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_comp.SelectedItem != null) {
				CompetenceController a = new CompetenceController();
				a.SupprComp(Lv_comp.SelectedItem as Competence);
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Competence pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            CompList Comp = new CompList();
            this.NavigationService.Navigate(Comp);
        }
	}
}
