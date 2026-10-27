using System.ComponentModel;
using System;
using System.Collections.Generic;

class Livro
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public int Paginas { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Livro> livros = new List<Livro>();
        Console.Write("Quantos livros deseja adicionar? ");
        int QuantidadeLivros = int.Parse(Console.ReadLine());

        for (int i = 0; i < QuantidadeLivros; i++)
        {
            Console.WriteLine($"\nDigite os dados do livro {i + 1}:");
            Livro livro = new Livro
            {
                Nome = Console.ReadLine(),
                Autor = Console.ReadLine(),
                Editora = Console.ReadLine(),
                Paginas = int.Parse(Console.ReadLine()),

            };
            livros.Add(livro);
        }

        Livro livroMaiorPaginas = livros[0];
        foreach(var livro in livros)
        {
            if(livro.Paginas > livroMaiorPaginas.Paginas)
            {
                livroMaiorPaginas = livro;
            }
        }

        Console.WriteLine("\nLivro com mais páginas:");
        Console.WriteLine($"Nome: {livroMaiorPaginas.Nome}");
        Console.WriteLine($"Autor: {livroMaiorPaginas.Autor}");
        Console.WriteLine($"Editora: {livroMaiorPaginas.Editora}");
        Console.WriteLine($"Páginas: {livroMaiorPaginas.Paginas}");
    }
}
