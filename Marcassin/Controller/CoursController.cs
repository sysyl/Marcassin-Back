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
	class CoursController {

		public void InsertCours(string Nom, DateTime Date, bool? Finis, Competence Comp) {
			using (var db = new MarcassinEntities1()) {
				string name = Nom + " ChatRoom";
				db.ChatRooms.Add(new ChatRoom() { nomduRoom = name });
				db.SaveChanges();
				ChatRoom cr = db.ChatRooms.Where(m => m.nomduRoom == name).First();
				Cour c = new Cour() { nomCours = Nom, dateCours = Date, estFinit = Finis.Value, Competence = Comp, ChatRoom = cr };
				db.Cours.Add(c);
				db.SaveChanges();
			}
		}

		public void ModifyCours(int Id, string Nom, DateTime Date, bool? Finis, Competence Comp) {
			using (var db = new MarcassinEntities1()) {
				Cour b = db.Cours.Find(Id);
				b.nomCours = Nom;
				b.dateCours = Date;
				if (Finis == null) {
					b.estFinit = false;
				} else {
					b.estFinit = true;
				}
				b.Competence = db.Competences.Find(Comp.idCompetence);
				ChatRoom cr = db.ChatRooms.Find(b.ChatRoom.idChatRoom);
				string n = Nom + " ChatRoom";
				cr.nomduRoom = n;
				db.Entry(cr).State = EntityState.Modified;
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprCours(Cour a) {
			using (var db = new MarcassinEntities1()) {
				Cour b = db.Cours.Find(a.idCours);
				db.Cours.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
