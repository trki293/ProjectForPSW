﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_diagram.Model.Patient;

namespace HCI_wireframe.Contoller
{
    public interface IController<T> where T : Entity
    {
         List<T> GetAll();

         void New(T entity);

         void Update(T entity);

        T GetByID(int ID);

        void Remove(T entity);
       
    }
}
