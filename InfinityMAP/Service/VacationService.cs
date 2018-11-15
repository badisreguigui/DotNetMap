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
    public class VacationService : Service<vacation>, IVacationService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utOfWork = new UnitOfWork(dbf);
        public VacationService():base(utOfWork)
        {

        }
    }
}
