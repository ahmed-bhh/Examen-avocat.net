using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IDossierService : IService<Dossier>
    {
        ICollection<Client> returnclientsbyAvocat(Avocat avocat);
        public int GroupingsBySpecialite();
    }
}
