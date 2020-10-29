/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using Class_diagram.Model.Employee;
using Class_diagram.Model.Manager;
using Class_diagram.Repository;
using HCI_wireframe.Model.Employee;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Xceed.Wpf.Toolkit;

namespace Class_diagram.Service
{
   public class ManagerService : AbstractUserService<ManagerUser>
    {
        public ManagerRepository managerRepository;
        public const int UPDATE_MANAGER = 0;
        public const int NEW_MANAGER = 1;

        String path = bingPathToAppDir(@"JsonFiles\manager.json");

        public ManagerService()
        {
            managerRepository = new ManagerRepository(path);
        }


     
      

        public override List<ManagerUser> GetAll()
        {
            return managerRepository.GetAll();
        }

        private bool createManagerIfDateIsValid(ManagerUser manager)
        {
            if (isDataValid(manager.Email, manager.UniqueCitizensIdentityNumber, manager) && isCityValid(manager.city))
            {
                managerRepository.New(manager);
                return true;
            }
            return false;
        }
        

        public override Boolean New(ManagerUser manager)
        {
            return createManagerIfDateIsValid(manager);
        }

        private bool updateManagerIfDataIsValid(ManagerUser manager)
        {
            if (isDataValid(manager.Email, manager.UniqueCitizensIdentityNumber, manager) && isCityValid(manager.city))
            {
                managerRepository.Update(manager);
                return true;
            }
            return false;
        }

        public override bool Update(ManagerUser manager)
        {
            return updateManagerIfDataIsValid(manager);
        }

        public override ManagerUser GetByID(int ID)
        {
            return managerRepository.GetByID(ID);
        }

        public override void Remove(ManagerUser manager)
        {
            managerRepository.Delete(manager.ID);
        }
    }
}