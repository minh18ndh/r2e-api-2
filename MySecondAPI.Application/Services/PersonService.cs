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

    public IEnumerable<PersonReadDto> GetAllPerson(string? name, Gender? gender, string? birthPlace) {
    var query = _personRepository.GetAllPerson().AsQueryable();

    if (!string.IsNullOrWhiteSpace(name)) {
        query = query.Where(p =>
            $"{p.FirstName} {p.LastName}".Contains(name));
    }

    if (gender.HasValue) {
        query = query.Where(p => p.Gender == gender.Value);
    }

    if (!string.IsNullOrWhiteSpace(birthPlace)) {
        query = query.Where(p =>
            p.BirthPlace.Contains(birthPlace, StringComparison.OrdinalIgnoreCase));
    }

    return query.Select(person => _mapper.Map<PersonReadDto>(person));
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
}