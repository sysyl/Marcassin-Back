using Marcassin.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace Controller {
	public class AffichageController {

		public dynamic Afficher(string Item) {
			switch (Item) {
				case "Admins":
					return AfficherAdmin();
				case "Badge":
					return AfficherBadge();
				case "ChatRoom":
					return AfficherChatRoom();
				case "Competence":
					return AfficherCompetence();
				case "Cours":
					return AfficherCours();
				case "Entreprise":
					return AfficherEntreprise();
				case "Langue":
					return AfficherLangue();
				case "Pays":
					return AfficherPay();
				case "Utilisateur":
					return AfficherUtilisateur();
				case "Ville":
					return AfficherVille();
				default:
					return "fail";
			}
		}

		public List<Admin> AfficherAdmin() {
			using (var db = new MarcassinEntities1()) {
				List<Admin> list = db.Admins.ToList();
				return list;
			}
		}

		public List<Badge> AfficherBadge() {
			using (var db = new MarcassinEntities1()) {
				return db.Badges.Include("Langue").ToList();
			}
		}

		public List<Cour> AfficherChatRoom() {
			using (var db = new MarcassinEntities1()) {
				List<Cour> list = db.Cours.Include("ChatRoom").ToList();
				return list;
			}
		}

		public List<Competence> AfficherCompetence() {
			using (var db = new MarcassinEntities1()) {
				return db.Competences.Include("Langue").ToList();
			}
		}

		public List<Cour> AfficherCours() {
			using (var db = new MarcassinEntities1()) {
				return db.Cours.Include("Competence").Include("ChatRoom").ToList();
				
			}
		}

		public List<Entreprise> AfficherEntreprise() {
			using (var db = new MarcassinEntities1()) {
				return db.Entreprises.Include("Ville").ToList();
			}
		}

		public List<Langue> AfficherLangue() {
			using (var db = new MarcassinEntities1()) {
				return db.Langues.ToList();
			}
		}

		public List<Pay> AfficherPay() {
			using (var db = new MarcassinEntities1()) {
				return db.Pays.ToList();
			}
		}

		public List<Utilisateur> AfficherUtilisateur() {
			using (var db = new MarcassinEntities1()) {
				return db.Utilisateurs.Include("Ville").Include("Entreprise").ToList();
			}
		}

		public List<Ville> AfficherVille() {
			using (var db = new MarcassinEntities1()) {
				return db.Villes.Include("Pay").ToList();
			}
		}
	}
}
