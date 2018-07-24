using Marcassin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcassin.Controller {
	class ChatController {

		public void InsertChat(string Nom) {
			using (var db = new MarcassinEntities1()) {
				db.ChatRooms.Add(new ChatRoom() { nomduRoom = Nom});
				db.SaveChanges();
			}
		}

		public void ModifyChat(int Id, string Nom) {
			using (var db = new MarcassinEntities1()) {
				ChatRoom b = db.ChatRooms.Find(Id);
				b.nomduRoom = Nom;
				db.Entry(b).State = EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void SupprChat(ChatRoom a) {
			using (var db = new MarcassinEntities1()) {
				ChatRoom b = db.ChatRooms.Find(a.idChatRoom);
				db.ChatRooms.Remove(b);
				db.SaveChanges();
			}
		}
	}
}
