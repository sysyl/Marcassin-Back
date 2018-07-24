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
	/// Logique d'interaction pour PageAjouterAdmin.xaml
	/// </summary>
	public partial class PageAjouterAdmin : Window
    {
		private string Action;
		private int Id;

        public PageAjouterAdmin()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			Action = "add";
		}

		public PageAjouterAdmin(Admin a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Prenom.Text = a.prenomAdmin;
			txt_Nom.Text = a.nomAdmin;
			txt_Mdp.Password = a.motDePasseAdmin;
			Id = a.idAdmin;
			Action = "update";
			Ajouter_Btn.Content = "Modifier";
			Ajouter_Btn.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Ajouter_Btn_Click(object sender, RoutedEventArgs e) {
			AdminController a = new AdminController();
			if (Action == "add") {
				a.InsertAdmin(txt_Prenom.Text, txt_Nom.Text, txt_Mdp.Password);
			}else {
				a.ModifyAdmin(Id, txt_Prenom.Text, txt_Nom.Text, txt_Mdp.Password);
			}
			Close();
		}

		private void Annuler_btn_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
