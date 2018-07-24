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
	/// Logique d'interaction pour LanguesList.xaml
	/// </summary>
	public partial class LanguesList : Page {

		string ItemName = "Langue";
		AffichageController c = new AffichageController();

		public LanguesList() {
			InitializeComponent();
			Lv_langue.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterLangue();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_langue.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterLangue(Lv_langue.SelectedItem as Langue) {
					Title = "Modifier Langue",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Langue pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_langue.SelectedItem != null) {
				LangueController a = new LangueController();
				a.SupprLangue(Lv_langue.SelectedItem as Langue);
			} else {
				Erreur er = new Erreur("Veuillez selectionner une Langue pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            LanguesList Lang = new LanguesList();
            this.NavigationService.Navigate(Lang);
        }
	}
}
