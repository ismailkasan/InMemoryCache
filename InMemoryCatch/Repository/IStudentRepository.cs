using InMemoryCatchKullanimi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCatchKullanimi.Repository
{
   public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }
}
