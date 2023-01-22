
# create the rootCA.keyand rootCA.crt
openssl req -x509 \
            -sha256 -days 356 \
            -nodes \
            -newkey rsa:2048 \
            -subj "/CN=demo.example.com/C=US/L=Baton Rouge" \
            -keyout rootCA.key -out rootCA.crt 

# -------------------------------------------------------
# ecdsa certificate which can be used for signing only 
# -------------------------------------------------------

# find your curve
openssl ecparam -list_curves

# generate a private key for a curve
openssl ecparam -name prime256v1 -genkey -noout -out privateEcdsa-key.pem

# generate corresponding public key
openssl ec -in privateEcdsa-key.pem -pubout -out publicEcdsa-key.pem

# optional: create a self-signed certificate
openssl req -new -x509 -key privateEcdsa-key.pem -out certEcdsa.pem -days 360

# optional: convert pem to pfx
openssl pkcs12 -export -inkey privateEcdsa-key.pem -in certEcdsa.pem -out certEcdsa.pfx


# ---------------------------------------------------------------
# rsa certificate which can be used for signing and/or encryption 
# ---------------------------------------------------------------

# generate a private key with the correct length
openssl genrsa -out private-key.pem 3072

# generate corresponding public key
openssl rsa -in privateRsa-key.pem -pubout -out publicRsa-key.pem

# optional: create a self-signed certificate
openssl req -new -x509 -key privateRsa-key.pem -out certRsa.pem -days 360

# optional: convert pem to pfx
openssl pkcs12 -export -inkey privateRsa-key.pem -in certRsa.pem -out certRsa.pfx