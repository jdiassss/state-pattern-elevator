namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador descendo. Simétrico ao SubindoState: sabe como mover
/// o elevador um andar para baixo e quando encerrar o movimento.
/// </summary>
public class DescendoState : IElevatorState
{
    public string Nome => "Descendo";

    public void AbrirPorta(Elevador elevador)
    {
        Console.WriteLine("Não é possível abrir a porta enquanto o elevador está descendo.");
    }

    public void FecharPorta(Elevador elevador)
    {
        Console.WriteLine("A porta já está fechada; o elevador está em movimento.");
    }

    public void Subir(Elevador elevador)
    {
        Console.WriteLine("Não é possível inverter o sentido: o elevador já está descendo.");
    }

    public void Descer(Elevador elevador)
    {
        elevador.DecrementarAndar();
        Console.WriteLine($"Elevador descendo... chegou ao andar {elevador.AndarAtual}.");

        // Ao chegar, o elevador volta a ficar parado com a porta fechada.
        elevador.MudarEstado(elevador.PortaFechada);
    }

    public void EntrarManutencao(Elevador elevador)
    {
        Console.WriteLine("Não é possível entrar em manutenção enquanto o elevador está em movimento.");
    }

    public void SairManutencao(Elevador elevador)
    {
        Console.WriteLine("O elevador não está em manutenção.");
    }
}
