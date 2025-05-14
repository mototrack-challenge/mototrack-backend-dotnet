using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mototrack_backend_dotnet.Domain.Entities;

public enum Prioridade { BAIXA, MEDIA, ALTA }
public enum StatusOrdem { ABERTA, EM_ANDAMENTO, FINALIZADA }

[Table("MT_ORDEMSERVICO")]
public class OrdemServicoEntity
{
    [Key]
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Prioridade Prioridade { get; set; }
    public StatusOrdem Status { get; set; } = StatusOrdem.ABERTA;
    public DateTime DataAbertura { get; set; } = DateTime.Now;
    public DateTime? DataFinalizacao { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string PlacaMoto { get; set; } = string.Empty;
}
