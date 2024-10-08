﻿namespace Psicowise.Domain.ObjetosDeValor;

public class Horario
{
    public Horario(DateTime inicioConsulta, DateTime fimConsulta)
    {
        InicioConsulta = inicioConsulta;
        FimConsulta = fimConsulta;
    }
    
    public Guid Id { get; set; } = new Guid();    
    public DateTime InicioConsulta { get; set; }
    public DateTime FimConsulta { get; set; }
}