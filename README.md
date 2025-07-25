# CDB Yield Calculator

Aplicação full-stack que calcula o rendimento bruto e líquido de um CDB (Certificado de Depósito Bancário) com base no valor investido e no período em meses.

## Funcionalidades

. Cálculo automático do rendimento bruto e líquido de CDB  
. Interface responsiva com Angular  
. Comunicação via API REST  
. Totalmente dockerizado e pronto para execução local  

## Tecnologias

Front-end: Angular 20
Back-end: ASP.NET Core (.NET 8) — container Docker
Containerização: Docker

### .Estrutura do Projeto  

```
├── CdbFront/              # Aplicação Angular
│   └── Dockerfile
├── CdbBack/               # Aplicaçã API .NET
│   └── Dockerfile
├── iniciar-app.bat        # Inicia os serviços
├── docker-compose.yml     # Orquestração dos serviços 
├── CdbSolution.sln        # Solução 
└── README.md              # Este arquivo
```

## Execução

Você pode iniciar ambos os serviços manualmente, usando docker-compose, ou simplesmente executando o arquivo **iniciar-app.bat**.

### .Docker Compose

Na raiz do projeto, execute:

```
bash

docker-compose up --build
```

### .Manualmente

1️⃣ Front-end (Angular)
A partir da pasta CdbFront:

```
bash

docker build -t cdb-frontend .
docker run -d -p 4200:80 cdb-frontend
```

2️⃣ Back-end (API .NET Core)
A partir da pasta CdbBack:

```
bash

docker build -t cdb-api .
docker run -d -p 5050:8080 cdb-backend
```

## API REST – Detalhes da Requisição

Método: POST  
URL: http://localhost:5050/api/cdb/yield  
Content-Type: application/json  

### .Request   

|Propriedade|Tipo|Valores Aceitos|Obrigatório|
|---|---|---|---|
|value|Decimal|Valor numérico positivo (ex: 1000.99)|Sim|
|months|Int|Inteiro positivo ≥ 1 (ex: 12)|Sim|

Exemplo de Request:
```
json
{
  "value": 212, 
  "months": 5 
}
```

### .Response
|Propriedade|Tipo|Valores Aceitos|Obrigatório|
|---|---|---|---|
|statusCode|Inteiro|Valor numérico positivo (ex: 200)|Sim|
|data: grossAmount|Decimal|Inteiro positivo (ex: 1000.99)|Não|
|data: grossAmount|Decimal|Inteiro positivo (ex: 1000.99)|Não|
|errorMessage|String|Texto (ex: "erro 500")|Não|

Exemplo de Response em caso de sucesso:
```
json
{
    "statusCode": 200, 
    "data": {
        "grossAmount": 222.51, 
        "netAmount": 220.14 
    },
    "errorMessage": null
}
```
Exemplo de Response em caso de bad request:
```
json
{
    "statusCode": 400,
    "data": null,
    "errorMessage": "The 'months' property must be at least 1. "
}
```
Exemplo de Response em caso de falha:
```
json
{
    "statusCode": 500, 
    "data": null,
    "errorMessage": Ocorreu um erro inesperado no servidor."
}
```

### .Postman

Para realizar testes utilize o cURL abaixo
```
curl --location 'http://localhost:5050/api/cdb/yield' \
--header 'Content-Type: application/json' \
--data '{
    "value":100,
    "months":1
}'
```
## Front-end Angular

- Acesse: http://localhost:4200  
- Introduza os valor do patrimônio a ser investido, deve ter valor positivo e no máximo duas casas decimais (ex:100,99)  
- Introduza o período em meses, deve ser maior que 1(ex:3)  
- Clique no botão "Calcular"
- O resultado dos rendimentos bruto e líquido aparececerá na parte inferior da calculadora

### .Testes Unitários

Para executar os testes unitários, a partir da pasta CdbFront execute  

```
bash

ng test
```

