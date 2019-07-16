using InMemoryCatchKullanimi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace InMemoryCatchKullanimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public StudentController(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            const string cacheKey = "studentListKey";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Student> response))
            {
                response = new List<Student> { new Student { Id = Guid.NewGuid(), Name = "ismail kaşan" }, new Student { Id = Guid.NewGuid(), Name = "serkan ulukoca" } };
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