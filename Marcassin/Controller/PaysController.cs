using Marcassin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class PaysController {

		public void InsertPays(string Nom) {
			using (var db = new MarcassinEntities1()) {
				db.Pays.Add(new Pay() { nomPays = Nom});
				db.SaveChanges();
			}
		}

		public void ModifyPays(int Id, string Nom) {
			using (var db = new MarcassinEntities1()) {
				Pay b = db.Pays.Find(Id);
				b.nomPays = Nom;
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprPays(Pay a) {
			using (var db = new MarcassinEntities1()) {
				Pay b = db.Pays.Find(a.id_Pays);
				db.Pays.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
