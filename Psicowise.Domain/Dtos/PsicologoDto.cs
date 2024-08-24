namespace Psicowise.Domain.Dtos;

public class PsicologoDto
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public List<ConsultaDto> Consultas { get; set; }
}