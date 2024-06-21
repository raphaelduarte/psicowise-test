using Psicowise.Domain.Commands;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PsicologoHandler
{
    private readonly IPsicologoRepository _repository;
    public PsicologoHandler(IPsicologoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Psicologo> Handle(CreatePsicologoCommand command)
    {
        
        
        return await _repository.Create(new Psicologo());
    }
}