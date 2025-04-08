using MySecondAPI.Domain.Entities;

namespace MySecondAPI.Application.Interfaces.Repositories;

public interface IPersonRepository 
{
    IEnumerable<Person> GetAllPerson();
    Person? GetPersonById(Guid id);
    Person? AddPerson(Person person);
    bool UpdatePerson(Person person);
    bool DeletePerson(Guid id);
}