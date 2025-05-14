using mototrack_backend_dotnet.Application.DTOs;
using mototrack_backend_dotnet.Domain.Entities;

namespace mototrack_backend_dotnet.Application.Interfaces;

public interface IOrdemServicoApplicationService
{
    IEnumerable<OrdemServicoResponseDTO> GetAll();
    IEnumerable<OrdemServicoResponseDTO> GetByPlaca(string placa);
    IEnumerable<OrdemServicoResponseDTO> GetByStatus(StatusOrdem status);
    OrdemServicoResponseDTO? GetById(int id);
    OrdemServicoResponseDTO? Create(OrdemServicoCreateDTO ordemServico);
    OrdemServicoResponseDTO? Update(int id, OrdemServicoCreateDTO ordemServico);
    OrdemServicoResponseDTO? Delete(int id);
}
