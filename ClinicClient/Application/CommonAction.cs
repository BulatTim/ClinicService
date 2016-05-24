using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Clinic.DTO;
using ClinicClient.ClinicWCFService;

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
           /// Does action with tickets
           /// </summary>
       public void DoActionWithTickets()
       {
           
           var docrotsList = _clinicServiceClient.GetAllDoctors(CurrentUserInfo.sessionTokenInfo.Guid);
           var groups = docrotsList.Select(d => d.specialityInfo.Title).Distinct().ToList();           
           for(var i=1;i<=groups.Count();i++)
           {
               Console.WriteLine("{0} {1}",i,groups[i-1]);
           }
           Console.WriteLine("Выберите специальность");
           var specialityNumber = Int32.Parse(Console.ReadLine());
           var doctors = docrotsList.Where(d => d.specialityInfo.Title == groups[specialityNumber-1]).ToList();
           var speciality = doctors.First().specialityInfo.Title;
           Console.WriteLine(speciality[speciality.Length - 1] == 'г' ? speciality + 'и' : speciality + 'ы');
           for(var i=1;i<=doctors.Count();i++)
           {
               Console.WriteLine("{0} {1} {2}", i, doctors[i-1].FirstName,doctors[i-1].LastName);
           }
           Console.WriteLine("Выберите доктора");
           var doctorNumber = Int32.Parse(Console.ReadLine());
           Console.WriteLine("Введите дату (гггг.мм.дд)");
           Console.WriteLine("------------------------------------------------------");
           var date = DateTime.Parse(Console.ReadLine());
           Console.WriteLine("------------------------------------------------------");
           Console.WriteLine("Дата приёма: {0}, врач: {1} {2} - {3}, каб. {4}", date, doctors[doctorNumber - 1].LastName, doctors[doctorNumber - 1].FirstName,
               doctors[doctorNumber - 1].specialityInfo.Title, doctors[doctorNumber - 1].Room);
           Console.WriteLine("------------------------------------------------------");
           var ticketList = _clinicServiceClient.GetTickets(doctors[doctorNumber - 1].Id, date, CurrentUserInfo.sessionTokenInfo.Guid);
           Console.WriteLine("{0,2} {1,5} {2,-26}","№","Время","         пациент");
           Console.WriteLine("------------------------------------------------------");
           for(var i=1;i<=ticketList.Count;i++)
           {
               Console.WriteLine("{0,2} {1,5} {2,-13} {3,-13}", i, ticketList[i - 1].DateTime.ToString("HH:mm"),               
                   ticketList[i - 1].PatientInfo == null ? "доступен для бронирования" : ticketList[i - 1].PatientInfo.FirstName,
                   ticketList[i - 1].PatientInfo == null ? "" : ticketList[i - 1].PatientInfo.LastName);
           }
           Console.WriteLine("------------------------------------------------------");
           for (; ; )
           {
               Console.WriteLine("Выберите действие:");
               Console.WriteLine("1-Забронировать талон");
               Console.WriteLine("2-Удалить талон");
               Console.WriteLine("0-Вернуться в главное меню");
               var actionWithTicket = Int32.Parse(Console.ReadLine());
               switch (actionWithTicket)
               {
                   case 1:
                       AddNewTicket(ticketList, doctors[doctorNumber - 1]);
                       return;
                   case 2:

                       RemoveTicket(ticketList, doctors[doctorNumber - 1]);
                       break;
                   case 0:
                       return;
                   default:
                       Console.WriteLine("Действие не распознано");
                       break;
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
           for (;;)
           {
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("Выбирите медицинскую карту");
               var cardNumber = Int32.Parse(Console.ReadLine());
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
               var action = Int32.Parse(Console.ReadLine());
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
       /// Adds new medical record.
       /// </summary>
       /// <returns></returns>
       public PatientInfo AddMedicalRecord()
       {
           for (;;)
           {
               var patientInfo = new PatientInfo();
               Console.WriteLine("Введите фамилию");
               patientInfo.LastName = Console.ReadLine();
               Console.WriteLine("Введите имя");
               patientInfo.FirstName = Console.ReadLine();
               Console.WriteLine("Введите дату рождения");
               patientInfo.Birthdate = DateTime.Parse(Console.ReadLine());
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("{0} {1} {2}", patientInfo.LastName, patientInfo.FirstName, patientInfo.Birthdate.ToShortDateString());
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("1-Продолжить");
               Console.WriteLine("2-Повторить ввод");
               var action = Int32.Parse(Console.ReadLine());
               switch (action)
               {
                   case 1:
                       break;
                   case 2:
                       continue;
               }
              
               if((patientInfo.Address = SetAddress())==null)
                    return null;
               var patientId = _clinicServiceClient.AddMedicalRecord(patientInfo, CurrentUserInfo.sessionTokenInfo.Guid);
               patientInfo.Id = patientId;
               if (patientId != 0)
               {
                   Console.WriteLine("Пациент добавлен");
                   return patientInfo;
               }
               Console.WriteLine("Такой пациент уже существует");
               return null;
           }
           
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
               addressInfo.City = Console.ReadLine();
               Console.WriteLine("Введите улицу");
               addressInfo.Street = Console.ReadLine();
               Console.WriteLine("Введите номер дома");
               addressInfo.Home = Console.ReadLine();
               Console.WriteLine("Введите корпус дома");
               addressInfo.HousingBody = Console.ReadLine();
               if (addressInfo.HousingBody == "")
               {
                   addressInfo.HousingBody = null;
               }
               Console.WriteLine("Введите номер квартиры");
               addressInfo.Apartament = Console.ReadLine();
               Console.WriteLine("1-Продолжить");
               Console.WriteLine("2-Повторить ввод");
               Console.WriteLine("3-Выйти");
               var action = Int32.Parse(Console.ReadLine());
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
           //var addressInfo = new AddressInfo();
           //Console.WriteLine("Введите город");
           //addressInfo.City = Console.ReadLine();
           //Console.WriteLine("Введите улицу");
           //addressInfo.Street = Console.ReadLine();
           //Console.WriteLine("Введите номер дома");
           //addressInfo.Home = Console.ReadLine();
           //Console.WriteLine("Введите корпус дома");
           //addressInfo.HousingBody = Console.ReadLine();
           //if (addressInfo.HousingBody == "")
           //{
           //    addressInfo.HousingBody = null;
           //}
           //Console.WriteLine("Введите номер квартиры");
           //addressInfo.Apartament = Console.ReadLine();
           //return addressInfo;
       }
       /// <summary>
       /// Adds new ticket in database.
       /// </summary>
       /// <param name="ticketList"></param>
       /// <param name="doctor"></param>
       public void AddNewTicket(List<TicketInfo> ticketList, DoctorInfo doctor)
       {
           var ticketNumber = 0;
           for (;;)
           {
               Console.WriteLine("Введите номер талона");
               ticketNumber = Int32.Parse(Console.ReadLine());
               if (ticketList[ticketNumber - 1].PatientInfo==null)
               {
                   Console.WriteLine("------------------------------------------------------");
                   Console.WriteLine("Талон №{0} дата:{1} врач: {2} {3} - {4}, каб. {5}",
                   ticketNumber, ticketList[ticketNumber - 1].DateTime.ToString("dd MMM HH:mm"), doctor.LastName,
                   doctor.FirstName, doctor.specialityInfo.Title, doctor.Room);
                   Console.WriteLine("------------------------------------------------------");
                   Console.WriteLine("1-Продолжить");
                   Console.WriteLine("2-Ввести еще раз");
                   Console.WriteLine("3-Выход");
                   var actionWithAvaliableTicket = Int32.Parse(Console.ReadLine());
                   switch (actionWithAvaliableTicket)
                   {
                       case 1:
                           break;
                       case 2:
                           continue;
                       case 3:
                           return;
                   }
                   break;
               }
               Console.WriteLine("Талон уже забронирован");
               Console.WriteLine("1-Повторить выбор талона");
               Console.WriteLine("2-Выход");
               var action = Int32.Parse(Console.ReadLine());
               switch (action)
               {
                   case 1:
                       break;
                   case 2:
                       return;
                   default:
                       Console.WriteLine("Ввод не распознан");
                       break;
               }

           }
           
           for (; ; )
           {
               Console.WriteLine("------------------------------------------------------");
               Console.WriteLine("Выберите действие:");
               Console.WriteLine("1-Выбрать медицинскую карту пациента");
               Console.WriteLine("2-Добавить медицинскую карту пациента");
               Console.WriteLine("0-Вернуться в главное меню");
               var actionWithMedicalCard = Int32.Parse(Console.ReadLine());
               var patientInfo = new PatientInfo();
               switch (actionWithMedicalCard)
               {

                   case 1:
                       patientInfo = GetMedicalRecords();
                       break;
                   case 2:
                       patientInfo = AddMedicalRecord();
                       break;
                   case 0:
                       return;
                   default:
                       break;
               }
               if(patientInfo==null)
                   continue;
               var newTicket = new TicketInfo
               {
                   DoctorInfo = new DoctorInfo { Id = doctor.Id },
                   DateTime = ticketList[ticketNumber - 1].DateTime,
                   PatientInfo = new PatientInfo { Id = patientInfo.Id }
               };
               if (_clinicServiceClient.AddTicket(newTicket, CurrentUserInfo.sessionTokenInfo.Guid))
               {
                   Console.WriteLine("------------------------------------------------------");
                   Console.WriteLine("Талон сохранен");
                   Console.WriteLine("Дата:{0} врач: {1} {2} - {3}, каб. {4}",
                   ticketList[ticketNumber - 1].DateTime, doctor.LastName,
                   doctor.FirstName, doctor.specialityInfo.Title, doctor.Room);
                   Console.WriteLine("Пациент: {0} {1}", patientInfo.LastName, patientInfo.FirstName);
                   Console.WriteLine("------------------------------------------------------");
                   return;
               }
           }                 
       }
       /// <summary>
       /// Remove ticket from database
       /// </summary>
       /// <param name="ticketList"></param>
       /// <param name="doctor"></param>
       public void RemoveTicket(List<TicketInfo> ticketList, DoctorInfo doctor)
       {
           Console.WriteLine("Введите номер талона");
           var removeTicketNumber = Int32.Parse(Console.ReadLine());
           if (ticketList[removeTicketNumber - 1].PatientInfo.FirstName == null)
           {
               Console.WriteLine("Талон не может быть удален т.к. он не забронирован");
               return;
           }
           Console.WriteLine("------------------------------------------------------");
           Console.WriteLine("Талон №{0} дата:{1} врач: {2} {3} - {4}, каб. {5}",
           removeTicketNumber, ticketList[removeTicketNumber - 1].DateTime, doctor.LastName,
           doctor.FirstName, doctor.specialityInfo.Title, doctor.Room);
           Console.WriteLine("Удалить?");
           Console.WriteLine("1-Да");
           Console.WriteLine("2-Нет");
           var action = Int32.Parse(Console.ReadLine());
           switch (action)
           {
               case 1:
                   if (_clinicServiceClient.RemoveTicket(ticketList[removeTicketNumber - 1].Id, CurrentUserInfo.sessionTokenInfo.Guid))
                   {
                       Console.WriteLine("Талон удален");
                       return;
                   }
                   break;
               case 2:
               default:
                   return;
           }
       }

       
    }
}
