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
   public class Reseption:Base
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
                Console.WriteLine("Выберите действие");
                Console.WriteLine();
                Console.WriteLine("1-Просмотр врачей");
                Console.WriteLine("2-Действия с талонами");
                Console.WriteLine("3-Просмотр посещений врача");
                Console.WriteLine("4-Просмотр посещений врачей пациентом");
                Console.WriteLine("0-Выход");
                var action = Validation.ValidateInput(0, 5);
                //DoAction(new ClinicEventArgs(action, "Reseption"));
                Initialize(action, "Reseption");
               
            }
        }
        

        /// <summary>
        /// Does action with tickets
        /// </summary>
               public void DoActionWithTickets()
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
            Console.WriteLine("Введите дату (гггг.мм.дд)");
            Console.WriteLine("------------------------------------------------------");
            var date = Validation.ValidateInput(DateTime.Now.Date, DateTime.Now.AddMonths(2));
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Дата приёма: {0}, врач: {1} {2} - {3}, каб. {4}", date, doctors[doctorNumber - 1].LastName, doctors[doctorNumber - 1].FirstName,
                doctors[doctorNumber - 1].specialityInfo.Title, doctors[doctorNumber - 1].Room);
            Console.WriteLine("------------------------------------------------------");
            var ticketList = _clinicServiceClient.GetTickets(doctors[doctorNumber - 1].Id, date, CurrentUserInfo.sessionTokenInfo.Guid);
            Console.WriteLine("{0,2} {1,5} {2,-26}", "№", "Время", "         пациент");
            Console.WriteLine("------------------------------------------------------");

            //foreach (var ticket in ticketList)
            //{
            //    if (ticket.PatientInfo!=null && ticket.PatientInfo.LastName == "reserved")
            //    {
            //        ticket.PatientInfo.FirstName = "Зарезервирован";
            //        ticket.PatientInfo.LastName = "";
            //    }
            //}

            for (var i = 1; i <= ticketList.Count; i++)
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
                var actionWithTicket = Validation.ValidateInput(0, 2);
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
        /// Adds new ticket in database.
        /// </summary>
        /// <param name="ticketList"></param>
        /// <param name="doctor"></param>
        public void AddNewTicket(List<TicketInfo> ticketList, DoctorInfo doctor)
        {
            var ticketNumber = 0;
            int ticketId = 0;
            for (; ; )
            {
                Console.WriteLine("Введите номер талона");
                ticketNumber = Validation.ValidateInput(1, ticketList.Count);
                if (ticketList[ticketNumber - 1].PatientInfo == null)
                {
                    
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Талон №{0} дата:{1} врач: {2} {3} - {4}, каб. {5}",
                    ticketNumber, ticketList[ticketNumber - 1].DateTime.ToString("dd MMM HH:mm"), doctor.LastName,
                    doctor.FirstName, doctor.specialityInfo.Title, doctor.Room);
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("1-Продолжить");
                    Console.WriteLine("2-Ввести еще раз");
                    Console.WriteLine("3-Выход");
                    var actionWithAvaliableTicket = Validation.ValidateInput(1, 3);
                    switch (actionWithAvaliableTicket)
                    {
                        case 1:
                          ticketId=  _clinicServiceClient.SetReservation(ticketList[ticketNumber - 1], CurrentUserInfo.sessionTokenInfo.Guid);//create temporary ticket
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
                var action = Validation.ValidateInput(1, 2);
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
                var actionWithMedicalCard = Validation.ValidateInput(0, 2);
                var patientInfo = new PatientInfo();
                switch (actionWithMedicalCard)
                {

                    case 1:
                        patientInfo = new CommonAction(_clinicServiceClient).GetMedicalRecords();
                        break;
                    case 2:
                        patientInfo = AddMedicalRecord();
                        break;
                    case 0:
                        _clinicServiceClient.AbortReservation(ticketId);
                        return;
                }
                if (patientInfo == null)
                    continue;
                var newTicket = new TicketInfo
                {
                    Id=ticketId,
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
            var removeTicketNumber = Validation.ValidateInput(1, ticketList.Count);
            if (ticketList[removeTicketNumber - 1].PatientInfo.FirstName == null)
            {
                Console.WriteLine("Талон не может быть удален т.к. он не забронирован");
                return;
            }
            //if (ticketList[removeTicketNumber - 1].PatientInfo != null &&
            //    ticketList[removeTicketNumber - 1].PatientInfo.LastName == "reserved")
            //{
            //    Console.WriteLine("Талон не может быть удален т.к. он забронирован");
            //    return;
            //}
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Талон №{0} дата:{1} врач: {2} {3} - {4}, каб. {5}",
            removeTicketNumber, ticketList[removeTicketNumber - 1].DateTime, doctor.LastName,
            doctor.FirstName, doctor.specialityInfo.Title, doctor.Room);
            Console.WriteLine("Удалить?");
            Console.WriteLine("1-Да");
            Console.WriteLine("2-Нет");
            var action = Validation.ValidateInput(1, 2);
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

        public PatientInfo AddMedicalRecord()
        {
            for (; ; )
            {
                var patientInfo = new PatientInfo();
                Console.WriteLine("Введите фамилию");
                patientInfo.LastName = Validation.ValidateInput(@"^[а-я]{3,20}$",
                 "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
                Console.WriteLine("Введите имя");
                patientInfo.FirstName = Validation.ValidateInput(@"^[а-я]{3,20}$",
                 "Длина строки должна быть от 3 до 20 символов и содержать только буквы");
                Console.WriteLine("Введите дату рождения");
                patientInfo.Birthdate = Validation.ValidateInput(DateTime.Now.AddYears(-120), DateTime.Now.Date);
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("{0} {1} {2}", patientInfo.LastName, patientInfo.FirstName, patientInfo.Birthdate.ToShortDateString());
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1-Продолжить");
                Console.WriteLine("2-Повторить ввод");
                var action = Validation.ValidateInput(1, 2);
                switch (action)
                {
                    case 1:
                        break;
                    case 2:
                        continue;
                }

                if ((patientInfo.Address = new CommonAction(_clinicServiceClient).SetAddress()) == null)
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
    }
}
