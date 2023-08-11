# Paso 1: Creación de la lista de ventas diarias
ventas_diarias = []

# Paso 2: Ingreso de las ventas diarias
for dia in range(1, 8):
    venta = float(input("Ingrese el monto de venta para el día {}: ".format(dia)))
    ventas_diarias.append(venta)

# Paso 3: Visualización de las ventas diarias
print("Ventas diarias:")
for dia in range(len(ventas_diarias)):
    print("Día", dia+1, ":", "$", ventas_diarias[dia])

# Paso 4: Monto de venta mayor y menor
monto_venta_mayor = max(ventas_diarias)
monto_venta_menor = min(ventas_diarias)

# Paso 5: Día de realización de la venta mayor y menor
dia_venta_mayor = ventas_diarias.index(monto_venta_mayor) + 1
dia_venta_menor = ventas_diarias.index(monto_venta_menor) + 1

# Paso 6: Total de ventas semanales
total_ventas_semana = sum(ventas_diarias)

# Paso 7: Promedio de ventas
promedio_ventas = total_ventas_semana / len(ventas_diarias)

# Paso 8: Mostrar los resultados
print("Monto de venta mayor: $", monto_venta_mayor, "(Día", dia_venta_mayor, ")")
print("Monto de venta menor: $", monto_venta_menor, "(Día", dia_venta_menor, ")")
print("Total de ventas semanales: $", total_ventas_semana)
print("Promedio de ventas: $", promedio_ventas)

'''
caso de prueba:
Ingrese el monto de venta para el día 1: 40
Ingrese el monto de venta para el día 2: 50
Ingrese el monto de venta para el día 3: 30
Ingrese el monto de venta para el día 4: 10
Ingrese el monto de venta para el día 5: 40
Ingrese el monto de venta para el día 6: 20
Ingrese el monto de venta para el día 7: 30
Ventas diarias:
Día 1 : $ 40.0
Día 2 : $ 50.0
Día 3 : $ 30.0
Día 4 : $ 10.0
Día 5 : $ 40.0
Día 6 : $ 20.0
Día 7 : $ 30.0
Monto de venta mayor: $ 50.0 (Día 2 )
Monto de venta menor: $ 10.0 (Día 4 )
Total de ventas semanales: $ 220.0
Promedio de ventas: $ 31.428571428571427'''