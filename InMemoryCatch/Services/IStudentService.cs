using InMemoryCatchKullanimi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCatchKullanimi.Services
{
  public  interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
    }
}
