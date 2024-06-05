from tkinter import *
import test1
import test2

root = Tk()
root.geometry("360x300")
root.title("3SS: Home Screen")
root.configure(bg='#add8e6')
encdec = Toplevel()
encdec.geometry("360x300")
encdec.title("3SS: Encrypt or Decrypt")
encdec.configure(bg='#add8e6')
encdec.withdraw()
hexdex = Toplevel()
hexdex.geometry("360x300")
hexdex.title("3SS: Hex to Dec / Dec to Hex")
hexdex.configure(bg='#add8e6')
hexdex.withdraw()

def nextstep():
    global root
    root.withdraw()
    encdec.deiconify()

def counter(event):
    global msg
    count = len(msg.get()) + 1
    countprt = Entry(root, width=3)
    countprt.grid(row=3, column=0)
    countprt.insert(0, count)
    
def hexdexconvert():
    global hexdex
    global root
    root.withdraw()
    hexdex.deiconify()

def encrypt():
    global msg
    global msg2
    global encout
    msgtxt = msg.get()
    msg2txt = msg2.get()
    encoutlbl = Label(encdec, text="Result ct", bg="#add8e6").grid(row=3, column=0)
    encout = Entry(encdec)
    encout.grid(row=4, column=0)
    val1 = str(test1.tester1(msgtxt, msg2txt))
    encout.insert(0, val1)
    
def decrypt():
    global msg
    global msg2
    global decout
    msgtxt = msg.get()
    msg2txt = msg2.get()
    decoutlbl = Label(encdec, text="Result pt", bg="#add8e6").grid(row=3, column=0)
    decout = Entry(encdec)
    decout.grid(row=4, column=0)
    val1 = str(test2.tester2(msgtxt, msg2txt))
    decout.insert(0, val1)

def converter():
    global hexdex
    global nin
    global basein
    n = nin.get()
    sb = basein.get()
    dexoutlbl = Label(hexdex, text="Hex/Dec Value (Copy and paste this)", bg="#add8e6").grid(row=7, column=0)
    dexout = Entry(hexdex)
    dexout.grid(row=8, column=0)
    conval = str(conv(n, int(sb)))
    dexout.insert(0, conval)

def conv(n, sb):
    if sb == 10:
        conval = hex(int(n))[2:].upper()
        return conval
    else:
        conval = int("0x"+n, 16)
        return conval

def homescrn():
    global root
    global encdec
    global hexdex
    global msg
    global msg2
    encdec.withdraw()
    hexdex.withdraw()
    root.deiconify()
    msg.delete(0, END)
    msg2.delete(0, END)
    encout.delete(0, END)
    decout.delete(0, END)

closebtn = Button(root, text="Click This When Done", command = nextstep, width = 20, height = 4, bg = "Orange", fg = "Black").grid(row=6, column=0)
msglbl = Label(root, text="pt/ct", bg="#add8e6").grid(row=0, column=0)
msg = Entry(root, width=40)
msg.grid(row=1, column=0)
msglbl2 = Label(root, text="key", bg="#add8e6").grid(row=4, column=0)
msg2 = Entry(root, width=10)
msg2.grid(row=5, column=0)
hexdexbut = Button(root, text="Hex/Dec Converter", command = hexdexconvert, width = 20, height = 4, bg = "Blue", fg = "White").grid(row=7, column=0)

enc = Button(encdec, text="Click for Encryption", command = encrypt, width = 20, height = 4, bg = "Green", fg = "Black").grid(row=1, column=0)
dec = Button(encdec, text="Click for Decryption", command = decrypt, width = 20, height = 4, bg = "Red", fg = "Black").grid(row=2, column=0)

convertbut = Button(hexdex, text="Convert", command = converter, width = 20, height = 4, bg = "Blue", fg = "White").grid(row=1, column=0)
dexhexinlbl = Label(hexdex, text="Dec/Hex Input (Exclude 0x for base 16 and all letters must be CAPS)", bg="#add8e6").grid(row=3, column=0)
nin = Entry(hexdex)
nin.grid(row=4, column=0)
baseinplbl = Label(hexdex, text="Base input (10 or 16)", bg="#add8e6").grid(row=5, column=0)
basein = Entry(hexdex)
basein.grid(row=6, column=0)
msg.bind("<Key>", counter)
encdecreturn = Button(encdec, text = "Return to Home Screen", command = homescrn, width = 20, height = 4, bg = "Yellow", fg = "Black").grid(row=10, column=0)
hexdexreturn = Button(hexdex, text = "Return to Home Screen", command = homescrn, width = 20, height = 4, bg = "Yellow", fg = "Black").grid(row=10, column=0)

root.mainloop()
encdec.mainloop()
hexdex.mainloop()
