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
	/// Logique d'interaction pour UtilList.xaml
	/// </summary>
	public partial class UtilList : Page {

		public UtilList() {
			InitializeComponent();
			Lv_Util.ItemsSource = List();
			lblTables.Content = "Utilisateur";
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterUtilisateur();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_Util.SelectedItem != null) {
				string table = lblTables.Content as string;
				Window a = new PageAjouterUtilisateur(Lv_Util.SelectedItem as Utilisateur) {
					Title = "Modifier Utilisateur",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Utilisateur pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_Util.SelectedItem != null) {
				UtilController a = new UtilController();
				a.SupprUtil(Lv_Util.SelectedItem as Utilisateur);
			} else {
				Erreur er = new Erreur("Veuillez selectionner un Utilisateur pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            UtilList Uti = new UtilList();
            this.NavigationService.Navigate(Uti);
        }

		private void txt_recherche_TextChanged(object sender, TextChangedEventArgs e) {
            if (txt_recherche.Text != "Recherche")
            {
                using (var db = new MarcassinEntities1())
                {
                    Lv_Util.ItemsSource = db.Utilisateurs.Include("Ville").Include("Entreprise")
                        .Where(k => k.nomUtilisateur.ToUpper().Contains(txt_recherche.Text.ToUpper()) || k.prenomUtilisateur.Contains(txt_recherche.Text)).ToList();
                }
            }
		}

		public List<Utilisateur> List() {
			using (var db = new MarcassinEntities1()) {
				return db.Utilisateurs.Include("Ville").Include("Entreprise").ToList();
			}
		}

        //private void txt_recherche_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    if (txt_recherche.Text == "Recherche")
        //    {
        //        txt_recherche.Text = "";
        //        Brush couleur = new SolidColorBrush(Colors.Gray);
        //        txt_recherche.Foreground = couleur;
        //    }
        //}

        //private void txt_recherche_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    if (txt_recherche.Text.Length == 0)
        //    {
        //        txt_recherche.Text = "Recherche";
        //        Brush couleur = new SolidColorBrush(Colors.Black);
        //        txt_recherche.Foreground = couleur;
        //    }
        //}

        private void txt_recherche_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_recherche.Text == "Recherche")
            {
                txt_recherche.Text = "";
                Brush couleur = new SolidColorBrush(Colors.Black);
                txt_recherche.Foreground = couleur;
            }
        }

        private void txt_recherche_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_recherche.Text.Length == 0)
            {
                txt_recherche.Text = "Recherche";
                Brush couleur = new SolidColorBrush(Colors.LightSlateGray);
                txt_recherche.Foreground = couleur;
            }
        }
    }
}
