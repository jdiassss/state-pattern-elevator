namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador subindo. Enquanto em movimento, a porta não pode ser
/// aberta/fechada, o sentido não pode ser invertido diretamente e não é
/// possível entrar em manutenção. É este estado que efetivamente sabe
/// como mover o elevador um andar para cima e quando parar.
/// </summary>
public class SubindoState : IElevatorState
{
    public string Nome => "Subindo";

    public void AbrirPorta(Elevador elevador)
    {
        Console.WriteLine("Não é possível abrir a porta enquanto o elevador está subindo.");
    }

    public void FecharPorta(Elevador elevador)
    {
        Console.WriteLine("A porta já está fechada; o elevador está em movimento.");
    }

    public void Subir(Elevador elevador)
    {
        elevador.IncrementarAndar();
        Console.WriteLine($"Elevador subindo... chegou ao andar {elevador.AndarAtual}.");

        // Ao chegar, o elevador volta a ficar parado com a porta fechada.
        elevador.MudarEstado(elevador.PortaFechada);
    }

    public void Descer(Elevador elevador)
    {
        Console.WriteLine("Não é possível inverter o sentido: o elevador já está subindo.");
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
