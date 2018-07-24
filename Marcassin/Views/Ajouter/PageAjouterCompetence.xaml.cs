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
	/// Logique d'interaction pour PageAjouterCompetence.xaml
	/// </summary>
	public partial class PageAjouterCompetence : Window 
	{
		private string Action;
		private int Id;

		public PageAjouterCompetence()
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

		public PageAjouterCompetence(Competence a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Nom.Text = a.nomCompetence;
			cb_Actif.IsChecked = a.estActif;
			cmb_Langue.ItemsSource = a.Langue.ToString();
			Id = a.idCompetence;
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
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			CompetenceController a = new CompetenceController();
			if (Action == "add") {
				a.InsertComp(txt_Nom.Text, cb_Actif.IsChecked, cmb_Langue.SelectedItem as Langue);
			} else {
				a.ModifyComp(Id, txt_Nom.Text, cb_Actif.IsChecked, cmb_Langue.SelectedItem as Langue);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
