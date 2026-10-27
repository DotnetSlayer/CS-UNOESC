using System.Collections;

// Utilizando a Lista Simples

ArrayList arrList = new();
arrList.Add(5);
arrList.Add("Thiago");

// É possível adicionar um conjunto de Valores de uma só vez

arrList.AddRange(new int[] {1, 2, 3});

// O método .Add() unsere o valor ao final do Vetor

arrList.Insert(2,15);

// Já o Método .Insert(), me permite incluir o valor desejado na posição especificada no primeiro parâmetro

// Lendo Valores da Lista 

object primeiro = arrList[0]!;
int quarto = (int)arrList[3]!;

// Percorrendo a Lista com Foreach 

foreach(object obj in arrList)
{
    Console.Write($" | {obj}");
}

// Obtendo o tamanho total da Lista
// Quantos elementos tem

int tamanho = arrList.Count;

// Obter a capacidade 
//Quantos podem ser armazenados

int capacidade = arrList.Capacity;

// Percorrendo no modo Clássico

for(int i = 0; i < arrList.Count; i++)
{
    Console.Write($" | {arrList[i]}");
}

// Recursos Importantes da Lista
// Verificar se um valor é contido na Lista

bool contemNome = arrList.Contains("Thiago");
if(!contemNome)
{
    Console.WriteLine("Nome Thiago não encontrado");
}

// Para saber o índice que conteém o Valor buscado
// Neste caso, se o Valor existir na Lista, ele retorna o índice (Número Inteiro)
// Caso esse Valor não exista, ele retorna -1

int indiceDoValor = arrList.IndexOf("Thiago");
if(indiceDoValor >= -0)

    Console.WriteLine( $"Thiago está em [{indiceDoValor}]");


else
    Console.WriteLine("É, realmente não tem.");

// É possível remover itens da Lista

arrList.Remove("Thiago"); // Remove pelo Valor
arrList.RemoveAt(4); // Remove do índice
arrList.RemoveRange(0,2); // O primeiro parâmetro é o índice, e o segundo é quantas casas após o índice

