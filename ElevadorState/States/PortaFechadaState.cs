namespace ElevadorState.States;

using ElevadorState.Elevator;

/// <summary>
/// Estado: porta fechada, elevador parado. É o estado "de repouso": a partir
/// dele o elevador pode abrir a porta, iniciar um movimento ou entrar em manutenção.
/// </summary>
public class PortaFechadaState : IElevatorState
{
    public string Nome => "Porta Fechada";

    public void AbrirPorta(Elevador elevador)
    {
        Console.WriteLine("Porta aberta.");
        elevador.MudarEstado(elevador.PortaAberta);
    }

    public void FecharPorta(Elevador elevador)
    {
        Console.WriteLine("A porta já está fechada.");
    }

    public void Subir(Elevador elevador)
    {
        if (elevador.AndarAtual >= Elevador.AndarMaximo)
        {
            Console.WriteLine($"Não é possível subir: o elevador já está no andar mais alto ({Elevador.AndarMaximo}).");
            return;
        }

        Console.WriteLine("Elevador iniciando subida...");
        elevador.MudarEstado(elevador.Subindo);

        // O deslocamento em si é responsabilidade do estado "Subindo".
        elevador.Subir();
    }

    public void Descer(Elevador elevador)
    {
        if (elevador.AndarAtual <= Elevador.AndarMinimo)
        {
            Console.WriteLine("Não é possível descer: o elevador já está no térreo.");
            return;
        }

        Console.WriteLine("Elevador iniciando descida...");
        elevador.MudarEstado(elevador.Descendo);

        // O deslocamento em si é responsabilidade do estado "Descendo".
        elevador.Descer();
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
