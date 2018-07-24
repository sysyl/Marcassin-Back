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
using Marcassin.Controller;
using Marcassin.Model;

namespace Marcassin
{
	/// <summary>
	/// Logique d'interaction pour PageAjouterUtilisateur.xaml
	/// </summary>
	public partial class PageAjouterUtilisateur : Window 
	{
		private string Action;
		private int Id;

		public PageAjouterUtilisateur()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Entreprise.ItemsSource = db.Entreprises.ToList();
				cmb_Ville.ItemsSource = db.Villes.ToList();
			}
			cmb_Entreprise.DisplayMemberPath = "nomEntreprise";
			cmb_Entreprise.SelectedValuePath = "id_Entreprise";
			cmb_Ville.DisplayMemberPath = "nomVille";
			cmb_Ville.SelectedValuePath = "id_Ville";
			Action = "add";
		}

		public PageAjouterUtilisateur(Utilisateur a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Entreprise.ItemsSource = db.Entreprises.ToList();
				cmb_Entreprise.DisplayMemberPath = "nomEntreprise";
				cmb_Entreprise.SelectedValuePath = "id_Entreprise";
				cmb_Ville.ItemsSource = db.Villes.ToList();
				cmb_Ville.DisplayMemberPath = "nomVille";
				cmb_Ville.SelectedValuePath = "id_Ville";
				int index = 0;
				for (int i = 0; i < cmb_Entreprise.Items.Count; i++) {
					List<Entreprise> parts = db.Entreprises.ToList();
					if (parts[i].nomEntreprise == a.Entreprise.nomEntreprise) {
						index = i;
					}
				}
				this.cmb_Entreprise.SelectedIndex = index;
				for (int i = 0; i < cmb_Ville.Items.Count; i++) {
					List<Ville> parts = db.Villes.ToList();
					if (parts[i].nomVille == a.Ville.nomVille) {
						index = i;
					}
				}
				this.cmb_Ville.SelectedIndex = index;
			}
			txt_Nom.Text = a.nomUtilisateur;
			txt_Prenom.Text = a.prenomUtilisateur;
			txt_Age.Text = a.ageUtilisateur.ToString();
			txt_Email.Text = a.emailUtilisateur;
			txt_Linkedin.Text = a.lienLinkedinUtilisateur;
			txt_Mdp.Password = a.motDePasseUtilisateur;
			cb_Tuteur.IsChecked = a.estTuteur;
			cb_Externe.IsChecked = a.estExterne;
			cb_Valide.IsChecked = a.estValide;
			Id = a.idUtilisateur;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			UtilController a = new UtilController();
			int age;
			try {
				age = Int32.Parse(txt_Age.Text);
			} catch (Exception) {
				throw;
			}
			if (Action == "add") {
				a.InsertUtil(txt_Prenom.Text, txt_Nom.Text, age, txt_Email.Text, txt_Linkedin.Text, txt_Mdp.Password, cb_Tuteur.IsChecked.Value, cb_Externe.IsChecked.Value, cb_Valide.IsChecked.Value, cmb_Entreprise.SelectedItem as Entreprise, cmb_Ville.SelectedItem as Ville);
			} else {
				a.ModifyUtil(Id, txt_Prenom.Text, txt_Nom.Text, age, txt_Email.Text, txt_Linkedin.Text, txt_Mdp.Password, cb_Tuteur.IsChecked, cb_Externe.IsChecked, cb_Valide.IsChecked, cmb_Entreprise.SelectedItem as Entreprise, cmb_Ville.SelectedItem as Ville);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
