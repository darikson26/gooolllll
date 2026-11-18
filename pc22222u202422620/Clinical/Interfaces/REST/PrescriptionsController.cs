using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pc22222u202422620.Clinical.Application;
using pc22222u202422620.Clinical.interfaces.REST.Resources;
using pc22222u202422620.Clinical.Interfaces.REST.Transform;

namespace pc22222u202422620.Clinical.interfaces.REST;

[ApiController]
[Route("api/v1/patients/{patientId:guid}/prescriptions")]
public class PrescriptionsController : ControllerBase
{
    private readonly PrescriptionCommandService _commandService;

    public PrescriptionsController(PrescriptionCommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Guid patientId,
        [FromBody] CreatePrescriptionResource resource)
    {
        try
        {
            var command = PrescriptionAssembler.ToCommand(resource, patientId);
            var prescription = await _commandService.HandleAsync(command);
            var response = PrescriptionAssembler.ToResource(prescription);

            return StatusCode(StatusCodes.Status201Created, response);
        }
        catch (InvalidOperationException exception)
        {
            return Conflict(new { message = exception.Message });
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
        catch (FormatException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
    }
}