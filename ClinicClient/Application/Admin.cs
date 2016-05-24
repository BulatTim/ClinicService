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

namespace ClinicClient
{
    public class Admin
    {
        private readonly IClinicService _clinicServiceClient;

        public Admin(IClinicService clinicServiceClient)
        {
            _clinicServiceClient = clinicServiceClient;
        }
        /// <summary>
        /// Does actions with database for role 'Admin'.
        /// </summary>
        public void ChooseOperation()
        {
            for (; ; )
            {
                Console.WriteLine("Выбирите действие");
                Console.WriteLine();
                Console.WriteLine("1-Просмотр врачей");
                Console.WriteLine("2-Действия с талонами");
                Console.WriteLine("3-Добавить врача");
                Console.WriteLine("4-Добавить специальность");
                Console.WriteLine("5-Просмотр посещений врача");
                Console.WriteLine("6-Просмотр посещений врача пациентом");
                Console.WriteLine("0-Выход");
                int action;
                try
                {
                    action = Int32.Parse(Console.ReadLine());
                }

                catch (FormatException)
                {
                    Console.WriteLine("Действие не распознано");
                    continue;
                }
                var commonAction = Program.unityContainer.Resolve<CommonAction>();
                var admin = Program.unityContainer.Resolve<Admin>();
                    switch (action)
                    {

                        case 1:
                            Console.WriteLine("Все врачи");
                            commonAction.ShowAllDoctors();
                            break;
                        case 2:
                            commonAction.DoActionWithTickets();
                            break;
                        case 3:
                            admin.AddDoctor();
                            break;
                        case 4:
                            admin.AddSpeciality();
                            break;
                        case 5:
                            GetDoctorVisits();
                            break;
                        case 6:
                            GetPatientVisits();
                            break;
                        case 0:
                            var authorization = Program.unityContainer.Resolve<Authorization>();
                            authorization.LogOut(CurrentUserInfo.sessionTokenInfo);
                            return;
                        default:
                            Console.WriteLine("Действие не распознано");
                            break;

                    }
                
                   
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
            var action = Int32.Parse(Console.ReadLine());
            switch(action)
            {
                case 1:
                    Console.WriteLine("Введите новую специальность");
                    var speciality = Console.ReadLine();
                    if(_clinicServiceClient.AddSpeciality(speciality, CurrentUserInfo.sessionTokenInfo.Guid))
                    {
                        Console.WriteLine("Специальность добавлена");
                    }
                    return;
                case 2:
                    return;
                default:
                    Console.WriteLine("Действие не распознано");
                    break;
            }
                
        }
        /// <summary>
        /// Adds new doctor in database.
        /// </summary>
        public void AddDoctor()
        {
            List<SpecialityInfo> specialityInfoList = _clinicServiceClient.GetSpecialities(CurrentUserInfo.sessionTokenInfo.Guid);
            for (int i = 1; i <= specialityInfoList.Count; i++)
            {
                Console.WriteLine("{0} {1}", i, specialityInfoList[i - 1].Title);
            }
            Console.WriteLine("Выберите специальноть нового врача");
            var specialityNumber = Int32.Parse(Console.ReadLine());
            var specialityInfo = specialityInfoList[specialityNumber-1];
            var doctorInfo = new DoctorInfo();
            Console.WriteLine("Введите фамилию");
            doctorInfo.LastName = Console.ReadLine();
            Console.WriteLine("Введите имя");
            doctorInfo.FirstName = Console.ReadLine();
            Console.WriteLine("Введите кабинет");
            doctorInfo.Room = Console.ReadLine();
            doctorInfo.AddressInfo = new CommonAction(_clinicServiceClient).SetAddress();
            doctorInfo.specialityInfo = specialityInfo;
            if(_clinicServiceClient.AddDoctor(doctorInfo,CurrentUserInfo.sessionTokenInfo.Guid))
            {
                Console.WriteLine("Врач добавлен");
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
            var specialityNumber = Int32.Parse(Console.ReadLine());
            var doctors = docrotsList.Where(d => d.specialityInfo.Title == groups[specialityNumber - 1]).ToList();
            var speciality = doctors.First().specialityInfo.Title;
            Console.WriteLine(speciality[speciality.Length - 1] == 'г' ? speciality + 'и' : speciality + 'ы');
            for (var i = 1; i <= doctors.Count(); i++)
            {
                Console.WriteLine("{0} {1} {2}", i, doctors[i - 1].FirstName, doctors[i - 1].LastName);
            }
            Console.WriteLine("Выберите доктора");
            var doctorNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("1-Выбрать на дату");
            Console.WriteLine("2-Выбрать за период");
            var action = Int32.Parse(Console.ReadLine());
            switch(action)
            {
                case 1:
                    Console.WriteLine("Введите дату (гггг.мм.дд)");
                    var date = DateTime.Parse(Console.ReadLine());
                    var ticketInfoList = _clinicServiceClient.GetDoctorVisits(doctors[doctorNumber - 1].Id, date, CurrentUserInfo.sessionTokenInfo.Guid);
                    var visitList=ticketInfoList.GroupBy(t => t.DateTime.Date).ToList();
                    Console.WriteLine("------------------------------------------------------");
                    foreach (var d in visitList)
                    {
                        Console.WriteLine("Дата: {0} Количество посещений: {1}",d.Key.ToShortDateString(),d.Count());
                        foreach(var v in d)
                        {
                            Console.WriteLine("{0}{1} {2}","     ",v.PatientInfo.FirstName,v.PatientInfo.FirstName);
                        }
                        Console.WriteLine("------------------------------------------------------");
                    }
                    Console.WriteLine("------------------------------------------------------");
                    break;
                case 2:
                    Console.WriteLine("Введите дату начала периода (гггг.мм.дд)");
                    var beginDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату конца периода (гггг.мм.дд)");
                    var endDate = DateTime.Parse(Console.ReadLine());

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
        /// <summary>
        /// Shows all patient's visits to doctor.
        /// </summary>
        public void GetPatientVisits()
        {
            var patientInfo = new CommonAction(_clinicServiceClient).GetMedicalRecords();
            var ticketInfoList = _clinicServiceClient.GetPatientVisits(patientInfo.Id, CurrentUserInfo.sessionTokenInfo.Guid);

            var periodTicketInfoList = ticketInfoList.GroupBy(x => x.DateTime.Date);
            Console.WriteLine("------------------------------------------------------");
            foreach(var visitDate in periodTicketInfoList)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Дата: {0}", visitDate.Key.Date.ToShortDateString());
                foreach (var ticket in visitDate)
                {
                    Console.WriteLine("{0} {1} {2}", "     ",ticket.DoctorInfo.LastName, ticket.DoctorInfo.specialityInfo.Title);
                }
            }
            
        }
    }
}
