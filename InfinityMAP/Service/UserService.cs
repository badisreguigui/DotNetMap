using Data.Infrastructure;
using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : Service<Utilisateur>, IUserService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utOfWork = new UnitOfWork(dbf);
        public UserService():base(utOfWork)
        {

        }
    }
}
