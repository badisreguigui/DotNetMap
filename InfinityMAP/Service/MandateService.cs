
using Data.Infrastructure;
using Domain.Entites;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
   public class MandateService:Service<mandate>,IMandateService
    {
        private static IDatabaseFactory DbFactory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(DbFactory);
        public MandateService():base(uof)
        {

        }
    }
}
