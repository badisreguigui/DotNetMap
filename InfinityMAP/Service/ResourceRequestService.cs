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
    public class ResourceRequestService : Service<resourcerequest>, IResourceRequestService
    {
        private static IDatabaseFactory DbFactory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(DbFactory);
        public ResourceRequestService():base(uof)
        {

        }

        public int GetresourceRequestNumber()
        {
            /* var adherant = utOfWork.AdherantRepository.GetById(id);
             return adherant;*/

            return this.GetAll().Count();
        }
    }
}
