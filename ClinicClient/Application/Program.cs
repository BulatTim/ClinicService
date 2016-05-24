using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.Application;
using ClinicClient.Core;
using Microsoft.Practices.Unity;

namespace ClinicClient
{

    public class Program
    {
        public static UnityContainer unityContainer;
        static void Main(string[] args)
        {
            unityContainer = new UnityContainer();
            UnityConfig.Initialize(unityContainer);
            CurrentUserInfo.sessionTokenInfo = unityContainer.Resolve<Authorization>("authorization").Authorize();
            if (CurrentUserInfo.sessionTokenInfo != null)
            {
                switch (CurrentUserInfo.sessionTokenInfo.Role)
                {
                    case "Admin":
                        Console.WriteLine("Роль администратор");
                        var adminService = unityContainer.Resolve<Admin>();
                        adminService.ChooseOperation();
                        break;
                    case "User":
                        break;
                    default:
                        break;
                }
            }

            
        }
    }
}
