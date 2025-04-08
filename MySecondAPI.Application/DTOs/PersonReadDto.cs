using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Application.DTOs;

public class PersonReadDto {
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public required string BirthPlace { get; set; }
}