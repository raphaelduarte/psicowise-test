namespace Psicowise.Domain.Dtos;

public class ConsultaDto
{
    public Guid Id { get; set; }
    public DateTime DataConsulta { get; set; }
    public string Observacoes { get; set; }
    public PacienteDto Paciente { get; set; }
}