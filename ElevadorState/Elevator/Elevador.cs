namespace ElevadorState.Elevator;

using ElevadorState.States;

/// <summary>
/// Context do padrão State.
/// Não conhece as regras de negócio de cada estado: apenas mantém o estado atual
/// e delega toda operação solicitada para ele. Também expõe os dados (andar atual,
/// limites) que os estados precisam para decidir o que é permitido.
/// </summary>
public class Elevador
{
    public const int AndarMinimo = 0;
    public const int AndarMaximo = 10;

    public int AndarAtual { get; private set; }
    public IElevatorState EstadoAtual { get; private set; }

    // Instâncias únicas de cada estado (evita recriar objetos a cada transição).
    public PortaAbertaState PortaAberta { get; } = new();
    public PortaFechadaState PortaFechada { get; } = new();
    public SubindoState Subindo { get; } = new();
    public DescendoState Descendo { get; } = new();
    public ManutencaoState Manutencao { get; } = new();

    public Elevador()
    {
        AndarAtual = 0;
        EstadoAtual = PortaFechada; // Regra de negócio: começa no térreo, porta fechada.
    }

    /// <summary>
    /// Realiza a troca de estado. É este método, chamado pelos próprios estados,
    /// que torna a transição explícita e visível para quem está lendo o código.
    /// </summary>
    public void MudarEstado(IElevatorState novoEstado)
    {
        EstadoAtual = novoEstado;
        Console.WriteLine($">> Estado alterado para: {novoEstado.Nome}");
    }

    public void IncrementarAndar() => AndarAtual++;

    public void DecrementarAndar() => AndarAtual--;

    // Operações do Context: cada uma delega imediatamente para o estado atual.
    // Note que não existe if/switch aqui verificando "qual é o estado" — quem
    // decide o comportamento é a própria classe de estado (polimorfismo).
    public void AbrirPorta() => EstadoAtual.AbrirPorta(this);

    public void FecharPorta() => EstadoAtual.FecharPorta(this);

    public void Subir() => EstadoAtual.Subir(this);

    public void Descer() => EstadoAtual.Descer(this);

    public void EntrarManutencao() => EstadoAtual.EntrarManutencao(this);

    public void SairManutencao() => EstadoAtual.SairManutencao(this);

    public void MostrarEstado() => Console.WriteLine($"Estado atual: {EstadoAtual.Nome}");

    public void MostrarAndar() => Console.WriteLine($"Andar atual: {AndarAtual}");
}
