edades = [13,20,18,30,50]

# listar datos 
for i in range(len(edades)): 
    print(edades[i])

#insertar elementos 

edades.append(44)
edades.append(80)

# listar datos 
for i in range(len(edades)): 
    print(edades[i])

edades.insert(3,28)

# listar datos 
for i in range(len(edades)): 
    print(edades[i])