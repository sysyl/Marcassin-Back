using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Marcassin.Model;
using Marcassin.Views;

namespace Marcassin.Controller {
	class LangueController {

		public void InsertLangue(string Nom) {
			using (var db = new MarcassinEntities1()) {
				db.Langues.Add(new Langue() { nomLangue = Nom});
				db.SaveChanges();
			}
		}

		public void ModifyLangue(int Id, string Nom) {
			using (var db = new MarcassinEntities1()) {
				Langue b = db.Langues.Find(Id);
				b.nomLangue = Nom;
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprLangue(Langue a) {
			using (var db = new MarcassinEntities1()) {
				Langue b = db.Langues.Find(a.idLangue);
				db.Langues.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
