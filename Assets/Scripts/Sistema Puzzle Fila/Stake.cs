using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stakes : MonoBehaviour //Pilha Burra
{

    private int topo; // No momento que a vida é gerada
    private int[] Elementos = new int[1000];
    private int qtd;

    public Stakes()
    {
        topo = -1;
        qtd = 0;
    }
    public void insere()// insere sempre 1
    {
        if(topo <= 20)
        {
            topo++;
            Elementos[topo] = 1;
        }

        
    }

    public void remove()
    {
        if(topo > 0)
        {
            topo--;
        }
    }

    public int getTopo()
    {
        return topo;
    }
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Prev { get; set; }

}

public class FilaEncadeadaCircular<T>
{
    private Node<T> head;
    private int tamanho;

    public T GetData()
    {
        return head.Data;
    }

    public FilaEncadeadaCircular() // Construtor
    {
        tamanho = -1;
        head = null;
    }
    public void Inserir(ref T elemento) // Referencia
    {
        Node<T> node = new Node<T>
        {
            Data = elemento,
            Prev = null
        };
        if (head == null)
        {
            head = node;
        }
        else
        {
            node.Prev = head;
            head = node;
        }
        tamanho++;
    }

    public T Retirar() // De forma padrão irá retirar como uma pilha
    {
        if (Vazia())
        {
            T button = default;
            Debug.Log("Noa deu para retirar, pois esta vazia");
            return button;
        }
        else
        {
            T button = head.Data;
            Debug.Log(head.Data);
            head = head.Prev;
            tamanho--;
            return button;
        }
    }

    public void Esvaziar()
    {
        head = new Node<T>();
        tamanho = -1;
    }

    public void TransformarPilhaFila() //Inverte a ordem da pilha, transformando em uma fila
    {
        FilaEncadeadaCircular<T> Outro = new FilaEncadeadaCircular<T>();
        while (!Vazia())
        {
            T tmp = Retirar();
            Outro.Inserir(ref tmp);
            
        }
        tamanho = Outro.tamanho;
        head = Outro.head;
    }
    public bool Vazia()
    {
        return tamanho == -1;
    }
}