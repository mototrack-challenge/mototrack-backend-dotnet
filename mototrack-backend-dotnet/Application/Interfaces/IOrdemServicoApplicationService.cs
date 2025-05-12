using mototrack_backend_dotnet.Domain.Entities;

namespace mototrack_backend_dotnet.Application.Interfaces;

public interface IOrdemServicoApplicationService
{
    IEnumerable<OrdemServicoEntity> GetAll();
    IEnumerable<OrdemServicoEntity> GetByPlaca(string placa);
    IEnumerable<OrdemServicoEntity> GetByStatus(StatusOrdem status);
    OrdemServicoEntity? GetById(int id);
    OrdemServicoEntity? Create(OrdemServicoEntity ordemServico);
    OrdemServicoEntity? Update(int id, OrdemServicoEntity ordemServico);
    OrdemServicoEntity? Delete(int id);
}
