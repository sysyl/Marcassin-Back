using Marcassin.Model;
using Marcassin.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Marcassin.Controller {
	class EntrepriseController {

		public void InsertEnt(string Nom, Ville Ville) {
			using(var db = new MarcassinEntities1()) {
				db.Entreprises.Add(new Entreprise() {nomEntreprise = Nom, Ville = Ville });
				db.SaveChanges();
			}
		}

		public void ModifyEnt(int Id, string Nom, Ville Ville) {
			using (var db = new MarcassinEntities1()) {
				Entreprise b = db.Entreprises.Find(Id);
				b.nomEntreprise = Nom;
				b.Ville = db.Villes.Find(Ville.id_Ville);
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprEnt(Entreprise a) {
			using (var db = new MarcassinEntities1()) {
				Entreprise b = db.Entreprises.Find(a.id_Entreprise);
				db.Entreprises.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
