using AutoMapper;
using MySecondAPI.Application.DTOs;
using MySecondAPI.Application.Interfaces.Repositories;
using MySecondAPI.Application.Interfaces.Services;
using MySecondAPI.Domain.Entities;
using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Application.Services;

public class PersonService : IPersonService {
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper) {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public IEnumerable<PersonReadDto> GetAllPerson() {
        var people = _personRepository.GetAllPerson();
        return people.Select(p => _mapper.Map<PersonReadDto>(p));
    }

    public PersonReadDto? AddPerson(PersonCreateDto? dto) {
        if (dto == null) return null;

        var person = _mapper.Map<Person>(dto);
        person.Id = Guid.NewGuid();

        _personRepository.AddPerson(person);
        return _mapper.Map<PersonReadDto>(person);
    }

    public bool UpdatePerson(Guid id, PersonUpdateDto? dto) {
        if (dto == null) return false;

        var existingPerson = _personRepository.GetPersonById(id);
        if (existingPerson == null) return false;

        _mapper.Map(dto, existingPerson);
        return _personRepository.UpdatePerson(existingPerson);
    }

    public bool DeletePerson(Guid id) {
        return _personRepository.DeletePerson(id);
    }

    public IEnumerable<PersonReadDto> FilterPersonByName(string name) {
        var result = _personRepository.GetAllPerson()
            .Where(p => $"{p.FirstName} {p.LastName}"
                .Contains(name))
            .Select(p => _mapper.Map<PersonReadDto>(p));

        return result;
    }

    public IEnumerable<PersonReadDto> FilterPersonByGender(Gender gender) {
        var result = _personRepository.GetAllPerson()
            .Where(p => p.Gender == gender)
            .Select(p => _mapper.Map<PersonReadDto>(p));

        return result;
    }

    public IEnumerable<PersonReadDto> FilterPersonByBirthPlace(string birthPlace) {
        var result = _personRepository.GetAllPerson()
            .Where(p => p.BirthPlace.Contains(birthPlace, StringComparison.OrdinalIgnoreCase))
            .Select(p => _mapper.Map<PersonReadDto>(p));

        return result;
    }
}