using mototrack_backend_dotnet.Domain.Entities;
using mototrack_backend_dotnet.Domain.Interfaces;
using mototrack_backend_dotnet.Infrastructure.AppData;

namespace mototrack_backend_dotnet.Infrastructure.Data;

public class OrdemServicoRepository : IOrdemServicoRepository
{
    private readonly ApplicationContext _context;

    public OrdemServicoRepository(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<OrdemServico> GetAll()
    {
        var ordens = _context.OrdemServico.ToList();

        return ordens;
    }
    public IEnumerable<OrdemServico> GetByPlaca(string placa)
    {
        var ordens = _context.OrdemServico
            .Where(o => o.PlacaMoto == placa)
            .ToList();

        return ordens;
    }

    public IEnumerable<OrdemServico> GetByStatus(StatusOrdem status)
    {
        var ordens = _context.OrdemServico
            .Where(o => o.Status == status)
            .ToList();

        return ordens;
    }
    public OrdemServico? GetById(int id)
    {
        var ordem = _context.OrdemServico.Find(id);

        return ordem;
    }

    public OrdemServico? Create(OrdemServico ordemServico)
    {
        _context.OrdemServico.Add(ordemServico);
        _context.SaveChanges();

        return ordemServico;
    }

    public OrdemServico? Update(int id, OrdemServico ordemServico)
    {
        var ordemExistente = _context.OrdemServico.Find(id);

        if (ordemExistente == null)
            return null;

        ordemExistente.Descricao = ordemServico.Descricao;
        ordemExistente.Prioridade = ordemServico.Prioridade;
        ordemExistente.Status = ordemServico.Status;
        ordemExistente.Responsavel = ordemServico.Responsavel;
        ordemExistente.PlacaMoto = ordemServico.PlacaMoto;

        _context.OrdemServico.Update(ordemExistente);
        _context.SaveChanges();

        return ordemExistente;
    }

    public OrdemServico? Delete(int id)
    {
        var ordem = _context.OrdemServico.Find(id);

        if (ordem is not null)
        {
            _context.OrdemServico.Remove(ordem);
            _context.SaveChanges();

            return ordem;
        }

        return null;
    }
}
