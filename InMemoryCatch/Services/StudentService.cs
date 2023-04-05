using System.Collections.Generic;
using InMemoryCacheKullanimi.Domain;
using InMemoryCacheKullanimi.Repository;

namespace InMemoryCacheKullanimi.Services
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
