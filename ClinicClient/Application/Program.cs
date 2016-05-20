using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.Core;
using Microsoft.Practices.Unity;

namespace ClinicClient
{
    public static class UserInfo
    {
        public static SessionTokenInfo sessionTokenInfo;
    }
    public class Program
    {
        public static UnityContainer unityContainer;
        static void Main(string[] args)
        {
            unityContainer = new UnityContainer();
            UnityConfig.Initialize(unityContainer);
            UserInfo.sessionTokenInfo = unityContainer.Resolve<Authorization>("authorization").Authorize();
            if (UserInfo.sessionTokenInfo != null)
            {
                switch (UserInfo.sessionTokenInfo.Role)
                {
                    case "Admin":
                        Console.WriteLine("Роль администратор");
                        Admin adminService = unityContainer.Resolve<Admin>();
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
