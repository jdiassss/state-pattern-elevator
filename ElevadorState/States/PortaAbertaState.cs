namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: porta aberta. O elevador não pode se mover enquanto a porta
/// estiver aberta; a porta precisa ser fechada primeiro.
/// </summary>
public class PortaAbertaState : IElevatorState
{
    public string Nome => "Porta Aberta";

    public void AbrirPorta(Elevador elevador)
    {
        Console.WriteLine("A porta já está aberta.");
    }

    public void FecharPorta(Elevador elevador)
    {
        Console.WriteLine("Porta fechada.");
        elevador.MudarEstado(elevador.PortaFechada);
    }

    public void Subir(Elevador elevador)
    {
        Console.WriteLine("Não é possível subir com a porta aberta. Feche a porta primeiro.");
    }

    public void Descer(Elevador elevador)
    {
        Console.WriteLine("Não é possível descer com a porta aberta. Feche a porta primeiro.");
    }

    public void EntrarManutencao(Elevador elevador)
    {
        Console.WriteLine("Entrando em manutenção...");
        elevador.MudarEstado(elevador.Manutencao);
    }

    public void SairManutencao(Elevador elevador)
    {
        Console.WriteLine("O elevador não está em manutenção.");
    }
}
