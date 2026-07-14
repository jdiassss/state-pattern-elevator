namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador descendo. Simétrico ao SubindoState: sabe como mover
/// o elevador um andar para baixo e quando encerrar o movimento.
/// </summary>
public sealed class DescendoState : IElevatorState
{
    public string Nome => "Descendo";

    public string AbrirPorta(Elevador elevador) =>
        "Não é possível abrir a porta enquanto o elevador está descendo.";

    public string FecharPorta(Elevador elevador) =>
        "A porta já está fechada; o elevador está em movimento.";

    public string Subir(Elevador elevador) =>
        "Não é possível inverter o sentido: o elevador já está descendo.";

    public string Descer(Elevador elevador)
    {
        elevador.DecrementarAndar();
        var chegada = $"Elevador descendo... chegou ao andar {elevador.AndarAtual}.";

        // Ao chegar, o elevador volta a ficar parado com a porta fechada.
        var transicao = elevador.MudarEstado(elevador.PortaFechada);

        return $"{chegada}\n{transicao}";
    }

    public string EntrarManutencao(Elevador elevador) =>
        "Não é possível entrar em manutenção enquanto o elevador está em movimento.";

    public string SairManutencao(Elevador elevador) =>
        "O elevador não está em manutenção.";
}