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
using Marcassin.Model;
using Marcassin.Controller;

namespace Marcassin
{
	/// <summary>
	/// Logique d'interaction pour PageAjouterLangue.xaml
	/// </summary>
	public partial class PageAjouterLangue : Window 
	{
		private string Action;
		private int Id;

		public PageAjouterLangue()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			Action = "add";
		}

		public PageAjouterLangue(Langue a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Langue.Text = a.nomLangue;
			Id = a.idLangue;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}
		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			LangueController a = new LangueController();
			if (Action == "add") {
				a.InsertLangue(txt_Langue.Text);
			} else {
				a.ModifyLangue(Id, txt_Langue.Text);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}

	}
}
