using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Clinic.Bisuness.Services.DAL;
using Clinic.Bisuness.Services.Implementation;
using Clinic.DTO;

namespace Clinic.Bisuness.Services.Classes
{
    

    public  static class DBHelper
    {     

        public static T Execute<T>(Func<ClinicContext, T> func, Guid guid)
        {

                if (!ValidationService.IsValidToken(guid))
                    throw new UnauthorizedAccessException("Доступ запрещен");
                using (var db = new ClinicContext())
                {
                    db.Database.Connection.Open();
                    return func(db);
                }

        }
        //public static void Execute(Action<ClinicContext> func, Guid guid)
        //{

        //    if (!ValidationService.IsValidToken(guid))
        //        throw new UnauthorizedAccessException("Доступ запрещен");
        //    using (var db = new ClinicContext())
        //    {
        //        db.Database.Connection.Open();
        //        func(db);
        //    }

        //}
    
        public static T ExecuteWithoutGuid<T>(Func<ClinicContext, T> func)
        {

            using (var db = new ClinicContext())
            {
                db.Database.Connection.Open();
                return func(db);
            }
        }
        public static void  ExecuteWithoutGuid(Action<ClinicContext> action)
        {

            using (var db = new ClinicContext())
            {
                db.Database.Connection.Open();
                action(db);
            }
        }
    }

 
}
 