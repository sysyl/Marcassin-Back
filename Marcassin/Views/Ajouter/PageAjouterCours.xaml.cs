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
using Marcassin.Views;

namespace Marcassin
{
	/// <summary>
	/// Logique d'interaction pour PageAjouterCours.xaml
	/// </summary>
	public partial class PageAjouterCours : Window
    {
		private string Action;
		private int Id;

		public PageAjouterCours()
        {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			using (var db = new MarcassinEntities1()) {
				cmb_Competence.ItemsSource = db.Competences.ToList();
			}
			cmb_Competence.DisplayMemberPath = "nomCompetence";
			cmb_Competence.SelectedValuePath = "idCompetence";
			Action = "add";
		}

		public PageAjouterCours(Cour a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Nom.Text = a.nomCours;
			cb_Finis.IsChecked = a.estFinit;
			d_Date.SelectedDate = a.dateCours;
			using (var db = new MarcassinEntities1()) {
				cmb_Competence.ItemsSource = db.Competences.ToList();
				cmb_Competence.DisplayMemberPath = "nomCompetence";
				cmb_Competence.SelectedValuePath = "idCompetence";
				int index = 0;
				for (int i = 0; i < cmb_Competence.Items.Count; i++) {
					List<Competence> parts = db.Competences.ToList();
					if (parts[i].nomCompetence == a.Competence.nomCompetence) {
						index = i;
					}
				}
				this.cmb_Competence.SelectedIndex = index;
			}
			Id = a.idCours;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			if (d_Date.SelectedDate != null) {
				CoursController a = new CoursController();
				DateTime date = d_Date.SelectedDate.Value;
				if (Action == "add") {
					a.InsertCours(txt_Nom.Text, date, cb_Finis.IsChecked, cmb_Competence.SelectedItem as Competence);
				} else {
					a.ModifyCours(Id, txt_Nom.Text, date, cb_Finis.IsChecked, cmb_Competence.SelectedItem as Competence);
				}
				Close();
			} else {
				Erreur er = new Erreur("Selectionnez une date");
				er.Show();
			}
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
