# Paso 1: Ingreso de elementos en la lista A
N = int(input("Ingrese la cantidad de elementos en la lista A: "))
A = []
for i in range(N):
    elemento = int(input("Ingrese el elemento {}: ".format(i+1)))
    A.append(elemento)

# Paso 2: Creación de la lista B
B = []

# Paso 3 y 4: Cálculo de la suma de elementos opuestos
for i in range(N // 2):
    suma = A[i] + A[-i-1]
    B.append(suma)

# Paso 6: Agregar el elemento del medio si la lista A tiene una longitud impar
if N % 2 != 0:
    B.append(A[N // 2])

# Paso 7: Mostrar la lista resultante B
print("Lista resultante B: ", B)

''''
caso de prueba:
Ingrese la cantidad de elementos en la lista A: 7
Ingrese el elemento 1: 9
Ingrese el elemento 2: 5
Ingrese el elemento 3: 3
Ingrese el elemento 4: 10
Ingrese el elemento 5: 2
Ingrese el elemento 6: 8
Ingrese el elemento 7: 1
Lista resultante B:  [10, 13, 5, 10]
'''