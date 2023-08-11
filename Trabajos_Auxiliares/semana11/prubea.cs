#include <iostream>
using namespace std;

const int MAX = 999999;

struct Arista;
struct Nodo {
    char dato;
    Nodo* sgte;
    Arista* ady;
    int distanciaFuente;
    Nodo* predecesor;
    char estado;
};

struct Arista {
    Nodo* destino;
    Arista* sgte;
    int distancia;
    bool disponible; // Nueva bandera que indica si la arista está disponible
};


Nodo* obtenerNodo(Nodo*, char);
Arista* obtenerArista(Nodo*, Nodo*);
void insertarNodo(Nodo*&, char);
void insertarArista(Nodo*&, char, char, int);
void mostrarGrafo(Nodo*);
void inicializarNodos(Nodo*);
void dijkstra(Nodo*, char);
Nodo* obtenerMinimo(Nodo*);
void mostrarDistanciasMinimas(Nodo*);
void mostrarCaminoMinimo(Nodo*, Nodo*);
void mostrarMensajeAlerta(Nodo*, Nodo*);
bool existeCamino(Nodo*, Nodo*);

int main(int argc, char* argv[]) {
    Nodo* grafo = nullptr;
    char valor, origen, destino;
    int n = 10; // Número de nodos
    int a = 15; // Número de aristas
    int distancia;

    cout << "Generando grafo aleatorio..." << endl;

    srand(time(NULL));

    // Generar nodos
    for (int i = 0; i < n; i++) {
        valor = 'A' + i;
        insertarNodo(grafo, valor);
    }

    // Generar aristas
    for (int i = 0; i < a; i++) {
        origen = 'A' + rand() % n; // Nodo origen aleatorio
        destino = 'A' + rand() % n; // Nodo destino aleatorio
        distancia = rand() % 10 + 1; // Distancia aleatoria entre 1 y 10
        insertarArista(grafo, origen, destino, distancia);
    }

    cout << endl << "Grafo generado: " << endl << endl;
    mostrarGrafo(grafo);

    cout << endl << "--Dijkstra--" << endl;
    cout << "Ingresa nodo origen:" << endl;
    cin >> origen;
    dijkstra(grafo, origen);
    mostrarDistanciasMinimas(grafo);

    cout << endl << "Mostrar camino mínimo desde el nodo origen a un nodo destino" << endl;
    cout << "Ingresa nodo destino:" << endl;
    cin >> destino;
    mostrarCaminoMinimo(grafo, obtenerNodo(grafo, destino));

    cout << endl << "Mostrar mensaje de alerta si no es posible ir del nodo origen a un nodo destino" << endl;
    cout << "Ingresa nodo destino:" << endl;
    cin >> destino;
    mostrarMensajeAlerta(grafo, obtenerNodo(grafo, destino));

    return 0;

}

Nodo* obtenerNodo(Nodo* grafo, char valor) {
    Nodo* nodo = grafo;
    while (nodo != nullptr && nodo->dato != valor) {
        nodo = nodo->sgte;
    }
    return nodo;
}

Arista* obtenerArista(Nodo* nodoOrigen, Nodo* nodoDestino) {
    Arista* arista = nodoOrigen->ady;
    while (arista != nullptr && arista->destino != nodoDestino) {
        arista = arista->sgte;
    }
    return arista;
}

void insertarNodo(Nodo*& grafo, char valor) {
    if (obtenerNodo(grafo, valor) == nullptr) {
        Nodo* nuevoNodo = new Nodo;
        nuevoNodo->dato = valor;
        nuevoNodo->sgte = nullptr;
        nuevoNodo->ady = nullptr;

        if (grafo == nullptr) {
            grafo = nuevoNodo;
        } else {
            Nodo* nodoUltimo = grafo;
            while (nodoUltimo->sgte != nullptr) {
                nodoUltimo = nodoUltimo->sgte;
            }
            nodoUltimo->sgte = nuevoNodo;
        }
    }
}

void insertarArista(Nodo*& grafo, char origen, char destino, int distancia) {
    Nodo* nodoOrigen = obtenerNodo(grafo, origen);
    Nodo* nodoDestino = obtenerNodo(grafo, destino);

    if (nodoOrigen != nullptr && nodoDestino != nullptr) {
        if (obtenerArista(nodoOrigen, nodoDestino) == nullptr) {
            Arista* nuevaArista = new Arista;
            nuevaArista->destino = nodoDestino;
            nuevaArista->distancia = distancia;
            nuevaArista->disponible = true; // Nueva arista está disponible
            nuevaArista->sgte = nullptr;

            if (nodoOrigen->ady == nullptr) {
                nodoOrigen->ady = nuevaArista;
            } else {
                Arista* ultimaArista = nodoOrigen->ady;
                while (ultimaArista->sgte != nullptr) {
                    ultimaArista = ultimaArista->sgte;
                }
                ultimaArista->sgte = nuevaArista;
            }
        }
    }
}

void mostrarGrafo(Nodo* grafo) {
    Nodo* nodoActual = grafo;
    Arista* aristaActual;

    while (nodoActual != nullptr) {
        cout << nodoActual->dato << " -> ";
        aristaActual = nodoActual->ady;

        while (aristaActual != nullptr) {
            cout << aristaActual->destino->dato << " (" << aristaActual->distancia << ") ";
            aristaActual = aristaActual->sgte;
        }

        cout << endl;
        nodoActual = nodoActual->sgte;
    }

    cout << endl;
}

void inicializarNodos(Nodo* grafo) {
    Nodo* nodoActual = grafo;
    while (nodoActual != nullptr) {
        nodoActual->predecesor = nullptr;
        nodoActual->distanciaFuente = MAX;
        nodoActual->estado = 'N';
        nodoActual = nodoActual->sgte;
    }
}

void dijkstra(Nodo* grafo, char origen) {
    Nodo* nodoOrigen = obtenerNodo(grafo, origen);
    Nodo* nodoMinimo;
    Nodo* nodoDestino;
    Arista* adyacencias;
    Arista* aristaActual;

    inicializarNodos(grafo);

    if (nodoOrigen != nullptr) {
        nodoOrigen->distanciaFuente = 0;

        while (nodoMinimo = obtenerMinimo(grafo)) {
            nodoMinimo->estado = 'V';
            adyacencias = nodoMinimo->ady;
            aristaActual = adyacencias;

            while (aristaActual != nullptr) {
                nodoDestino = aristaActual->destino;

                if (nodoDestino->distanciaFuente > nodoMinimo->distanciaFuente + aristaActual->distancia) {
                    nodoDestino->distanciaFuente = nodoMinimo->distanciaFuente + aristaActual->distancia;
                    nodoDestino->predecesor = nodoMinimo;
                }

                aristaActual = aristaActual->sgte;
            }
        }
    }
}

Nodo* obtenerMinimo(Nodo* grafo) {
    Nodo* nodoMinimo = nullptr;
    Nodo* nodoActual = grafo;
    int minimo = MAX;

    while (nodoActual != nullptr) {
        if (nodoActual->estado == 'N' && nodoActual->distanciaFuente < minimo) {
            nodoMinimo = nodoActual;
            minimo = nodoMinimo->distanciaFuente;
        }
        nodoActual = nodoActual->sgte;
    }

    return nodoMinimo;
}

void mostrarDistanciasMinimas(Nodo* grafo) {
    Nodo* nodoActual = grafo;
    while (nodoActual != nullptr) {
        cout << "Valor: " << nodoActual->dato << " - Distancia mínima: ";
        if (nodoActual->distanciaFuente == MAX) {
            cout << "Infinito";
        } else {
            cout << nodoActual->distanciaFuente;
        }
        cout << endl;
        nodoActual = nodoActual->sgte;
    }
}


void mostrarCaminoMinimo(Nodo* nodoDestino) {
    if (nodoDestino->predecesor != nullptr) {
        mostrarCaminoMinimo(nodoDestino->predecesor);
    }
    cout << nodoDestino->dato << " ";
}

void mostrarMensajeAlerta(Nodo* nodoOrigen, Nodo* nodoDestino) {
    if (!existeCamino(nodoDestino)) {
        cout << "No es posible ir desde el nodo " << nodoOrigen->dato << " al nodo " << nodoDestino->dato << endl;
    }
}

bool existeCamino(Nodo* nodoDestino) {
return nodoDestino->distanciaFuente != MAX;
}
bool existeCamino(Nodo* nodoOrigen, Nodo* nodoDestino) {
    Nodo* nodoActual = nodoOrigen;
    while (nodoActual != nullptr) {
        if (nodoActual == nodoDestino) {
            return true;
        }
        nodoActual = nodoActual->predecesor;
    }
    return false;
}