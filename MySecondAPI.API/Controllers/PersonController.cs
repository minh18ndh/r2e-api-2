using Microsoft.AspNetCore.Mvc;
using MySecondAPI.Application.DTOs;
using MySecondAPI.Application.Interfaces.Services;

namespace MySecondAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? name,
        [FromQuery] string? gender,
        [FromQuery] string? birthPlace) 
    {
        var result = _personService.GetAllPerson(name, gender, birthPlace);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] PersonCreateDto? dto) {
        if (dto == null || !ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _personService.AddPerson(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] PersonUpdateDto? dto) {
        if (dto == null || !ModelState.IsValid)
            return BadRequest(ModelState);

        var success = _personService.UpdatePerson(id, dto);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        var success = _personService.DeletePerson(id);
        return success ? Ok() : NotFound();
    }
}