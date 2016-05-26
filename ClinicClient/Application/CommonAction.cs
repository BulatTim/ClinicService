using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.Classes;
using ClinicClient.ClinicWCFService;
using Microsoft.Practices.Unity;

namespace ClinicClient.Application
{
   public class CommonAction
    {
        private readonly IClinicService _clinicServiceClient;

        public CommonAction(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
       /// <summary>
       /// Shows all doctors.
       /// </summary>
        public void ShowAllDoctors()
       {
           var docrotsList = _clinicServiceClient.GetAllDoctors(CurrentUserInfo.sessionTokenInfo.Guid);
           var groupList = docrotsList.GroupBy(d => d.specialityInfo.Title);
            foreach (var group in groupList)
            {
                Console.WriteLine(group.Key + ":");
                foreach (var doctor in group)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", doctor.Id, doctor.LastName, doctor.FirstName, doctor.specialityInfo.Title,doctor.Room);
                   

                }
                Console.WriteLine("_____________________________________________________________");
            }
            Console.WriteLine("------------------------------------------------------");
        }
 
       /// <summary>
       /// Creates new address.
       /// </summary>
       /// <returns></returns>
        public AddressInfo SetAddress()
       {
           for (;;)
           {
               var addressInfo = new AddressInfo();
               Console.WriteLine("Введите город");
               addressInfo.City = Validation.ValidateInput(@"^[а-я]{3,50}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
               Console.WriteLine("Введите улицу");
               addressInfo.Street = Validation.ValidateInput(@"^[а-я]{3,50}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
               Console.WriteLine("Введите номер дома");
               addressInfo.Home = Validation.ValidateInput(@"^[0-9а-я]{1,4}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
               Console.WriteLine("Введите корпус дома");
               addressInfo.HousingBody = Validation.ValidateInput(@"^[0-9а-я]{1,2}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы",true);
               Console.WriteLine("Введите номер квартиры");
               addressInfo.Apartament = Validation.ValidateInput(@"^[0-9а-я]{1,4}$",
                "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
               Console.WriteLine("1-Продолжить");
               Console.WriteLine("2-Повторить ввод");
               Console.WriteLine("3-Выйти");
               var action = Validation.ValidateInput(1, 3);
               switch (action)
               {
                   case 1:
                       return addressInfo;
                   case 2:
                       continue;
                   case 3:
                       return null;
               }

           }
       }

       /// <summary>
       /// Shows all patient's visits to doctor.
       /// </summary>
        public void GetPatientVisits()
       {
           var patientInfo = new CommonAction(_clinicServiceClient).GetMedicalRecords();
           var ticketInfoList = _clinicServiceClient.GetPatientVisits(patientInfo.Id, CurrentUserInfo.sessionTokenInfo.Guid);

           var periodTicketInfoList = ticketInfoList.GroupBy(x => x.DateTime.Date);
           Console.WriteLine("------------------------------------------------------");
           foreach (var visitDate in periodTicketInfoList)
           {
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("Дата: {0}", visitDate.Key.Date.ToShortDateString());
               foreach (var ticket in visitDate)
               {
                   Console.WriteLine("{0} {1} {2}", "     ", ticket.DoctorInfo.LastName, ticket.DoctorInfo.specialityInfo.Title);
               }
           }

       }
       /// <summary>
       /// Shows all medical cards.
       /// </summary>
       /// <returns></returns>
        public PatientInfo GetMedicalRecords()
       {

           var patientInfoList = _clinicServiceClient.GetMedicalRecords(CurrentUserInfo.sessionTokenInfo.Guid);
           Console.WriteLine("------------------------------------------------------");
           for (var i = 1; i <= patientInfoList.Count; i++)
           {
               Console.WriteLine("{0,2} {1,-10} {2,-10} {3,10} г. {4,-8} ул.{5,-10} д.{6,-3} кор.{7,1} кв.{8,-3}", i, patientInfoList[i - 1].LastName, patientInfoList[i - 1].FirstName, patientInfoList[i - 1].Birthdate.ToShortDateString(),
                   patientInfoList[i - 1].Address.City, patientInfoList[i - 1].Address.Street,
                   patientInfoList[i - 1].Address.Home, patientInfoList[i - 1].Address.HousingBody, patientInfoList[i - 1].Address.Apartament);
           }
           for (; ; )
           {
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("Выбирите медицинскую карту");
               var cardNumber = Validation.ValidateInput(1, patientInfoList.Count);
               Console.WriteLine("{0,2} {1,-10} {2,-10} {3,10} г. {4,-8} ул.{5,-10} д.{6,-3} кор.{7,1} кв.{8,-3}",
                   cardNumber,
                   patientInfoList[cardNumber - 1].LastName, patientInfoList[cardNumber - 1].FirstName,
                   patientInfoList[cardNumber - 1].Birthdate.ToShortDateString(),
                   patientInfoList[cardNumber - 1].Address.City, patientInfoList[cardNumber - 1].Address.Street,
                   patientInfoList[cardNumber - 1].Address.Home, patientInfoList[cardNumber - 1].Address.HousingBody,
                   patientInfoList[cardNumber - 1].Address.Apartament);
               Console.WriteLine("1-Продолжить");
               Console.WriteLine("2-Повторить");
               Console.WriteLine("3-Выход");
               var action = Validation.ValidateInput(1, 3);
               switch (action)
               {
                   case 1:
                       return patientInfoList[cardNumber - 1];
                   case 2:
                       continue;
                   case 3:
                       return null;
               }
           }
       }

       /// <summary>
       /// Shows all doctor's visits on date.
       /// </summary>
        public void GetDoctorVisits()
       {
           var docrotsList = _clinicServiceClient.GetAllDoctors(CurrentUserInfo.sessionTokenInfo.Guid);
           var groups = docrotsList.Select(d => d.specialityInfo.Title).Distinct().ToList();
           for (var i = 1; i <= groups.Count(); i++)
           {
               Console.WriteLine("{0} {1}", i, groups[i - 1]);
           }
           Console.WriteLine("Выберите специальность");
           var specialityNumber = Validation.ValidateInput(1, groups.Count());
           var doctors = docrotsList.Where(d => d.specialityInfo.Title == groups[specialityNumber - 1]).ToList();
           var speciality = doctors.First().specialityInfo.Title;
           Console.WriteLine(speciality[speciality.Length - 1] == 'г' ? speciality + 'и' : speciality + 'ы');
           for (var i = 1; i <= doctors.Count(); i++)
           {
               Console.WriteLine("{0} {1} {2}", i, doctors[i - 1].FirstName, doctors[i - 1].LastName);
           }
           Console.WriteLine("Выберите доктора");
           var doctorNumber = Validation.ValidateInput(1, doctors.Count());
           Console.WriteLine("1-Выбрать на дату");
           Console.WriteLine("2-Выбрать за период");
           var action = Validation.ValidateInput(1, 2);
           switch (action)
           {
               case 1:
                   Console.WriteLine("Введите дату (гггг.мм.дд)");
                   var date = Validation.ValidateInput(DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(2));
                   var ticketInfoList = _clinicServiceClient.GetDoctorVisits(doctors[doctorNumber - 1].Id, date, CurrentUserInfo.sessionTokenInfo.Guid);
                   var visitList = ticketInfoList.GroupBy(t => t.DateTime.Date).ToList();
                   Console.WriteLine("------------------------------------------------------");
                   foreach (var visitDate in visitList)
                   {
                       Console.WriteLine("Дата: {0} Количество посещений: {1}", visitDate.Key.ToShortDateString(), visitDate.Count());
                       foreach (var visit in visitDate)
                       {
                           Console.WriteLine("{0}{1} {2}", "     ", visit.PatientInfo.FirstName, visit.PatientInfo.FirstName);
                       }
                       Console.WriteLine("------------------------------------------------------");
                   }
                   Console.WriteLine("------------------------------------------------------");
                   break;
               case 2:
                   Console.WriteLine("Введите дату начала периода (гггг.мм.дд)");
                   var beginDate = Validation.ValidateInput(DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(2));
                   Console.WriteLine("Введите дату конца периода (гггг.мм.дд)");
                   var endDate = Validation.ValidateInput(DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(2));

                   var periodTicketInfoList = _clinicServiceClient.GetDoctorVisitsByPeriod(doctors[doctorNumber - 1].Id, beginDate, endDate, CurrentUserInfo.sessionTokenInfo.Guid);
                   var periodVisitList = periodTicketInfoList.GroupBy(t => t.DateTime.Date).ToList();
                   Console.WriteLine("------------------------------------------------------");
                   foreach (var visitDate in periodVisitList)
                   {
                       Console.WriteLine("Дата: {0} Количество посещений: {1}", visitDate.Key.ToShortDateString(), visitDate.Count());
                       foreach (var patient in visitDate)
                       {
                           Console.WriteLine("{0}{1} {2}", "     ", patient.PatientInfo.FirstName, patient.PatientInfo.LastName);
                       }
                       Console.WriteLine("------------------------------------------------------");
                   }
                   Console.WriteLine("------------------------------------------------------");
                   break;
               default:
                   Console.WriteLine("Действие не распознано");
                   break;
           }
           Console.WriteLine("Введите дату (гггг.мм.дд)");
       }

       //public void LogOut()
       //{
       //    var authorization = Program.unityContainer.Resolve<Authorization>();
       //    authorization.LogOut(CurrentUserInfo.sessionTokenInfo);
       //}


    }
}
