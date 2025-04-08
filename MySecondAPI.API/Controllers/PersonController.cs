using Microsoft.AspNetCore.Mvc;
using MySecondAPI.Application.DTOs;
using MySecondAPI.Domain.Enums;
using MySecondAPI.Application.Interfaces.Services;

namespace MySecondAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) {
        _personService = personService;
    }

    [HttpGet("all")]
    public IActionResult GetAllPerson() {
        var result = _personService.GetAllPerson();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonCreateDto? dto) {
        if (dto == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _personService.AddPerson(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(Guid id, [FromBody] PersonUpdateDto? dto) {
        if (dto == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _personService.UpdatePerson(id, dto);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(Guid id) {
        var success = _personService.DeletePerson(id);
        return success ? Ok() : NotFound();
    }

    [HttpGet("filter-by-name")]
    public IActionResult FilterByName([FromQuery] string name) {
        if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name cannot be empty.");
        var result = _personService.FilterPersonByName(name);
        return Ok(result);
    }

    [HttpGet("filter-by-gender")]
    public IActionResult FilterByGender([FromQuery] Gender? gender) {
        if (gender == null) return BadRequest("Gender is required.");

        var result = _personService.FilterPersonByGender(gender.Value);
        return Ok(result);
    }

    [HttpGet("filter-by-birthplace")]
    public IActionResult FilterByBirthPlace([FromQuery] string birthPlace) {
        if (string.IsNullOrWhiteSpace(birthPlace)) return BadRequest("Birthplace cannot be empty.");
        var result = _personService.FilterPersonByBirthPlace(birthPlace);
        return Ok(result);
    }
}