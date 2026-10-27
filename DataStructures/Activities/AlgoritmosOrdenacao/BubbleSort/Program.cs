using BubbleSort;

int[] inteiros = {0, 12, 7, 1, 2, 8};

Console.WriteLine("Números sem Filtrar");
BubbleSort.BubbleSort.Print(inteiros);

BubbleSort.BubbleSort.Sort<int>(inteiros);

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Números Filtrados com BubbleSort");
BubbleSort.BubbleSort.Print(inteiros);

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Teste Char");

char[] chars = ['x', 'z', 'd', 'c', 'a'];
BubbleSort.BubbleSort.Print(chars);
BubbleSort.BubbleSort.Sort(chars);
Console.WriteLine("");
BubbleSort.BubbleSort.Print(chars);
