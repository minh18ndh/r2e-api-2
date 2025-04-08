using MySecondAPI.Application.DTOs;
using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Application.Interfaces.Services;

public interface IPersonService 
{
    IEnumerable<PersonReadDto> GetAllPerson(string? name, Gender? gender, string? birthPlace);
    PersonReadDto? AddPerson(PersonCreateDto? dto);
    bool UpdatePerson(Guid id, PersonUpdateDto? dto);
    bool DeletePerson(Guid id);
}