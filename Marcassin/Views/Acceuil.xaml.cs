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
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page
    {

        public Acceuil()
        {
            InitializeComponent();
        }

        private void btn_utilisateurs_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Utilisateurs Uti = new Utilisateurs();
            this.NavigationService.Navigate(Uti);
        }

        private void btn_cours_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Cours Cou = new Cours();
            this.NavigationService.Navigate(Cou);
        }

        private void btn_langues_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LanguesList Lang = new LanguesList();
            this.NavigationService.Navigate(Lang);
        }

        private void btn_admins_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AdminList Admin = new AdminList();
            this.NavigationService.Navigate(Admin);
        }

        private void btn_badges_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BadgeList bad = new BadgeList();
            this.NavigationService.Navigate(bad);
        }

        private void btn_competences_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CompList Comp = new CompList();
            this.NavigationService.Navigate(Comp);
        }


        Thickness ThicknessMouseEnter()
        {
			Thickness myThicknessEnter = new Thickness {
				Bottom = 1,
				Left = 2,
				Right = -2,
				Top = -1
			};

			return myThicknessEnter;
        }

        Thickness ThicknessMouseLeave()
        {
			Thickness myThicknessLeave = new Thickness {
				Bottom = 0,
				Left = 0,
				Right = 0,
				Top = 0
			};

			return myThicknessLeave;
        }


        private void btn_admins_MouseEnter(object sender, MouseEventArgs e)
        {  
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Admins.png", UriKind.Relative));
            btn_admins.Source = Source;
        }

        private void btn_admins_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonAdmins.jpg", UriKind.Relative));
            btn_admins.Source = Source;
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

        private void btn_badges_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Badges.png", UriKind.Relative));
            btn_badges.Source = Source;
        }

        private void btn_badges_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonBadges.jpg", UriKind.Relative));
            btn_badges.Source = Source;
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

        private void btn_competences_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Competences.png", UriKind.Relative));
            btn_competences.Source = Source;
        }

        private void btn_competences_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonCompetences.jpg", UriKind.Relative));
            btn_competences.Source = Source;
        }

        private void btn_langues_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/Langues.png", UriKind.Relative));
            btn_langues.Source = Source;
        }

        private void btn_langues_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage Source = new BitmapImage(new Uri("../Ressources/BoutonLangues.jpg", UriKind.Relative));
            btn_langues.Source = Source;
        }
    }
}
