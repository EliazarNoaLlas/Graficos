using System;
using System.Collections.Generic;

const int MAX = 999999;

class Nodo
{
    public char dato;
    public Nodo sgte;
    public Arista ady;
    public int distanciaFuente;
    public Nodo predecesor;
    public char estado;
}

class Arista
{
    public Nodo destino;
    public Arista sgte;
    public int distancia;
    public bool disponible; // Nueva bandera que indica si la arista está disponible
}

class Program
{
    static void Main(string[] args)
    {
        Nodo grafo = null;
        char valor, origen, destino;
        int n = 10; // Número de nodos
        int a = 15; // Número de aristas
        int distancia;

        Console.WriteLine("Generando grafo aleatorio...");

        Random rand = new Random();

        // Generar nodos
        for (int i = 0; i < n; i++)
        {
            valor = (char)('A' + i);
            insertarNodo(ref grafo, valor);
        }

        // Generar aristas
        for (int i = 0; i < a; i++)
        {
            origen = (char)('A' + rand.Next(n)); // Nodo origen aleatorio
            destino = (char)('A' + rand.Next(n)); // Nodo destino aleatorio
            distancia = rand.Next(1, 11); // Distancia aleatoria entre 1 y 10
            insertarArista(ref grafo, origen, destino, distancia);
        }

        Console.WriteLine();
        Console.WriteLine("Grafo generado:");
        Console.WriteLine();
        mostrarGrafo(grafo);

        Console.WriteLine();
        Console.WriteLine("--Dijkstra--");
        Console.WriteLine("Ingresa nodo origen:");
        origen = Console.ReadKey().KeyChar;
        dijkstra(grafo, origen);
        Console.WriteLine();
        mostrarDistanciasMinimas(grafo);

        Console.WriteLine();
        Console.WriteLine("Mostrar camino mínimo desde el nodo origen a un nodo destino");
        Console.WriteLine("Ingresa nodo destino:");
        destino = Console.ReadKey().KeyChar;
        mostrarCaminoMinimo(grafo, obtenerNodo(grafo, destino));
        
        Console.WriteLine();
        Console.WriteLine("Mostrar mensaje de alerta si no es posible ir del nodo origen a un nodo destino");
        Console.WriteLine("Ingresa nodo destino:");
        destino = Console.ReadKey().KeyChar;
        mostrarMensajeAlerta(grafo, obtenerNodo(grafo, destino));

        Console.ReadLine();
    }

    
    static Nodo obtenerNodo(Nodo grafo, char valor)
    {
        Nodo nodo = grafo;
        while (nodo != null && nodo.dato != valor)
        {
            nodo = nodo.sgte;
        }
        return nodo;
    }

    static Arista obtenerArista(Nodo nodoOrigen, Nodo nodoDestino)
    {
        Arista arista = nodoOrigen.ady;
        while (arista != null && arista.destino != nodoDestino)
        {
            arista = arista.sgte;
        }
        return arista;
    }

    static void insertarNodo(ref Nodo grafo, char valor)
    {
        if (obtenerNodo(grafo, valor) == null)
        {
            Nodo nuevoNodo = new Nodo();
            nuevoNodo.dato = valor;
            nuevoNodo.sgte = null;
            nuevoNodo.ady = null;

            if (grafo == null)
            {
                grafo = nuevoNodo;
            }
            else
            {
                Nodo nodoUltimo = grafo;
                while (nodoUltimo.sgte != null)
                {
                    nodoUltimo = nodoUltimo.sgte;
                }
                nodoUltimo.sgte = nuevoNodo;
            }
        }
    }

    static void insertarArista(ref Nodo grafo, char origen, char destino, int distancia)
    {
        Nodo nodoOrigen = obtenerNodo(grafo, origen);
        Nodo nodoDestino = obtenerNodo(grafo, destino);

        if (nodoOrigen != null && nodoDestino != null)
        {
            if (obtenerArista(nodoOrigen, nodoDestino) == null)
            {
                Arista nuevaArista = new Arista();
                nuevaArista.destino = nodoDestino;
                nuevaArista.distancia = distancia;
                nuevaArista.disponible = true; // Nueva arista está disponible
                nuevaArista.sgte = null;

                if (nodoOrigen.ady == null)
                {
                    nodoOrigen.ady = nuevaArista;
                }
                else
                {
                    Arista ultimaArista = nodoOrigen.ady;
                    while (ultimaArista.sgte != null)
                    {
                        ultimaArista = ultimaArista.sgte;
                    }
                    ultimaArista.sgte = nuevaArista;
                }
            }
        }
    }

    static void mostrarGrafo(Nodo grafo)
    {
        Nodo nodoActual = grafo;
        Arista aristaActual;

        while (nodoActual != null)
        {
            Console.Write(nodoActual.dato + " -> ");
            aristaActual = nodoActual.ady;

            while (aristaActual != null)
            {
                Console.Write(aristaActual.destino.dato + " (" + aristaActual.distancia + ") ");
                aristaActual = aristaActual.sgte;
            }

            Console.WriteLine();
            nodoActual =             nodoActual.sgte;
        }

        Console.WriteLine();
    }

    static void inicializarNodos(Nodo grafo)
    {
        Nodo nodoActual = grafo;
        while (nodoActual != null)
        {
            nodoActual.predecesor = null;
            nodoActual.distanciaFuente = MAX;
            nodoActual.estado = 'N';
            nodoActual = nodoActual.sgte;
        }
    }

    static void dijkstra(Nodo grafo, char origen)
    {
        Nodo nodoOrigen = obtenerNodo(grafo, origen);
        Nodo nodoMinimo;
        Nodo nodoDestino;
        Arista adyacencias;
        Arista aristaActual;

        inicializarNodos(grafo);

        if (nodoOrigen != null)
        {
            nodoOrigen.distanciaFuente = 0;

            while ((nodoMinimo = obtenerMinimo(grafo)) != null)
            {
                nodoMinimo.estado = 'V';
                adyacencias = nodoMinimo.ady;
                aristaActual = adyacencias;

                while (aristaActual != null)
                {
                    nodoDestino = aristaActual.destino;

                    if (nodoDestino.distanciaFuente > nodoMinimo.distanciaFuente + aristaActual.distancia)
                    {
                        nodoDestino.distanciaFuente = nodoMinimo.distanciaFuente + aristaActual.distancia;
                        nodoDestino.predecesor = nodoMinimo;
                    }

                    aristaActual = aristaActual.sgte;
                }
            }
        }
    }

    static Nodo obtenerMinimo(Nodo grafo)
    {
        Nodo nodoMinimo = null;
        Nodo nodoActual = grafo;
        int minimo = MAX;

        while (nodoActual != null)
        {
            if (nodoActual.estado == 'N' && nodoActual.distanciaFuente < minimo)
            {
                nodoMinimo = nodoActual;
                minimo = nodoMinimo.distanciaFuente;
            }
            nodoActual = nodoActual.sgte;
        }

        return nodoMinimo;
    }

    static void mostrarDistanciasMinimas(Nodo grafo)
    {
        Nodo nodoActual = grafo;
        while (nodoActual != null)
        {
            Console.Write("Valor: " + nodoActual.dato + " - Distancia mínima: ");
            if (nodoActual.distanciaFuente == MAX)
            {
                Console.Write("Infinito");
            }
            else
            {
                Console.Write(nodoActual.distanciaFuente);
            }
            Console.WriteLine();
            nodoActual = nodoActual.sgte;
        }
    }

    static void mostrarCaminoMinimo(Nodo nodoDestino)
    {
        if (nodoDestino.predecesor != null)
        {
            mostrarCaminoMinimo(nodoDestino.predecesor);
        }
        Console.Write(nodoDestino.dato + " ");
    }

    static void mostrarMensajeAlerta(Nodo nodoOrigen, Nodo nodoDestino)
    {
        if (!existeCamino(nodoOrigen, nodoDestino))
        {
            Console.WriteLine("No es posible ir desde el nodo " + nodoOrigen.dato + " al nodo " + nodoDestino.dato);
        }
    }

    static bool existeCamino(Nodo nodoOrigen, Nodo nodoDestino)
    {
        Nodo nodoActual = nodoOrigen;
        while (nodoActual != null)
        {
            if (nodoActual == nodoDestino)
            {
                return true;
            }
            nodoActual = nodoActual.predecesor;
        }
        return false;
    }
}

