// Inicializa a lista circular de categorias de esportes
SportsLinkedList<string> categories = new SportsLinkedList<string>();

// Adiciona categorias de esportes na lista circular
categories.AddLast("Futebol");
categories.AddLast("Basquete");
categories.AddLast("Vôlei");
categories.AddLast("Tênis");
categories.AddLast("Handebol");
categories.AddLast("Atletismo");
categories.AddLast("Natação");
categories.AddLast("Ciclismo");
categories.AddLast("Surf");
categories.AddLast("Boxe");

// Função para randomizar as categorias de esportes
Random aleatorio = new Random();
int tempoTotal = 0;
int tempoRestante = 0;

// Loop While para manter o jogo em execução
while (true)
{
    // Condição para iniciar o jogo (ENTER) ou sair (qualquer tecla)
    if (tempoRestante <= 0)
    {
        Console.WriteLine("Pressione a tecla [*ENTER*] para começar o jogo\n\n");
        Console.WriteLine("Pressione qualquer outra tecla para sair...");

        // Se a tecla apertada não for ENTER, o jogo é encerrado
        if (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            return;
        }

        // Se o ENTER tiver sido apertado inicia o jogo
        tempoTotal = aleatorio.Next(800, 1200);
        tempoRestante = tempoTotal;

        
    }

    // Escolhe uma categoria de esporte aleatória
    var allCategories = categories.GetAll();
    string categoria = allCategories[aleatorio.Next(allCategories.Count)];

    // Embaralha a lista de categorias antes de cada rotação
    var categoriasEmbaralhadas = allCategories.OrderBy(x => aleatorio.Next()).ToList();

    // Cria um HashSet, ele faz com que valores usados sejam armazenados, não permitindo repetições
    var categoriasUsadas = new HashSet<string>();

    foreach (var categoriaAtual in categoriasEmbaralhadas)
    {
        // Se a categoria ainda não foi usada, exibe e marca como usada
        if (categoriasUsadas.Add(categoriaAtual))
        {
            int categoriaTempo = (-450 * tempoRestante) / (tempoTotal - 50) + 500 + (22500 / (tempoTotal - 50));
            tempoRestante -= categoriaTempo;

            Thread.Sleep(categoriaTempo);

            Console.ForegroundColor = tempoRestante <= 0 ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(categoria);
            Console.ForegroundColor = ConsoleColor.Gray;

            break; // Sai do loop, pois a categoria já foi exibida
        }
    }
}


    

