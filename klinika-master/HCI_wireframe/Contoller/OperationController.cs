/***********************************************************************
 * Module:  OperationController.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Contoller.OperationController
 ***********************************************************************/
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Service;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;
namespace Class_diagram.Contoller
{
    public class OperationController 
    {
        public OperationService operationService;
        public ContextAppointmentService contextAppointmentService;

        public OperationController()
        {
            operationService = new OperationService();
            contextAppointmentService = new ContextAppointmentService(operationService);
        }

        public List<Operation> GetAll()
        {
            return operationService.GetAll();
        }

        public Operation GetByID(int id)
        {
            return operationService.GetByID(id);
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            contextAppointmentService.New(appointment, operation);
        }

        public void Remove(int appointmentID, int operationID)
        {
            contextAppointmentService.Remove(appointmentID, operationID);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            contextAppointmentService.Update(appointment, operation);
        }

        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan start, TimeSpan end, String dateToString, PatientUser patient)
        {
            return operationService.isTermNotAvailable( doctor, start, end, dateToString,patient);
        }
      

    }
}