using System;
using System.Collections.Generic;
using System.Threading;


public class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
    }
}

    public class SportsLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            tail.Next = head; // Conecta o último ao primeiro
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head; // Conecta o último ao primeiro
        }
    }

    public List<T> GetAll()
    {
        var result = new List<T>();
        if (head == null) return result;

        var current = head;
        do
        {
            result.Add(current.Data);
            current = current.Next;
        } while (current != head);

        return result;
    }
}

