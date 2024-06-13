def conv(n, sb):
    # n = number
    # sb = starting base
    if sb == 10:
        return hex(int(n))[2:].upper()
    else:
        return int("0x"+n, 16)