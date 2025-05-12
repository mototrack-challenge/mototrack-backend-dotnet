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
    public IEnumerable<OrdemServico> GetAll()
    {
        return _repository.GetAll();
    }
    public IEnumerable<OrdemServico> GetByPlaca(string placa)
    {
        return _repository.GetByPlaca(placa);
    }

    public IEnumerable<OrdemServico> GetByStatus(StatusOrdem status)
    {
        return _repository.GetByStatus(status);
    }
    public OrdemServico? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public OrdemServico? Create(OrdemServico ordemServico)
    {
        return _repository.Create(ordemServico);
    }
    public OrdemServico? Update(int id, OrdemServico ordemServico)
    {
        return _repository.Update(id, ordemServico);
    }

    public OrdemServico? Delete(int id)
    {
        return _repository.Delete(id);
    }
}

