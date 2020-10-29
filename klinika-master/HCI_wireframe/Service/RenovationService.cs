/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/


using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_diagram.Service
{
   public class RenovationService : bingPath, IService<Renovation>
    {
        public RenovationRepository renovationRepository;
        String b = bingPathToAppDir(@"JsonFiles\renovation.json");

        public RenovationService()
        {
            renovationRepository = new RenovationRepository(b);
        }

        public void Update(Renovation renovation)
        {
            renovationRepository.Update(renovation);
        }
      
        public void Remove(Renovation renovation)
        {
            renovationRepository.Delete(renovation.ID);
        }
      
        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();

        }
        public void New(Renovation renovation)
        {
            renovationRepository.New(renovation);
        }

        public Renovation GetByID(int ID)
        {
            return  renovationRepository.GetByID(ID);
        }
    }
}