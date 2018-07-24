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
	/// Logique d'interaction pour ChatList.xaml
	/// </summary>
	public partial class ChatList : Page {

		string ItemName = "ChatRoom";
		AffichageController c = new AffichageController();

		public ChatList() {
			InitializeComponent();
			Lv_chat.ItemsSource = c.Afficher(ItemName);
			lblTables.Content = ItemName;
		}

		private void Btn_Ajouter(object sender, RoutedEventArgs e) {
			string table = lblTables.Content as string;
			Window a;
			a = new PageAjouterChatRoom();
			a.Show();
		}

		private void Btn_Modifier(object sender, RoutedEventArgs e) {
			if (Lv_chat.SelectedItem != null) {
				string table = lblTables.Content as string;
				Cour c = Lv_chat.SelectedItem as Cour;
				Window a = new PageAjouterChatRoom(c.ChatRoom) {
					Title = "Modifier ChatRoom",
				};
				a.Show();
			} else {
				Erreur er = new Erreur("Veuillez selectionner une ChatRoom pour pouvoir le modifier");
				er.Show();
			}
		}

		private void Btn_Supprimer(object sender, RoutedEventArgs e) {
			if (Lv_chat.SelectedItem != null) {
				ChatController a = new ChatController();
				a.SupprChat(Lv_chat.SelectedItem as ChatRoom);
			} else {
				Erreur er = new Erreur("Veuillez selectionner une ChatRoom pour pouvoir le supprimer");
				er.Show();
			}
		}

		private void Menu_Click(object sender, RoutedEventArgs e) {
			Acceuil Acc = new Acceuil();
			this.NavigationService.Navigate(Acc);
		}

		private void Btn_refresh(object sender, RoutedEventArgs e) {
            ChatList Cha = new ChatList();
            this.NavigationService.Navigate(Cha);
        }
	}
}
