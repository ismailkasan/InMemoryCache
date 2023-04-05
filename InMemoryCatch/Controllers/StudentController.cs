using InMemoryCacheKullanimi.Domain;
using InMemoryCacheKullanimi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InMemoryCacheKullanimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IStudentService  _studentService;
        public StudentController(
            IMemoryCache memoryCache,
            IStudentService studentService
            )
        {
            this._memoryCache = memoryCache;
            this._studentService = studentService;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            const string cacheKey = "studentListKey";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Student> response))
            {
                response = _studentService.GetAllStudents().ToList();
                var cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.Normal,
                };

                cacheExpirationOptions.RegisterPostEvictionCallback(callback: EvictionCallback, state: this);
            }
            return response;
        }

        private static void EvictionCallback(object key, object value,EvictionReason reason, object state)
        {
            var message = $"Entry was evicted. Reason: {reason}.";          
        }
    }
}