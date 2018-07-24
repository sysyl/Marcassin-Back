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
	/// Logique d'interaction pour PageAjouterBadge.xaml
	/// </summary>
	public partial class PageAjouterBadge : Window
    {
		private string Action;
		private int Id;

        public PageAjouterBadge()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Langue.ItemsSource = db.Langues.ToList();
			}
			cmb_Langue.DisplayMemberPath = "nomLangue";
			cmb_Langue.SelectedValuePath = "idLangue";
			Action = "add";
		}

		public PageAjouterBadge(Badge a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Nom.Text = a.nomBadge;
			using (var db = new MarcassinEntities1()) {
				cmb_Langue.ItemsSource = db.Langues.ToList();
				cmb_Langue.DisplayMemberPath = "nomLangue";
				cmb_Langue.SelectedValuePath = "idLangue";
				int index = 0;
				for (int i = 0; i < cmb_Langue.Items.Count; i++) {
					List<Langue> parts = db.Langues.ToList();
					if (parts[i].nomLangue == a.Langue.nomLangue) {
						index = i;
					}
				}
				this.cmb_Langue.SelectedIndex = index;
			}
			Id = a.id_Badge;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			BadgeController a = new BadgeController();
			if (Action == "add") {
				a.InsertBadge(txt_Nom.Text, cmb_Langue.SelectedItem as Langue);
			} else {
				a.ModifyBadge(Id, txt_Nom.Text, cmb_Langue.SelectedItem as Langue);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
