//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marcassin.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cour()
        {
            this.Relation_TCN = new HashSet<Relation_TCN>();
            this.Utilisateurs = new HashSet<Utilisateur>();
        }
    
        public int idCours { get; set; }
        public string nomCours { get; set; }
        public System.DateTime dateCours { get; set; }
        public bool estFinit { get; set; }
        public int ref_ChatRoom { get; set; }
        public int ref_Competence { get; set; }
    
        public virtual ChatRoom ChatRoom { get; set; }
        public virtual Competence Competence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Relation_TCN> Relation_TCN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
