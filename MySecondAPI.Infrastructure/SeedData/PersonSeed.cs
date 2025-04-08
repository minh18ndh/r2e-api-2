using MySecondAPI.Domain.Entities;
using MySecondAPI.Domain.Enums;

namespace MySecondAPI.Infrastructure.SeedData;

public static class PersonSeed 
{
    public static List<Person> GetPreconfiguredPeople() 
    {
        return new List<Person> 
        {
            new Person 
            {
                Id = Guid.NewGuid(),
                FirstName = "Kiet",
                LastName = "Tran",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Gender = Gender.Male,
                BirthPlace = "Hanoi"
            },
            new Person 
            {
                Id = Guid.NewGuid(),
                FirstName = "Minh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(2003, 12, 5),
                Gender = Gender.Female,
                BirthPlace = "Da Nang"
            },
            new Person 
            {
                Id = Guid.NewGuid(),
                FirstName = "Paul",
                LastName = "Smith",
                DateOfBirth = new DateOnly(2000, 6, 21),
                Gender = Gender.Other,
                BirthPlace = "Quang Binh"
            }
        };
    }
}