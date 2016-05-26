using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.ClinicWCFService;
using ClinicClient.Core;
using ClinicClient.Application;
using Microsoft.Practices.Unity;
using ClinicClient.Classes;

namespace ClinicClient
{
    public class Admin:Base
    {
        private readonly IClinicService _clinicServiceClient;
       
        public Admin(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }

        /// <summary>
        /// Does actions with database for role 'Admin'.
        /// </summary>
        public void Meth()
        {
            Console.WriteLine("meth");
        }
        public void ChooseOperation()
        {
           
            
             //commonAction = Program.unityContainer.Resolve<CommonAction>();
             //admin = Program.unityContainer.Resolve<Admin>();
             //authorization = Program.unityContainer.Resolve<Authorization>();
                        
            for (; ; )
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine();
                Console.WriteLine("1-Просмотр врачей");
                Console.WriteLine("2-Добавить врача");
                Console.WriteLine("3-Добавить специальность");
                Console.WriteLine("4-Просмотр посещений врача");
                Console.WriteLine("5-Просмотр посещений врачей пациентом");
                Console.WriteLine("0-Выход");
                var action = Validation.ValidateInput(0, 5);
                Initialize(action, "Admin");
            }
        }
        /// <summary>
        /// Adds new speciality in database.
        /// </summary>
        public void AddSpeciality()
        {
            var specialityInfoList = _clinicServiceClient.GetSpecialities(CurrentUserInfo.sessionTokenInfo.Guid);
            for(var i=1;i<=specialityInfoList.Count;i++)
            {
                Console.WriteLine("{0} {1}", i, specialityInfoList[i-1].Title);
            }
            Console.WriteLine("Добавить специальность?");
            Console.WriteLine("1-Да");
            Console.WriteLine("2-Нет");
            var action = Validation.ValidateInput(1, 2);
            switch(action)
            {
                case 1:
                    Console.WriteLine("Введите новую специальность");
                    var speciality = Validation.ValidateInput(@"^[а-я]{3,50}$",
                "Длина строки должна быть от 3 до 50 символов и содержать только буквы");
                    if(_clinicServiceClient.AddSpeciality(speciality, CurrentUserInfo.sessionTokenInfo.Guid))
                    {
                        Console.WriteLine("Специальность добавлена");
                    }
                    return;
                case 2:
                    return;
                
            }
                
        }
        /// <summary>
        /// Adds new doctor in database.
        /// </summary>
        public void AddDoctor()
        {
            var specialityInfoList = _clinicServiceClient.GetSpecialities(CurrentUserInfo.sessionTokenInfo.Guid);
            for (var i = 1; i <= specialityInfoList.Count; i++)
            {
                Console.WriteLine("{0} {1}", i, specialityInfoList[i - 1].Title);
            }
            Console.WriteLine("Выберите специальноть нового врача");
            var specialityNumber = Validation.ValidateInput(1, specialityInfoList.Count);
            var specialityInfo = specialityInfoList[specialityNumber-1];
            var doctorInfo = new DoctorInfo();
            Console.WriteLine("Введите фамилию");
            doctorInfo.LastName = Validation.ValidateInput(@"^[а-я]{3,20}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
            Console.WriteLine("Введите имя");
            doctorInfo.FirstName = Validation.ValidateInput(@"^[а-я]{3,20}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
            Console.WriteLine("Введите кабинет");
            doctorInfo.Room = Validation.ValidateInput(@"^[0-9а-я]{1,4}$",
                "Длина строки должна быть от 1 до 4 символов ");
            doctorInfo.AddressInfo = new CommonAction(_clinicServiceClient).SetAddress();
            doctorInfo.specialityInfo = specialityInfo;
            if(_clinicServiceClient.AddDoctor(doctorInfo,CurrentUserInfo.sessionTokenInfo.Guid))
            {
                Console.WriteLine("Врач добавлен");
            }
            
        }
    }
}
