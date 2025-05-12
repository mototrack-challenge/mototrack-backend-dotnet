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
    public IEnumerable<OrdemServicoEntity> GetAll()
    {
        return _repository.GetAll();
    }
    public IEnumerable<OrdemServicoEntity> GetByPlaca(string placa)
    {
        return _repository.GetByPlaca(placa);
    }

    public IEnumerable<OrdemServicoEntity> GetByStatus(StatusOrdem status)
    {
        return _repository.GetByStatus(status);
    }
    public OrdemServicoEntity? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public OrdemServicoEntity? Create(OrdemServicoEntity ordemServico)
    {
        return _repository.Create(ordemServico);
    }
    public OrdemServicoEntity? Update(int id, OrdemServicoEntity ordemServico)
    {
        return _repository.Update(id, ordemServico);
    }

    public OrdemServicoEntity? Delete(int id)
    {
        return _repository.Delete(id);
    }
}

