using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Domain.Entities;

public class Person {
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public required string BirthPlace { get; set; }
}