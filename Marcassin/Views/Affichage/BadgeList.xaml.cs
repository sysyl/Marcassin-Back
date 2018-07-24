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
	/// Logique d'interaction pour BadgeList.xaml
	/// </summary>
	public partial class BadgeList : Page {

		string ItemName = "Badge";
		AffichageController c = new AffichageController();

		public BadgeList() {
			InitializeComponent();
			Lv_badge.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterBadge();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_badge.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterBadge(Lv_badge.SelectedItem as Badge) {
					Title = "Modifier Badge",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Badge pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_badge.SelectedItem != null) {
				BadgeController a = new BadgeController();
				a.SupprBadge(Lv_badge.SelectedItem as Badge);
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Badge pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            BadgeList bad = new BadgeList();
            this.NavigationService.Navigate(bad);
        }
	}
}
