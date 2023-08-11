cantidad_productos=int(input("INGRESE CANTIDAD DE PRODUCTOS : "))

lista_productos = []
lista_precios = []

#INGRESO DE DATOS
for i in range(cantidad_productos):
    producto = input("PRODUCTO  : ")
    lista_productos.append(producto)
    precio = float(input("PRECIO : "))
    lista_precios.append(precio)


#LISTAR DATOS
for i in range(cantidad_productos):
    print("PRODUCTO : ",lista_productos[i], " PRECIO : ",lista_precios[i])

#PRODUCTO CON MAYOR PRECIO
mayor_precio = -1
mayor_posicion = -1
#mayor_producto = ""
for i in range(cantidad_productos):
    if lista_precios[i]>mayor_precio:
        mayor_precio=lista_precios[i]
        mayor_posicion = i
        #mayor_producto=lista_productos[i]


print("PRODUCTO : ",lista_productos[mayor_posicion]," CON MAYOR PRECIOS DE : ",mayor_precio)



