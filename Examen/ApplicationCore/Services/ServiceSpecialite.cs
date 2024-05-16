using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceSpecialite : Service<Specialite>, IServiceSpecialite
    {
        public ServiceSpecialite(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Specialite maxavocats()
        {
            return null;
           //return GetMany(s => s.Avocats).GroupBy(s => s.NomSpecialite).Select(s => new {s.Key,total=s.Count()}).OrderByDescending(s => s.total).FirstOrDefault();
        }
    }
}
