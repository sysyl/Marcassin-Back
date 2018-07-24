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
	/// Logique d'interaction pour PageAjouterChatRoom.xaml
	/// </summary>
	public partial class PageAjouterChatRoom : Window
    {
		private string Action;
		private int Id;

		public PageAjouterChatRoom()
        {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			Action = "add";
		}

		public PageAjouterChatRoom(ChatRoom a) {
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			txt_Nom.Text = a.nomduRoom;
			Id = a.idChatRoom;
			Action = "update";
			Btn_ajouter.Content = "Modifier";
			Btn_ajouter.Background = new SolidColorBrush(Color.FromRgb(255, 200, 0));
		}

		private void Btn_ajouter_Click(object sender, RoutedEventArgs e) {
			ChatController a = new ChatController();
			if (Action == "add") {
				a.InsertChat(txt_Nom.Text);
			} else {
				a.ModifyChat(Id, txt_Nom.Text);
			}
			Close();
		}

		private void Btn_annuler_Click(object sender, RoutedEventArgs e) {
			Close();
		}
	}
}
