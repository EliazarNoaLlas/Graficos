# ingresar una cantidad de numeros enteros y realizar lo siguiente:
# listar los elementos
# hallar el mayor y menor
# reportar el promedio de nuemros
#reportar cuanttos son pares e impares
# almacenar en otra lista todos los numeros primos
# almacenar en dos listas los numeros multiplos de 5 y de 3


cantidad = int(input("INGRESE CANTIDAD DE NUMEROS : "))
lista_numeros=[]

#INGRRESO DE DATOS
for i in range(cantidad):
    numero=int(input("NUMERO : "))
    lista_numeros.append(numero)
print("LISTADO DE NUMEROS")

#LISTADO DE DATOS
for i in range(cantidad):
    print(lista_numeros[i])

# mayor y menor
mayor = -99999999999
menor = 999999999999

for i in range(cantidad):
    if lista_numeros[i]>mayor:
        mayor=lista_numeros[i]
    
    if lista_numeros[i]<menor:
        menor=lista_numeros[i]

print("MAYOR : ",mayor)
print("MENOR ; ",menor)

#promedio 
suma = 0

for i in range(cantidad):
    suma +=lista_numeros[i]

promedio = suma/cantidad

print("EL PROMEDIO ES . ",promedio)

#pares e impares
cant_pares = 0
cant_impares = 0

for i in range(cantidad):
    if lista_numeros[i]%2==0:
        cant_pares+=1
    else:
        cant_impares +=1

print("CANTIDAD DE PARES : ",cant_pares)
print("CANTIDAD DE IMAPRES : ",cant_impares)

#numeros primos

lista_primos = []

for i in range(cantidad):
    can_divisores = 0
    for j in range(1,lista_numeros[i]+1):
        if lista_numeros[i]%j==0:
            can_divisores +=1

    if can_divisores==2:
        lista_primos.append(lista_numeros[i])

print("LISTA DE NUMEROS PRIMOS")
for j in range(len(lista_primos)):
    print(lista_primos[j])


#multiplos de 5 y multiplos de 3
lista_mult_5 = []
lista_mult_3 = []

for i in range(cantidad):
    if lista_numeros[i]%5 == 0:
        lista_mult_5.append(lista_numeros[i])
    
    if lista_numeros[i]%3 == 0:
        lista_mult_3.append(lista_numeros[i])

print("LISTA DE MULTIPLOS DE 5")
for j  in range(len(lista_mult_5)):
    print(lista_mult_5[j])
print("LISTA DE MULTIPLOS DE 3")
for j in range(len(lista_mult_3)):
    print(lista_mult_3[j])