using mototrack_backend_dotnet.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace mototrack_backend_dotnet.Application.DTOs;

public class OrdemServicoCreateDTO
{
    [Required]
    [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public Prioridade Prioridade { get; set; }

    [Required]
    public StatusOrdem Status { get; set; }

    public DateTime? DataFinalizacao { get; set; }

    [Required]
    public string Responsavel { get; set; } = string.Empty;

    [Required]
    public string PlacaMoto { get; set; } = string.Empty;
}
