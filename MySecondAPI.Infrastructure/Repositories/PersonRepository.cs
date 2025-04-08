using MySecondAPI.Domain.Entities;
using MySecondAPI.Infrastructure.SeedData;
using MySecondAPI.Application.Interfaces.Repositories;

namespace MySecondAPI.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository {
    private readonly List<Person> _people;

    public PersonRepository() {
        _people = PersonSeed.GetPreconfiguredPeople();
    }
    
    public IEnumerable<Person> GetAllPerson() => _people;

    public Person? GetPersonById(Guid id) => _people.FirstOrDefault(p => p.Id == id);

    public Person AddPerson(Person person) {
        _people.Add(person);
        return person;
    }

    public bool UpdatePerson(Person person) {
        var index = _people.FindIndex(p => p.Id == person.Id);
        if (index == -1) return false;

        _people[index] = person;
        return true;
    }

    public bool DeletePerson(Guid id) {
        var person = GetPersonById(id);
        if (person == null) return false;

        _people.Remove(person);
        return true;
    }
}