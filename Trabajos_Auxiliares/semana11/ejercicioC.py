# Paso 1: Ingreso de la cantidad de ventas
cantidad_ventas = int(input("Ingrese la cantidad de ventas: "))

# Paso 2 y 3: Ingreso de las ventas
ventas = []
for i in range(cantidad_ventas):
    venta = float(input("Ingrese el valor de la venta {}: ".format(i+1)))
    ventas.append(venta)

# Paso 4: Suma total de las ventas
suma_ventas = 0
for venta in ventas:
    suma_ventas += venta

# Paso 5: Promedio de las ventas
promedio_ventas = suma_ventas / cantidad_ventas

# Paso 6: Inicialización de variables
debajo_promedio = 0
encima_promedio = 0
igual_promedio = 0

# Paso 7: Cálculo de cantidad de ventas debajo, encima e iguales al promedio
for venta in ventas:
    if venta < promedio_ventas:
        debajo_promedio += 1
    elif venta > promedio_ventas:
        encima_promedio += 1
    else:
        igual_promedio += 1

# Paso 8: Mostrar los resultados
print("Suma total de las ventas:", suma_ventas)
print("Promedio de las ventas:", promedio_ventas)
print("Cantidad de ventas debajo del promedio:", debajo_promedio)
print("Cantidad de ventas encima del promedio:", encima_promedio)
print("Cantidad de ventas iguales al promedio:", igual_promedio)

'''
caso de prueba:
Ingrese la cantidad de ventas: 3
Ingrese el valor de la venta 1: 30
Ingrese el valor de la venta 2: 50
Ingrese el valor de la venta 3: 60
Suma total de las ventas: 140.0
Promedio de las ventas: 46.666666666666664
Cantidad de ventas debajo del promedio: 1
Cantidad de ventas encima del promedio: 2
Cantidad de ventas iguales al promedio: 0
'''
