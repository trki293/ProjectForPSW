/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
namespace Class_diagram.Service
{
    public class OperationService : bingPath, IStrategyAppointment
    {
        public OperationRepository operationRepository;
        String path = bingPathToAppDir(@"JsonFiles\operations.json");

        public OperationService()
        {
            operationRepository = new OperationRepository(path);
        }

        public List<Operation> GetAll()
        {
            return operationRepository.GetAll();
        }

        public Operation GetByID(int id)
        {
            return operationRepository.GetByID(id);
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            operationRepository.New(operation);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            operationRepository.Update(operation);
        }

        public void Remove(int appointmentID, int operationID)
        {
            operationRepository.Delete(operationID);
        }
        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan start,TimeSpan end , String dateToString, PatientUser patient)
        {
            PatientController patientController = new PatientController();
            DoctorController doctorController = new DoctorController();
            Boolean hasAppointmentDoctor = doctorController.doesDoctorHaveAnAppointmentAtSpecificPeriod(doctor, start, end,dateToString);
            Boolean hasOperationDoctor = doctorController.doesDoctorHaveAnOperationAtSpecificPerod(doctor, start, end,dateToString);
            Boolean hasAppointmentPatient = patientController.doesPatientHaveAnAppointmentAtSpecificPeriod(start, end,dateToString, patient);
            Boolean hasOperationPatient = patientController.doesPatientHaveAnOperationAtSpecificPeriod(start,end,dateToString, patient);
            
            if (hasAppointmentDoctor || hasAppointmentPatient || hasOperationDoctor || hasOperationPatient)
            {
                return true;
            }
            return false;
        }
       

    }
}