using Marcassin.Views.Affichage;
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

namespace Marcassin.Views
{
    /// <summary>
    /// Logique d'interaction pour Cours.xaml
    /// </summary>
    public partial class Cours : Page
    {
        public Cours()
        {
            InitializeComponent();
        }

        private void btn_retour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Acceuil Acc = new Acceuil();
            this.NavigationService.Navigate(Acc);
        }

        private void btn_cours_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CoursList Cou = new CoursList();
            this.NavigationService.Navigate(Cou);
        }

        private void btn_chatrooms_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChatList Cha = new ChatList();
            this.NavigationService.Navigate(Cha);
        }

        private void btn_cours_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Cours.png", UriKind.Relative));
            btn_cours.Source = Source;
        }

        private void btn_cours_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonCours.jpg", UriKind.Relative));
            btn_cours.Source = Source;
        }

        private void btn_chatrooms_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/ChatRooms.png", UriKind.Relative));
            btn_chatrooms.Source = Source;
        }

        private void btn_chatrooms_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/GestionChatrooms.jpg", UriKind.Relative));
            btn_chatrooms.Source = Source;
        }

        private void btn_retour_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/retourombre.png", UriKind.Relative));
            btn_retour.Source = Source;
        }

        private void btn_retour_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/retour2.jpg", UriKind.Relative));
            btn_retour.Source = Source;
        }
    }
}
