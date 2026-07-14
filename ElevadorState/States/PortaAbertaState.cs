namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: porta aberta. O elevador não pode se mover enquanto a porta
/// estiver aberta; a porta precisa ser fechada primeiro.
/// </summary>
public sealed class PortaAbertaState : IElevatorState
{
    public string Nome => "Porta Aberta";

    public string AbrirPorta(Elevador elevador) =>
        "A porta já está aberta.";

    public string FecharPorta(Elevador elevador)
    {
        var transicao = elevador.MudarEstado(elevador.PortaFechada);
        return $"Porta fechada.\n{transicao}";
    }

    public string Subir(Elevador elevador) =>
        "Não é possível subir com a porta aberta. Feche a porta primeiro.";

    public string Descer(Elevador elevador) =>
        "Não é possível descer com a porta aberta. Feche a porta primeiro.";

    public string EntrarManutencao(Elevador elevador)
    {
        var transicao = elevador.MudarEstado(elevador.Manutencao);
        return $"Entrando em manutenção...\n{transicao}";
    }

    public string SairManutencao(Elevador elevador) =>
        "O elevador não está em manutenção.";
}