using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceDossier : Service<Dossier>, IDossierService
    {
        public ServiceDossier(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICollection<Client> returnclientsbyAvocat(Avocat avocat)
        {
           return GetMany(d=>d.Avocat==avocat && d.DateDepot.Day>DateTime.Now.Day-10).Select(c=>c.Client).ToList();
        }
        public int GroupingsBySpecialite()
        {
            return GetMany().GroupBy(s => s.Avocat.Specialite).Count();
        }
    }
}
