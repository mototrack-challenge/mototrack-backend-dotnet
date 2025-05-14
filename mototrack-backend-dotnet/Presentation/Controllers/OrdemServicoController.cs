using System.Numerics;
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


    /// <summary>
    /// Retorna as ordens de serviço associadas a uma placa específica.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna todas as ordens de serviços que possuem a placa informada.
    /// Retorna status 204 caso não existam ordens com essa placa.
    /// </remarks>
    /// <param name="placa">Placa da moto associada à ordem de serviço.</param>
    /// <returns>
    /// Retorna 200 OK com a lista das ordens, ou 204 caso não haja resultados.
    /// </returns>
    /// <response code="200">Lista de ordens de serviços com a placa especificada retornada com sucesso.</response>
    /// <response code="204">Nenhuma ordem encontrada para a placa informada.</response>
    /// <response code="400">Erro ao tentar buscar as ordens de serviços pela placa.</response>
    [HttpGet("placa/{placa}")]
    [ProducesResponseType(typeof(IEnumerable<OrdemServicoEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetByPlaca([FromRoute] string placa)
    {
        try
        {
            var ordensPlaca = _service.GetByPlaca(placa);

            if (!ordensPlaca.Any())
                return NoContent();

            return Ok(ordensPlaca);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar as ordens de serviços com essa placa: {ex.Message}");
        }
    }

    /// <summary>
    /// Retorna as ordens de serviço com o status especificado.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna todas as ordens de serviços que possuem o status informado.
    /// Retorna status 204 caso não existam ordens com esse status.
    /// </remarks>
    /// <param name="status">Status da ordem de serviço (por exemplo: ABERTA, EM_ANDAMENTO, FINALIZADA).</param>
    /// <returns>
    /// Retorna 200 OK com a lista das ordens, ou 204 caso não haja resultados.
    /// </returns>
    /// <response code="200">Lista de ordens de serviços com o status especificado retornada com sucesso.</response>
    /// <response code="204">Nenhuma ordem encontrada com o status informado.</response>
    /// <response code="400">Erro ao tentar buscar as ordens de serviços pelo status.</response>
    [HttpGet("status/{status}")]
    [ProducesResponseType(typeof(IEnumerable<OrdemServicoEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetByStatus([FromRoute] StatusOrdem status)
    {
        try
        {
            var ordensStatus = _service.GetByStatus(status);

            if (!ordensStatus.Any())
                return NoContent();

            return Ok(ordensStatus);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar as ordens de serviços com esse status: {ex.Message}");
        }
    }


    /// <summary>
    /// Retorna a ordem de serviço cadastrada com este id.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna a ordem de serviço registrada no sistema com o id passado por parâmetro.
    /// Retorna status 404 (Not Found) caso não exista a ordem com este id.
    /// </remarks>
    /// <returns>
    /// Retorna 200 OK com a ordem de servico, ou 404 caso não haja ordem com este id.
    /// </returns>
    /// <response code="200">Ordem de Serviço com este id retornada com sucesso.</response>
    /// <response code="404">Nenhuma ordem com este id encontrada.</response>
    /// <response code="400">Erro ao tentar buscar a ordem.</response>
    /// <param name="id">ID da ordem de serviço a ser consultado. Deve ser um número inteiro maior que zero.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrdemServicoEntity), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            var ordem = _service.GetById(id);

            if (ordem == null)
                return NotFound($"Ordem de Serviço com ID {id} não encontrada.");

            return Ok(ordem);

        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao buscar a ordem de serviço com este ID: {ex.Message}");
        }
    }

    /// <summary>
    /// Cadastra uma nova ordem de serviço no sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint recebe os dados de uma nova ordem de serviço e a registra no sistema. 
    /// É necessário enviar um objeto JSON no corpo da requisição com os dados obrigatórios:
    /// - descricao
    /// - prioridade (BAIXA, MEDIA, ALTA)
    /// - status (ABERTA, EM_ANDAMENTO, FINALIZADA)
    /// - dataFinalizacao
    /// - responsavel
    /// - placaMoto
    /// 
    /// Exemplo de corpo (JSON):
    ///{
    ///"descricao": "Arrumar motor da moto",
    ///"prioridade": "MEDIA",
    ///"status": "EM_ANDAMENTO",
    ///"dataAbertura": "2025-05-13T21:59:20.953Z",
    ///"dataFinalizacao": "2025-06-07T09:00:00.953Z",
    ///"responsavel": "Felipe Sora",
    ///"placaMoto": "ABC1234"
    ///}
    /// </remarks>
    /// <param name="entity">Objeto com os dados da nova ordem de serviço.</param>
    /// <returns>Retorna 200 OK com a ordem cadastrado ou 400 Bad Request em caso de erro.</returns>
    /// <response code="200">Ordem cadastrada com sucesso.</response>
    /// <response code="400">Erro ao tentar salvar a ordem.</response>
    [HttpPost]
    [ProducesResponseType(typeof(OrdemServicoEntity), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] OrdemServicoEntity entity)
    {
        try
        {
            var ordem = _service.Create(entity);

            return Ok(ordem);

        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar salvar esta ordem de serviço: {ex.Message}");
        }
    }

    /// <summary>
    /// Atualiza os dados de uma ordem de serviço existente.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite atualizar as informações de uma ordem de serviço cadastrada no sistema.
    /// O ID da ordem deve ser informado na rota e os novos dados devem ser enviados no corpo da requisição.
    /// Retorna 404 caso a ordem não exista.
    /// </remarks>
    /// <param name="id">ID da ordem de serviço a ser atualizado. Deve ser um número inteiro maior que zero.</param>
    /// <param name="entity">Objeto com os novos dados da ordem de serviço.</param>
    /// <returns>Retorna a ordem de serviço atualizada ou uma mensagem de erro.</returns>
    /// <response code="200">Ordem de Serviço atualizada com sucesso.</response>
    /// <response code="404">Ordem de Serviço com o ID especificado não foi encontrada.</response>
    /// <response code="400">Erro ao tentar atualizar a ordem de serviço.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(OrdemServicoEntity), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Editar([FromRoute] int id, [FromBody] OrdemServicoEntity entity)
    {
        try
        {
            var ordemAtualizada = _service.Update(id, entity);

            if (ordemAtualizada == null)
                return NotFound($"Ordem de Serviço com ID {id} não encontrado.");

            return Ok(ordemAtualizada);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar editar esta ordem de serviço: {ex.Message}");
        }
    }

    /// <summary>
    /// Remove a ordem de serviço do sistema com o id especificado.
    /// </summary>
    /// <remarks>
    /// Este endpoint remove uma ordem de serviço registrada no sistema, identificado pelo ID passado como parâmetro na rota.
    /// Retorna 404 caso a ordem não seja encontrada.
    /// </remarks>
    /// <param name="id">ID da ordem de serviço a ser removida. Deve ser um número inteiro maior que zero.</param>
    /// <returns>Retorna o status de sucesso ou falha dependendo do resultado da remoção.</returns>
    /// <response code="200">Ordem de Serviço removida com sucesso.</response>
    /// <response code="404">Ordem de Serviço com o ID especificado não encontrada.</response>
    /// <response code="400">Erro ao tentar remover a ordem de serviço.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(OrdemServicoEntity), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Deletar(int id)
    {
        try
        {
            var ordem = _service.Delete(id);

            if (ordem == null)
                return NotFound($"Ordem de Serviço com ID {id} não encontrada.");

            return Ok(ordem);


        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu uma falha ao tentar remover esta ordem de serviço: {ex.Message}");
        }
    }

}
