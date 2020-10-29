/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Model.Secretary;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Class_diagram.Service
{
    public class SecretaryService : AbstractUserService<SecretaryUser>
    {
        public EmployeesScheduleRepository employeesScheduleRepository;
        public SecretaryRepository secretaryRepository;
        String path = bingPathToAppDir(@"JsonFiles\secretary.json");
        String path2 = bingPathToAppDir(@"JsonFiles\schedule.json");

        public SecretaryService()
        {
            secretaryRepository = new SecretaryRepository(path);
            employeesScheduleRepository = new EmployeesScheduleRepository(path2);
        }
        public override List<SecretaryUser> GetAll()
        {
            return secretaryRepository.GetAll();
        }

        public override bool New(SecretaryUser secretary)
        {
            if (isDataValid(secretary.Email, secretary.UniqueCitizensIdentityNumber,secretary) && isCityValid(secretary.city))
            {
                secretaryRepository.New(secretary);
                return true;
            }
            return false;
        }

        public override bool Update(SecretaryUser secretary)
        {
            if (isDataValid(secretary.Email, secretary.UniqueCitizensIdentityNumber,secretary) && isCityValid(secretary.city))
            {
                secretaryRepository.Update(secretary);
                return true;
            }
            return false;
        }

        public override SecretaryUser GetByID(int ID)
        {
            return secretaryRepository.GetByID(ID);
        }

        public override void Remove(SecretaryUser secretary)
        {
            removeSecretaryFromSchedule(secretary);
            secretaryRepository.Delete(secretary.ID);
        }


        private Boolean isScheduleForSecretary(Schedule schedule, SecretaryUser secretaryUser)
        {
            if(schedule.employeeFirst.Equals(secretaryUser.FirstName))
            {
                return true;
            }
            return false;
        }

        private void findAndDeleteScheduleForSecretary(SecretaryUser secretaryUser)
        {
            List<Schedule> listOfSchedule = new List<Schedule>();
            listOfSchedule = employeesScheduleRepository.GetAll();

            foreach (Schedule schedule in listOfSchedule)
            {

                if (isScheduleForSecretary(schedule, secretaryUser))
                {
                    employeesScheduleRepository.Delete(schedule.ID);

                }
            }
        }

        private Boolean areSecreatariesEqualByID(SecrearyUser firstSecretary, SecrearyUser secondSecretary)
        {
            if(firstSecretary.ID.ToString().Equals(secondSecretary.ID.ToString()))
            {
                return true;
            }
            return false;
        }

        public void removeSecretaryFromSchedule(SecretaryUser secretary)
        {
           
            List<SecretaryUser> listOfSecretaries = secretaryRepository.GetAll();

            foreach (SecretaryUser secretaryUser in listOfSecretaries)
            {

                if (areSecreatariesEqualByID(secretaryUser, secretary))
                {

                    findAndDeleteScheduleForSecretary(secretaryUser);

                }
            }

        }

     
    }
}