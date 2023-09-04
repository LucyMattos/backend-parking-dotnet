## Introdução

O **EstacionamentoAPI** é uma API REST desenvolvida em .NET 6 para gerenciar um estacionamento de carros e motos através de CRUD.

## Tecnologias utilizadas

- .NET 6
- Entity Framework Core
- AutoMapper
- Injeção de dependência
- Notification Pattern
- Swagger
- Postman

## Pré requisitos

- IDE Visual Studio (Recomendado) ou uma IDE ou editor de código fonte de sua preferência;
- Entity Framework Core;
- Banco de dados SQL Server instalado na máquina;

## Configurando o ambiente

 1- Clonar o reposiório para sua máquina;
 2- Conectar com o banco de dados SQL Server:
    - Crie um banco de dados com o nome de "EstacionamentoDB"
    - No Visual Studio, no terminal Package Manager Console utilize o comando "update-database" executar as migrations do projeto e atualizar no banco de dados. 
 4- Para finalizar, no Visual Studio execute a aplicação utilizando a tecla F5 do teclado.

## Considerações sobre a aplicação:

- Para realizar as chamadas aos endpoints é necessário autenticar-se atráves de API Key. Para isso basta utilizar o Postman e enviar a chave no header de cada requisição. Na aplicação, a chave "EstacionamentoApiKey" encontra-se no arquivo "appsettings.Development.json", dentro da camada principal "EstacionamentoAPI".
Feito isso basta inserir chave e valor no header de cada requisição junto com os demais parâmetros necessários para realizar a chamada à API. Para consultar os endpoints consulte a documentação no Swagger.

- Na API Veículo, no request body dos endpoints de POST e PUT de veículo, os campos "tipo": "string" e "tipoVeiculoEnum": "Carro" referem-se ao tipo do veículo,Carro ou Moto. Há apenas estes dois tipos de veículo na aplicação. No banco de dados o campo "Tipo" aparece como Carro = 0 ou  Moto = 1 ; 
