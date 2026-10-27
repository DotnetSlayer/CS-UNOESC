using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<QuizItem> tree = GetTree();
        BinaryTreeNode<QuizItem> node = tree.Root;
        
        while (node != null)
        {
            if (node.Left != null || node.Right != null)
            {
                Console.Write(node.Data.Text);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        WriteAnswer("Yes");
                        node = node.Left;
                        break;

                    case ConsoleKey.N:
                        WriteAnswer("No");
                        node = node.Right;
                        break;
                }
            }
            else
            {
                WriteAnswer(node.Data.Text);
                node = null;
            }
        }
    }

    private static BinaryTree<QuizItem> GetTree()
    {
        BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>();
        tree.Root = new BinaryTreeNode<QuizItem>()
        {
            Data = new QuizItem("Você tem experiência em desenvolver softwares?"),
            Left = new BinaryTreeNode<QuizItem>()
            {
                Data = new QuizItem("Trabalhou como desenvolvedor por mais de 5 anos?"),
                Left = new BinaryTreeNode<QuizItem>()
                {
                    Data = new QuizItem("Candidate-se a desenvolvedor Senior!")
                },
                Right = new BinaryTreeNode<QuizItem>()
                {
                    Data = new QuizItem("Candidate-se a desenvolvedor Médio!")
                }
            },
            Right = new BinaryTreeNode<QuizItem>()
            {
                Data = new QuizItem("Completou a Faculdade?"),
                Left = new BinaryTreeNode<QuizItem>()
                {
                    Data = new QuizItem("Candidate-se a desenvolvedor Júnior!")
                },
                Right = new BinaryTreeNode<QuizItem>()
                {
                    Data = new QuizItem("Você terá um tempo durante o Semestre?"),
                    Left = new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Candidate-se para um Estágio de longo prazo!")
                    },
                    Right = new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Candidate-se para um Estágio de verão!")
                    }
                }
            }
        };

        tree.Count = 9; 
        return tree;
    }

    private static void WriteAnswer(string answer)
    {
        Console.WriteLine(answer);
    }
}



class QuizItem
{
    public string Text { get; }

    public QuizItem(string text)
    {
        Text = text;
    }
}

class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }
}

class BinaryTreeNode<T> : TreeNode<T>
{
    public T Data { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
}

class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }
}
