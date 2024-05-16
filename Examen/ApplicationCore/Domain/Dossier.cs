using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    [PrimaryKey(nameof(DateDepot), nameof(Client_FK), nameof(Avocat_FK))]
    public class Dossier
    {
        [Key]
        [DataType(DataType.DateTime)]

        public DateTime DateDepot { get; set; }
        [DataType(DataType.MultilineText)]

        public string description { get; set; }
        public double frais { get; set; }
        public Boolean clos { get; set; }
        public virtual Avocat   Avocat { get; set; }
        [ForeignKey("Avocat")]
        public int Avocat_FK { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("Client")]
        public int Client_FK { get; set; }
    }
}
