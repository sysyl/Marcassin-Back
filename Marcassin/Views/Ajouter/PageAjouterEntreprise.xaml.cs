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
	/// Logique d'interaction pour PageAjouterEntreprise.xaml
	/// </summary>
	public partial class PageAjouterEntreprise : Window
    {
		private string Action;
		private int Id;

		public PageAjouterEntreprise()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Ville.ItemsSource = db.Villes.ToList();
			}
			cmb_Ville.DisplayMemberPath = "nomVille";
			cmb_Ville.SelectedValuePath = "id_Ville";
			Action = "add";
		}

		public PageAjouterEntreprise(Entreprise a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Nom.Text = a.nomEntreprise;
			using (var db = new MarcassinEntities1()) {
				cmb_Ville.ItemsSource = db.Villes.ToList();
				cmb_Ville.DisplayMemberPath = "nomVille";
				cmb_Ville.SelectedValuePath = "id_Ville";
				int index = 0;
				for (int i = 0; i < cmb_Ville.Items.Count; i++) {
					List<Ville> parts = db.Villes.ToList();
					if (parts[i].nomVille == a.Ville.nomVille) {
						index = i;
					}
				}
				this.cmb_Ville.SelectedIndex = index;
			}
			Id = a.id_Entreprise;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			EntrepriseController a = new EntrepriseController();
			if (Action == "add") {
				a.InsertEnt(txt_Nom.Text, cmb_Ville.SelectedItem as Ville);
			} else {
				a.ModifyEnt(Id, txt_Nom.Text, cmb_Ville.SelectedItem as Ville);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
