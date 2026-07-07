namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Interface comum a todos os estados do elevador (State, no padrão GoF).
/// Cada operação recebe o Context (Elevador) para poder ler/alterar seus dados
/// e solicitar a troca de estado quando necessário.
/// </summary>
public interface IElevatorState
{
    /// <summary>Nome amigável do estado, usado apenas para exibição no console.</summary>
    string Nome { get; }

    void AbrirPorta(Elevador elevador);
    void FecharPorta(Elevador elevador);
    void Subir(Elevador elevador);
    void Descer(Elevador elevador);
    void EntrarManutencao(Elevador elevador);
    void SairManutencao(Elevador elevador);
}
