using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using System.ServiceModel;
using ClinicClient.ClinicWCFService;
using ClinicClient.Application;

namespace ClinicClient
{
    class Reseption  
    {
        private readonly IClinicService _clinicServiceClient;

        public Reseption(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
        public void ChooseOperation()
        {
            for (; ; )
            {
                Console.WriteLine("Выбирите действие");
                Console.WriteLine();
                Console.WriteLine("1-Просмотр врачей");
                Console.WriteLine("0-Выход");
                int action;
                try
                {
                    action = Int32.Parse(Console.ReadLine());
                }
                
                catch(FormatException)
                {
                    Console.WriteLine("Действие не распознано");
                    continue;
                }
                CommonAction commonAction = new CommonAction(_clinicServiceClient);
                switch(action)
                {
                    case 1:
                        Console.WriteLine("Все врачи");
                        commonAction.ShowAllDoctors();
                        
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Действие не распознано");
                        break;
                }
            }
            
            
        }
    }
}
