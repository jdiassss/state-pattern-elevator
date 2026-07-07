namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador em manutenção. Bloqueia porta e movimento. A única
/// saída possível é encerrar a manutenção, retornando ao estado Porta Fechada.
/// </summary>
public class ManutencaoState : IElevatorState
{
    public string Nome => "Em Manutenção";

    public void AbrirPorta(Elevador elevador)
    {
        Console.WriteLine("Não é possível abrir a porta durante a manutenção.");
    }

    public void FecharPorta(Elevador elevador)
    {
        Console.WriteLine("Não é possível fechar a porta durante a manutenção.");
    }

    public void Subir(Elevador elevador)
    {
        Console.WriteLine("Não é possível movimentar o elevador durante a manutenção.");
    }

    public void Descer(Elevador elevador)
    {
        Console.WriteLine("Não é possível movimentar o elevador durante a manutenção.");
    }

    public void EntrarManutencao(Elevador elevador)
    {
        Console.WriteLine("O elevador já está em manutenção.");
    }

    public void SairManutencao(Elevador elevador)
    {
        Console.WriteLine("Manutenção encerrada. Elevador pronto para uso.");
        elevador.MudarEstado(elevador.PortaFechada);
    }
}
