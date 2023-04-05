using InMemoryCacheKullanimi.Domain;
using System;
using System.Collections.Generic;

namespace InMemoryCacheKullanimi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAll()
        {
            return new List<Student>
            {
                new Student { Id = Guid.NewGuid(), Name = "Student-1" },
                new Student {  Id = Guid.NewGuid(), Name = "Student-2" }
            };
        }
    }   
}
