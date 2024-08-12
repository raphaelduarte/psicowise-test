namespace Psicowise.Domain.ObjetosDeValor;

public class Telefone
{
    public Telefone(
        string ddd,
        string numero
        )
    {
        Ddd = ddd;
        Numero = numero;
    }
    public string Ddd { get; private set; }
    public string Numero { get; private set; }
}