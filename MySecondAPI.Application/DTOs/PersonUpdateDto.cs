using System.ComponentModel.DataAnnotations;
using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Application.DTOs;

public class PersonUpdateDto 
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    [DateOfBirthRange]
    public DateOnly DateOfBirth { get; set; }

    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    
    [Required]
    public required string BirthPlace { get; set; }
}