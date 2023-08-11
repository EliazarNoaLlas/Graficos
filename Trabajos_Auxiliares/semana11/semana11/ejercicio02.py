edades = [13,20,18,30,50]

for i in range(len(edades)): 
    print(edades[i])


suma = 0
for i in range(len(edades)):
    suma = suma + edades[i]

print("LA SUMA ES : ",suma)

cant_mayores = 0
for i in range(len(edades)):
    if edades[i]>=18:
        cant_mayores +=1

print("LA CANTIDAD DE MAYORES ES : ",cant_mayores)

cant_menores = 0

for i in range(len(edades)):
    if edades[i]<18:
        cant_menores += 1

print("LA CANTIDAD DE MENORES ES : ",cant_menores)