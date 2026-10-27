using InsertionSort;

int[] inteiros = {57, 43, 89, 150, 25, 12};

Console.WriteLine("Números sem Filtrar");
InsertionSort.InsertionSort.Print(inteiros);

InsertionSort.InsertionSort.Sort<int>(inteiros);

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Números Filtrados com InsertionSort");
InsertionSort.InsertionSort.Print(inteiros);

Console.WriteLine("");
Console.WriteLine("");

