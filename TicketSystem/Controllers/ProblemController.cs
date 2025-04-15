using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSystem.Endpoint;
using TicketSystem.Entitites.Dto.Problem;
using TicketSystem.Logic;

namespace TicketSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ProblemContorller : ControllerBase
{
    ProblemLogic logic;

    public ProblemContorller(ProblemLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IEnumerable<ProblemViewDto> Get()
    {
        return this.logic.Read();
    }

    [HttpPost]
    public void Post(ProblemCreateDto dto)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        this.logic.Create(dto, userId);
    }
}
