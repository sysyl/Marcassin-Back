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
	/// Logique d'interaction pour PageAjouterVille.xaml
	/// </summary>
	public partial class PageAjouterVille : Window 
	{
		private string Action;
		private int Id;

		public PageAjouterVille()
        {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Pays.ItemsSource = db.Pays.ToList();
			}
			cmb_Pays.DisplayMemberPath = "nomPays";
			cmb_Pays.SelectedValuePath = "id_Pays";
			Action = "add";
		}

		public PageAjouterVille(Ville a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Ville.Text = a.nomVille;
			using (var db = new MarcassinEntities1()) {
				cmb_Pays.ItemsSource = db.Pays.ToList();
				cmb_Pays.DisplayMemberPath = "nomPays";
				cmb_Pays.SelectedValuePath = "id_Pays";
				int index = 0;
				for (int i = 0; i < cmb_Pays.Items.Count; i++) {
					List<Pay> parts = db.Pays.ToList();
					if (parts[i].nomPays == a.Pay.nomPays) {
						index = i;
					}
				}
				this.cmb_Pays.SelectedIndex = index;
			}
			Id = a.id_Ville;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			VilleController a = new VilleController();
			if (Action == "add") {
				a.InsertVille(txt_Ville.Text, cmb_Pays.SelectedItem as Pay);
			} else {
				a.ModifyVille(Id, txt_Ville.Text, cmb_Pays.SelectedItem as Pay);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
