using InMemoryCacheKullanimi.Domain;
using System.Collections.Generic;

namespace InMemoryCacheKullanimi.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }
}
