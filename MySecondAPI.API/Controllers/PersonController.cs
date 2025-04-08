using Microsoft.AspNetCore.Mvc;
using MySecondAPI.Application.DTOs;
using MySecondAPI.Domain.Enums;
using MySecondAPI.Application.Interfaces.Services;

namespace MySecondAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase 
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) 
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAllPerson(
        [FromQuery] string? name,
        [FromQuery] Gender? gender,
        [FromQuery] string? birthPlace) 
    {
        var result = _personService.GetAllPerson(name, gender, birthPlace);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonCreateDto? dto) 
    {
        if (dto == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _personService.AddPerson(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(Guid id, [FromBody] PersonUpdateDto? dto) 
    {
        if (dto == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _personService.UpdatePerson(id, dto);
        return success ? Ok($"Person with id {id} deleted.") : NotFound($"Person with id {id} not found.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(Guid id) 
    {
        var success = _personService.DeletePerson(id);
        return success ? Ok($"Person with id {id} deleted.") : NotFound($"Person with id {id} not found.");
    }
}