using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    internal interface IServiceSpecialite : IService<Specialite>
    {
        Specialite maxavocats();
    }
}
