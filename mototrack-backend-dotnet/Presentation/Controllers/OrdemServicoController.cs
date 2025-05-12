using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mototrack_backend_dotnet.Application.Interfaces;
using mototrack_backend_dotnet.Domain.Entities;

namespace mototrack_backend_dotnet.Presentation.Controllers;

/// <summary>
/// Controlador responsável por operações com ordens de serviços.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrdemServicoController : ControllerBase
{
    private readonly IOrdemServicoApplicationService _service;

    public OrdemServicoController(IOrdemServicoApplicationService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todas as ordens de serviços cadastradas.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna uma lista de todas as ordens de serviços registradas no sistema.
    /// Retorna status 204 (No Content) caso não existam ordens.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com a lista das ordens de serviço, ou 204 caso não haja dados.
    /// </returns>
    /// <response code="200">Lista de ordens de serviços retornada com sucesso.</response>
    /// <response code="204">Nenhuma ordem encontrada.</response>
    /// <response code="400">Erro ao tentar buscar as ordens de serviços.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrdemServicoEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        try
        {
            var ordens = _service.GetAll();

            if (!ordens.Any())
                return NoContent();

            return Ok(ordens);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar as ordens de serviços: {ex.Message}");
        }
    }
}
