using KipCodeChallengeMvcPerson.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace KipCodeChallengeMvcServices.Services
{
    public interface IPersonService
    {
        Person GetPerson(string key);
        Person SavePerson(string key, Person person);
    }

    public class PersonService : IPersonService
    {
        private readonly MemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public Person GetPerson(string key) => _memoryCache.Get<Person>(key);

        public Person SavePerson(string key, Person person) => _memoryCache.Set(key, person, TimeSpan.FromDays(7));
    }
}
