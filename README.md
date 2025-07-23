
### CDB Yield Calculator

Aplicação full stack que calcula o rendimento bruto e líquido de um CDB (Certificado de Depósito Bancário), com interface em Angular e lógica de cálculo via API .NET Framework 4.8.

## Tecnologias
Frontend: Angular 20

Backend: ASP.NET (.NET Framework 4.8)

Containerização: Docker

Servidor de desenvolvimento:

-Frontend → Porta 4200

-API → Porta 44347

## Estrutura do Projeto
/
├── CdbFront/            # Angular 20 app
│   └── Dockerfile
├── CdbBack/ 
│   └── Publish          # API publicada para IIS Express
├── iniciar-app.bat      # Script para subir ambos os serviços
├── CdbSolution.sln      # Solução com ambos os serviços
└── README.md            # Esse arquivo

##  Executando o projeto

# Script de inicialização

Você pode usar o iniciar-app.bat para:

Iniciar o IIS Express apontando para a API publicada

Buildar e rodar o contêiner Angular na porta 4200 automaticamente no navegador

Manter a janela do terminal ativa com logs

Ou manualmente conforme os passos 1 e 2 a seguir


1. Frontend (Angular)

A partir da pasta CdbFront

bash
docker build -t angular-frontend .
docker run -d -p 4200:80 angular-frontend

Acesse: http://localhost:4200

2. CdbBack (API .NET Framework)

Configure o IIS manualmente para apontar para a pasta Publish.

Acesse via requisição POST:

http://localhost:44347/api/cdb/yield

# API REST – Detalhes da Requisição

Requisição POST
URL: http://localhost:44347/api/cdb/yield
Content-Type: application/json

Request Json:

{
  "value": 1000.00,
  "months": 12
}

Response Json: 

{
  "amountgross": 1137.84,
  "amountnet": 1101.32
}

## Funcionalidades

Cálculo automático do rendimento bruto e líquido de CDB com base em valor e tempo

Interface responsiva em Angular

Comunicação via API REST

Totalmente dockerizado e fácil de rodar em ambiente local