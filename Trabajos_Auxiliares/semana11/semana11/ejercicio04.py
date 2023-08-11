cantidad = int(input("INGRESE CANTIDAD DE EDADES : "))

lista_edades = []

for i in range(cantidad):
    edad=int(input("INGRESE EDAD : "))
    lista_edades.append(edad)

for i in range(cantidad):
    print(lista_edades[i])