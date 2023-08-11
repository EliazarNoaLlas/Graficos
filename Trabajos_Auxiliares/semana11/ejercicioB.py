# Paso 1: Ingreso de elementos en la lista A
N = int(input("Ingrese la cantidad de elementos en la lista A: "))
A = []
for i in range(N):
    elemento = int(input("Ingrese el elemento {}: " % (i+1)))
    A.append(elemento)

# Paso 2: Ingreso del número dado
numero_dado = int(input("Ingrese el número: "))

# Paso 3: Creación de la lista B
B = []

# Paso 4 y 5: Verificación de números iguales y almacenamiento de posiciones
for i in range(len(A)):
    num = A[i]
    if num == numero_dado:
        B.append(i+1)

# Paso 6: Mostrar la lista resultante B
print("Lista resultante B: ", B)

'''
caso de prueba:
Ingrese la cantidad de elementos en la lista A: 8
Ingrese el elemento 1: 4
Ingrese el elemento 2: 6
Ingrese el elemento 3: 8
Ingrese el elemento 4: 2
Ingrese el elemento 5: 6
Ingrese el elemento 6: 9
Ingrese el elemento 7: 6
Ingrese el elemento 8: 1
Ingrese el número: 6
Lista resultante B:  [2, 5, 7]
'''
