using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mototrack_backend_dotnet.Domain.Entities;

public enum Prioridade { BAIXA, MEDIA, ALTA }
public enum StatusOrdem { ABERTA, EM_ANDAMENTO, FINALIZADA }

[Table("MT_ORDEMSERVICO")]
public class OrdemServico
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(200,ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public Prioridade Prioridade { get; set; }
    [Required]
    public StatusOrdem Status { get; set; } = StatusOrdem.ABERTA;
    public DateTime DataAbertura { get; set; } = DateTime.Now;
    public DateTime? DataFinalizacao { get; set; }
    [Required]
    public string Responsavel { get; set; } = string.Empty;
    [Required]
    public string PlacaMoto { get; set; } = string.Empty;
}
