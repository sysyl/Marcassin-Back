using Marcassin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class VilleController {

		public void InsertVille(string Nom, Pay pays) {
			using (var db = new MarcassinEntities1()) {
				db.Villes.Add(new Ville() { nomVille = Nom, Pay = pays });
				db.SaveChanges();
			}
		}

		public void ModifyVille(int Id, string Nom, Pay pays) {
			using (var db = new MarcassinEntities1()) {
				Ville b = db.Villes.Find(Id);
				b.nomVille = Nom;
				b.Pay = db.Pays.Find(pays.id_Pays);
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprVille(Ville a) {
			using (var db = new MarcassinEntities1()) {
				Ville b = db.Villes.Find(a.id_Ville);
				db.Villes.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
