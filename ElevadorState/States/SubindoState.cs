namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador subindo. Enquanto em movimento, a porta não pode ser
/// aberta/fechada, o sentido não pode ser invertido diretamente e não é
/// possível entrar em manutenção. É este estado que efetivamente sabe
/// como mover o elevador um andar para cima e quando parar.
/// </summary>
public sealed class SubindoState : IElevatorState
{
    public string Nome => "Subindo";

    public string AbrirPorta(Elevador elevador) =>
        "Não é possível abrir a porta enquanto o elevador está subindo.";

    public string FecharPorta(Elevador elevador) =>
        "A porta já está fechada; o elevador está em movimento.";

    public string Subir(Elevador elevador)
    {
        elevador.IncrementarAndar();
        var chegada = $"Elevador subindo... chegou ao andar {elevador.AndarAtual}.";

        // Ao chegar, o elevador volta a ficar parado com a porta fechada.
        var transicao = elevador.MudarEstado(elevador.PortaFechada);

        return $"{chegada}\n{transicao}";
    }

    public string Descer(Elevador elevador) =>
        "Não é possível inverter o sentido: o elevador já está subindo.";

    public string EntrarManutencao(Elevador elevador) =>
        "Não é possível entrar em manutenção enquanto o elevador está em movimento.";

    public string SairManutencao(Elevador elevador) =>
        "O elevador não está em manutenção.";
}