using mototrack_backend_dotnet.Application.DTOs;
using mototrack_backend_dotnet.Application.Interfaces;
using mototrack_backend_dotnet.Domain.Entities;
using mototrack_backend_dotnet.Domain.Interfaces;

namespace mototrack_backend_dotnet.Application.Services;

public class OrdemServicoApplicationService : IOrdemServicoApplicationService
{
    private readonly IOrdemServicoRepository _repository;

    public OrdemServicoApplicationService(IOrdemServicoRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<OrdemServicoResponseDTO> GetAll()
    {
        return _repository.GetAll()
            .Select(MapToResponseDto);
    }
    public IEnumerable<OrdemServicoResponseDTO> GetByPlaca(string placa)
    {
        return _repository.GetByPlaca(placa)
            .Select(MapToResponseDto);
    }

    public IEnumerable<OrdemServicoResponseDTO> GetByStatus(StatusOrdem status)
    {
        return _repository.GetByStatus(status)
            .Select(MapToResponseDto);
    }
    public OrdemServicoResponseDTO? GetById(int id)
    {
        var entity = _repository.GetById(id);
        return entity is null ? null : MapToResponseDto(entity);
    }

    public OrdemServicoResponseDTO? Create(OrdemServicoCreateDTO dto)
    {
        var entity = new OrdemServicoEntity
        {
            Descricao = dto.Descricao,
            Prioridade = dto.Prioridade,
            Status = dto.Status,
            DataFinalizacao = dto.DataFinalizacao,
            Responsavel = dto.Responsavel,
            PlacaMoto = dto.PlacaMoto
        };

        var created = _repository.Create(entity);
        return created is null ? null : MapToResponseDto(created);
    }
    public OrdemServicoResponseDTO? Update(int id, OrdemServicoCreateDTO dto)
    {
        var entity = new OrdemServicoEntity
        {
            Id = id,
            Descricao = dto.Descricao,
            Prioridade = dto.Prioridade,
            Status = dto.Status,
            DataFinalizacao = dto.DataFinalizacao,
            Responsavel = dto.Responsavel,
            PlacaMoto = dto.PlacaMoto
        };

        var updated = _repository.Update(id, entity);
        return updated is null ? null : MapToResponseDto(updated);
    }

    public OrdemServicoResponseDTO? Delete(int id)
    {
        var deleted = _repository.Delete(id);
        return deleted is null ? null : MapToResponseDto(deleted);
    }

    private static OrdemServicoResponseDTO MapToResponseDto(OrdemServicoEntity entity)
    {
        return new OrdemServicoResponseDTO
        {
            Id = entity.Id,
            Descricao = entity.Descricao,
            Prioridade = entity.Prioridade,
            Status = entity.Status,
            DataAbertura = entity.DataAbertura,
            DataFinalizacao = entity.DataFinalizacao,
            Responsavel = entity.Responsavel,
            PlacaMoto = entity.PlacaMoto
        };
    }
}

