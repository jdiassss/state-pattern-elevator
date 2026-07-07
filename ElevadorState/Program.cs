using ElevadorState.Elevator;

var elevador = new Elevador();
var continuar = true;

while (continuar)
{
    ExibirCabecalho(elevador);

    Console.Write("Escolha: ");
    var opcao = Console.ReadLine();
    Console.WriteLine();

    switch (opcao)
    {
        case "1":
            elevador.AbrirPorta();
            break;
        case "2":
            elevador.FecharPorta();
            break;
        case "3":
            elevador.Subir();
            break;
        case "4":
            elevador.Descer();
            break;
        case "5":
            elevador.EntrarManutencao();
            break;
        case "6":
            elevador.SairManutencao();
            break;
        case "7":
            elevador.MostrarEstado();
            break;
        case "8":
            elevador.MostrarAndar();
            break;
        case "0":
            continuar = false;
            Console.WriteLine("Encerrando o sistema do elevador...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine();
}

// Este switch trata apenas a entrada do usuário (escolha de menu),
// não decide o comportamento do elevador — essa responsabilidade é inteiramente das classes de estado, através do padrão State.

static void ExibirCabecalho(Elevador elevador)
{
    Console.WriteLine("-------------------------");
    Console.WriteLine("   SISTEMA DO ELEVADOR");
    Console.WriteLine("-------------------------");
    Console.WriteLine($"Estado atual: {elevador.EstadoAtual.Nome}");
    Console.WriteLine($"Andar atual : {elevador.AndarAtual}");
    Console.WriteLine();
    Console.WriteLine("1 - Abrir porta");
    Console.WriteLine("2 - Fechar porta");
    Console.WriteLine("3 - Subir");
    Console.WriteLine("4 - Descer");
    Console.WriteLine("5 - Entrar em manutenção");
    Console.WriteLine("6 - Sair da manutenção");
    Console.WriteLine("7 - Mostrar estado");
    Console.WriteLine("8 - Mostrar andar");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();
}
