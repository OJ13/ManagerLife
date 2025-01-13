FROM ubuntu:20.04

# Instalar dependencias
RUN apt-get update && apt-get install -y \
    curl \
    nginx \
    && rm -rf /var/lib/apt/lists/*

# Pasta de Upload de arquivos
RUN mkdir -p /var/www/uploads

# Pasta de trabalho
WORKDIR /var/www/uploads

# Porta
EXPOSE 80

# Iniciando servidor
CMD ["nginx", "-g", "daemon off;"]