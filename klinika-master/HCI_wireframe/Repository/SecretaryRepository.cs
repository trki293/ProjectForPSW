/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using Class_diagram.Model.Secretary;
using System;

namespace Class_diagram.Repository
{
   public class SecretaryRepository : GenericFileRepository<SecretaryUser>
   {
        public SecretaryRepository(string filePath) : base(filePath) { }

        public SecretaryRepository() : base() { }

    }
}