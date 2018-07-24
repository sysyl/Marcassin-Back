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
    /// Logique d'interaction pour Utilisateurs.xaml
    /// </summary>
    public partial class Utilisateurs : Page
    {
        public Utilisateurs()
        {
            InitializeComponent();
        }

        private void btn_retour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Acceuil Acc = new Acceuil();
            this.NavigationService.Navigate(Acc);
        }

        private void btn_entreprises_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EntList Ent = new EntList();
            this.NavigationService.Navigate(Ent);
        }

        private void btn_pays_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PaysList Pay = new PaysList();
            this.NavigationService.Navigate(Pay);
        }

        private void btn_utilisateurs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UtilList Uti = new UtilList();
            this.NavigationService.Navigate(Uti);
        }

        private void btn_villes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VillesList Vil = new VillesList();
            this.NavigationService.Navigate(Vil);
        }


        private void btn_entreprises_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Entreprises.png", UriKind.Relative));
            btn_entreprises.Source = Source;
        }

        private void btn_entreprises_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/GestionEntreprises.jpg", UriKind.Relative));
            btn_entreprises.Source = Source;
        }

        private void btn_pays_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Pays.png", UriKind.Relative));
            btn_pays.Source = Source;
        }

        private void btn_pays_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/GestionPays.jpg", UriKind.Relative));
            btn_pays.Source = Source;
        }

        private void btn_utilisateurs_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Utilisateurs.png", UriKind.Relative));
            btn_utilisateurs.Source = Source;
        }

        private void btn_utilisateurs_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonUtilisateurs.jpg", UriKind.Relative));
            btn_utilisateurs.Source = Source;
        }

        private void btn_villes_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Villes.png", UriKind.Relative));
            btn_villes.Source = Source;
        }

        private void btn_villes_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/GestionVilles.jpg", UriKind.Relative));
            btn_villes.Source = Source;
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
