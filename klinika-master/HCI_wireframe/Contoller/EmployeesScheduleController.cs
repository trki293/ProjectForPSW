/***********************************************************************
 * Module:  EmployeesScheduleController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.EmployeesScheduleController
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Class_diagram.Contoller
{
   public class EmployeesScheduleController : IController<Schedule>
    {
        public EmployeesScheduleService employeesScheduleService;

        public EmployeesScheduleController()
        {
            employeesScheduleService = new EmployeesScheduleService();
        }

        public void New(Schedule schedule)
        {
            employeesScheduleService.New(schedule);
        }
      
         public void Update(Schedule schedule)
         {
            employeesScheduleService.Update(schedule);
         }
      
         public void Remove(Schedule schedule)
         {
            employeesScheduleService.Remove(schedule);
         }
      
     
        public List<Schedule> GetAll()
        {
            return employeesScheduleService.GetAll();
        }

        public Shift getShiftForDoctorForSpecificDay(string date, DoctorUser doctor)
        {
            return employeesScheduleService.getShiftForDoctorForSpecificDay(date, doctor);
        }

        public Boolean isDoctorWorkingAtSpecifiedTime(string date, DoctorUser doctor, TimeSpan time)
        {
            return employeesScheduleService.isDoctorWorkingAtSpecifiedTime(date, doctor, time);
        }

        public Boolean isTimeInGoodFormat(string start, string end)
        {
            return employeesScheduleService.isTimeInGoodFormat(start, end);
        }

        public Schedule GetByID(int ID)
        {
            return employeesScheduleService.GetByID(ID);
        }
    }
}