using Marcassin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class CompetenceController {

		public void InsertComp(string Nom, bool? Actif, Langue Lang) {
			using (var db = new MarcassinEntities1()) {
				bool estact;
				if (Actif == null) {
					estact = false;
				}else {
					estact = true;
				}
				db.Competences.Add(new Competence() { nomCompetence = Nom, estActif = estact, Langue = Lang });
				db.SaveChanges();
			}
		}

		public void ModifyComp(int Id, string Nom, bool? Actif, Langue Lang) {
			using (var db = new MarcassinEntities1()) {
				Competence b = db.Competences.Find(Id);
				b.nomCompetence = Nom;
				b.estActif = Actif.Value;
				b.Langue = db.Langues.Find(Lang.idLangue);
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprComp(Competence a) {
			using (var db = new MarcassinEntities1()) {
				Competence b = db.Competences.Find(a.idCompetence);
				db.Competences.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
