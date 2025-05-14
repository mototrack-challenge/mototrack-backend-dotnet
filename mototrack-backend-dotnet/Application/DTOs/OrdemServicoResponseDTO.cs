using mototrack_backend_dotnet.Domain.Entities;
using mototrack_backend_dotnet.Domain.Enums;

namespace mototrack_backend_dotnet.Application.DTOs;

public class OrdemServicoResponseDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Prioridade Prioridade { get; set; }
    public StatusOrdem Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string PlacaMoto { get; set; } = string.Empty;

}
