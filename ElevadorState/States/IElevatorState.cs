namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Interface comum a todos os estados do elevador (State, no padrão GoF).
/// Cada operação recebe o Context (Elevador) para poder ler/alterar seus dados
/// e solicitar a troca de estado quando necessário. Cada método retorna uma
/// mensagem descrevendo o resultado da operação; quem decide o que fazer com
/// essa mensagem (imprimir, logar etc.) é o chamador, não o próprio estado —
/// isso mantém a lógica de domínio livre de detalhes de apresentação.
/// </summary>
public interface IElevatorState
{
    /// <summary>Nome amigável do estado, usado para exibição.</summary>
    string Nome { get; }

    string AbrirPorta(Elevador elevador);
    string FecharPorta(Elevador elevador);
    string Subir(Elevador elevador);
    string Descer(Elevador elevador);
    string EntrarManutencao(Elevador elevador);
    string SairManutencao(Elevador elevador);
}