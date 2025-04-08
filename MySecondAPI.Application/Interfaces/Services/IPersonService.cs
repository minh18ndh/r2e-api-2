using MySecondAPI.Application.DTOs;
using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Application.Interfaces.Services;

public interface IPersonService {
    IEnumerable<PersonReadDto> GetAllPerson();
    PersonReadDto? AddPerson(PersonCreateDto? dto);
    bool UpdatePerson(Guid id, PersonUpdateDto? dto);
    bool DeletePerson(Guid id);
    IEnumerable<PersonReadDto> FilterPersonByName(string name);
    IEnumerable<PersonReadDto> FilterPersonByGender(Gender gender);
    IEnumerable<PersonReadDto> FilterPersonByBirthPlace(string birthPlace);
}