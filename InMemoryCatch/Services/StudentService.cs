using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemoryCatchKullanimi.Domain;
using InMemoryCatchKullanimi.Repository;

namespace InMemoryCatchKullanimi.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return this._studentRepository.GetAll();
        }
    }
}
