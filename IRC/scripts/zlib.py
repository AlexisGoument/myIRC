import zlib
import sys
import base64

a = sys.argv[1]
print(a)

b = a.encode()

c = base64.b64decode(b)
print(c)
z = list(c)
print(z)

d = zlib.decompress(c)
print(d.decode())
