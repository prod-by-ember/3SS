from random import *

vals = ["ABCDE", "0123456789", "ABCDE", "01", "ABC", "01234"]

print(vals[0][randint(0,4)] + vals[1][randint(0,9)], end="")
print(vals[2][randint(0,4)] + vals[3][randint(0,1)], end="")
print(vals[2][randint(0,4)] + vals[3][randint(0,1)], end="")
print(vals[4][randint(0,2)] + vals[5][randint(0,4)], end="")