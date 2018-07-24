using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcassin.Model;

namespace Marcassin.Controller {
	class AdminController {

		public void InsertAdmin(string Prenom, string Nom, string Mdp) {	
			using (var db = new MarcassinEntities1()) {
				db.Admins.Add(new Admin() { prenomAdmin = Prenom, nomAdmin = Nom, motDePasseAdmin =  Mdp});
				db.SaveChanges();
			}
		}

		public void ModifyAdmin(int Id, string Prenom, string Nom, string Mdp){
			using (var db = new MarcassinEntities1()) {
				Admin b = db.Admins.Find(Id);
				b.prenomAdmin = Prenom;
				b.nomAdmin = Nom;
				b.motDePasseAdmin = Mdp;
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprAdmin(Admin a) {
			using (var db = new MarcassinEntities1()) {
				Admin b = db.Admins.Find(a.idAdmin);
				db.Admins.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
