using mototrack_backend_dotnet.Domain.Entities;

namespace mototrack_backend_dotnet.Application.Interfaces;

public interface IOrdemServicoApplicationService
{
    IEnumerable<OrdemServico> GetAll();
    IEnumerable<OrdemServico> GetByPlaca(string placa);
    IEnumerable<OrdemServico> GetByStatus(StatusOrdem status);
    OrdemServico? GetById(int id);
    OrdemServico? Create(OrdemServico ordemServico);
    OrdemServico? Update(int id, OrdemServico ordemServico);
    OrdemServico? Delete(int id);
}
