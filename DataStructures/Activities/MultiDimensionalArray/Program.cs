// Criando um Vetor Multidimensional
// Com 5 linhas e 2 colunas

int[,] numbers = new int[5,2];

// Criando um Vetor tridimensional

int[,,] triNumbers = new int[5,4,3];

// Podemos Inicializar os Valores do Vetor no momento de sua declaração

int[,] iniNumbers = new int[,]
{
    {9,15,-9},
    {11,7,-9},
    {19,25,-4},
    {16,45,-79},
    {10,5,89},
};

// Para acessar os Valores contidos neste tipo de Variável 

int valor = iniNumbers[0,1]; // O Valor é 15

Console.WriteLine($"iniNumbers[0,1] = {valor}");

int maiorNumero = iniNumbers[0,0];

foreach (int number in iniNumbers)
{
    if(number > maiorNumero)
    {
        maiorNumero = number;    
    }
}

Console.WriteLine("O maior número é: " + maiorNumero);

