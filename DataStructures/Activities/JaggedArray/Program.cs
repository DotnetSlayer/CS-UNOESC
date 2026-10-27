// JaggedArray é conehcido como um Vetor de Vetores

int[][] numbers = new int[5][];

// Neste caso [][] indica que é um Vetor de Vetor
// Neste caso é um vetor de 4 posições
// Contendo vetores de tamanha indefinido


numbers[0] = new int[] {1, 2, 3};
numbers[1] = new int[] {4, 3, 2, 1, 0};
numbers[2] = new int[] {1, 2, 0};
numbers[3] = new int[] {57};
numbers[4] = null!;

// Para obter valor de JaggedArray

int valor = numbers[0][2];
Console.WriteLine(valor);

// Para atribuir valor em um JaggedArray

numbers[1][2] = 0;
Console.WriteLine(numbers[1][2]);



