using Marcassin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class UtilController {

		public void InsertUtil(string Prenom, string Nom, int Age, string Email, string Linkedin, string Mdp, bool Tuteur, bool Externe, bool Valide, Entreprise Ent, Ville Ville) {
			using (var db = new MarcassinEntities1()) {
				db.Utilisateurs.Add(new Utilisateur() { prenomUtilisateur = Prenom, nomUtilisateur = Nom, ageUtilisateur = Age, emailUtilisateur = Email,
														lienLinkedinUtilisateur = Linkedin, motDePasseUtilisateur = Mdp, estTuteur = Tuteur, estExterne = Externe, estValide = Valide, Entreprise = Ent, Ville = Ville});
				db.SaveChanges();
			}
		}

		public void ModifyUtil(int Id, string Prenom, string Nom, int Age, string Email, string Linkedin, string Mdp, bool? Tuteur, bool? Externe, bool? Valide, Entreprise Ent, Ville Ville) {
			using (var db = new MarcassinEntities1()) {
				Utilisateur b = db.Utilisateurs.Find(Id);
				b.prenomUtilisateur = Prenom;
				b.nomUtilisateur = Nom;
				b.ageUtilisateur = Age;
				b.emailUtilisateur = Email;
				b.lienLinkedinUtilisateur = Linkedin;
				b.motDePasseUtilisateur = Mdp;
				b.estTuteur = Tuteur.Value;
				b.estExterne = Externe.Value;
				b.estValide = Valide.Value;
				b.Entreprise = db.Entreprises.Find(Ent.id_Entreprise);
				b.Ville = db.Villes.Find(Ville.id_Ville);
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprUtil(Utilisateur a) {
			using (var db = new MarcassinEntities1()) {
				Utilisateur b = db.Utilisateurs.Find(a.idUtilisateur);
				db.Utilisateurs.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
