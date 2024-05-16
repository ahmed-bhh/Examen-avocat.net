using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Client
    {
        [Key]

        public int CIN { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }

    }
}
