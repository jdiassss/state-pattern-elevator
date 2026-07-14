namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: elevador em manutenção. Bloqueia porta e movimento. A única
/// saída possível é encerrar a manutenção, retornando ao estado Porta Fechada.
/// </summary>
public sealed class ManutencaoState : IElevatorState
{
    public string Nome => "Em Manutenção";

    public string AbrirPorta(Elevador elevador) =>
        "Não é possível abrir a porta durante a manutenção.";

    public string FecharPorta(Elevador elevador) =>
        "Não é possível fechar a porta durante a manutenção.";

    public string Subir(Elevador elevador) =>
        "Não é possível movimentar o elevador durante a manutenção.";

    public string Descer(Elevador elevador) =>
        "Não é possível movimentar o elevador durante a manutenção.";

    public string EntrarManutencao(Elevador elevador) =>
        "O elevador já está em manutenção.";

    public string SairManutencao(Elevador elevador)
    {
        var transicao = elevador.MudarEstado(elevador.PortaFechada);
        return $"Manutenção encerrada. Elevador pronto para uso.\n{transicao}";
    }
}