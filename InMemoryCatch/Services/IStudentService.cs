using InMemoryCacheKullanimi.Domain;
using System.Collections.Generic;

namespace InMemoryCacheKullanimi.Services
{
    public  interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
    }
}
