using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Avocat
    {
        [Key]

        public int AvocatId { get; set; }
        [Required(ErrorMessage = " obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = " obligatoire")]

        public string prenom { get; set; }
        [DataType(DataType.DateTime)]

        public DateTime DateEmbauche { get; set; }

        public virtual Specialite Specialite { get; set; }

        public int SpecialiteFK { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
