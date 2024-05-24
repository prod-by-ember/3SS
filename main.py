from random import *

f = open("temp.txt", "w")

count = 0
while count < 50:
    a = randint(0, 28)
    b = randint(0, 28)
    c = randint(0, 28)
    d = randint(0, 28)
    
    if (a * d) - (b * c) != 0 and (a * d) - (b * c) != 29:
        f.write(f"[{a} {b}]\n[{c} {d}]\n\n")
        count += 1