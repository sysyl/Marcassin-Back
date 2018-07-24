using Marcassin.Model;
using Marcassin.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class BadgeController {
		public void InsertBadge(string Nom, Langue Lang) {
			using (var db = new MarcassinEntities1()) {
				db.Badges.Add(new Badge() { nomBadge = Nom, Langue = Lang });
				db.SaveChanges();
			}
		}

		public void ModifyBadge(int Id, string Nom, Langue Lang) {
			using (var db = new MarcassinEntities1()) {
				Badge b = db.Badges.Find(Id);
				b.nomBadge = Nom;
				b.Langue = db.Langues.Find(Lang.idLangue);
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprBadge(Badge a) {
			using (var db = new MarcassinEntities1()) {
				Badge b = db.Badges.Find(a.id_Badge);
				foreach (var util in db.Utilisateurs.ToList()) {
					if (util.Badges.Where(m => m.id_Badge == b.id_Badge).Any() ) {
						Erreur er = new Erreur("Veuillez d'abord supprimer le badge ");
						er.Show();
					} else {
						db.Badges.Remove(b);
						db.SaveChanges();
					}
				}
			}
		}
	}
}
