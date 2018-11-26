using Data.Infrastructure;
using Domain.Entites;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class HistoriqueService :Service<historiqueassignationmandat>, IHistoriqueService
    { private static IDatabaseFactory dbf = new DatabaseFactory();
    private static IUnitOfWork utOfWork = new UnitOfWork(dbf);
    public HistoriqueService():base(utOfWork)
        {

    }
}
}
