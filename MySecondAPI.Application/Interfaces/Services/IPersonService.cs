using MySecondAPI.Application.DTOs;

namespace MySecondAPI.Application.Interfaces.Services;

public interface IPersonService {
    IEnumerable<PersonReadDto> GetAllPerson(string? name = null, string? gender = null, string? birthPlace = null);
    PersonReadDto? AddPerson(PersonCreateDto? dto);
    bool UpdatePerson(Guid id, PersonUpdateDto? dto);
    bool DeletePerson(Guid id);
}