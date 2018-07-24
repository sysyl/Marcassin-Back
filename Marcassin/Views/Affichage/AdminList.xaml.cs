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
	/// Logique d'interaction pour AdminList.xaml
	/// </summary>
	public partial class AdminList : Page {

		string ItemName = "Admins";
		AffichageController c = new AffichageController();

		public AdminList() {
			InitializeComponent();
			Lv_admin.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterAdmin();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_admin.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterAdmin(Lv_admin.SelectedItem as Admin) {
					Title = "Modifier Admin",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Admin pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_admin.SelectedItem != null) {
				AdminController a = new AdminController();
				a.SupprAdmin(Lv_admin.SelectedItem as Admin);
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Admin pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            AdminList Admin = new AdminList();
            this.NavigationService.Navigate(Admin);
        }
	}
}
