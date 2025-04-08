using AutoMapper;
using MySecondAPI.Application.DTOs;
using MySecondAPI.Domain.Entities;

namespace MySecondAPI.Application.Mappings;

public class PersonMappingProfile : Profile {
    public PersonMappingProfile() {
        // Map CreateDto to Person (used when creating)
        CreateMap<PersonCreateDto, Person>();

        // Map UpdateDto to Person (used when updating)
        CreateMap<PersonUpdateDto, Person>();

        // Map Person to ReadDto (used when returning to client)
        CreateMap<Person, PersonReadDto>();
    }
}