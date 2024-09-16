namespace Psicowise.Domain.Queries.Contracts;

public interface IWhatsappServiceQuery
{
    Task<string> GetInstanceName(Guid psicologoId);
    Task<List<string>> GetAllInstanceByPsicologoId(Guid psicologoId);
}