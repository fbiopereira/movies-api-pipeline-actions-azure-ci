# Movies API

Projeto .Net que usa o GitHub Actions para entregar a aplicação em um Azure Container Apps

## Índice
- [Movies API](#clínica-alô-doutor)
    - [Sobre](#sobre) 
    - [Integrantes](#integrantes)  
    - [Tecnologias Utilizadas](#tecnologias-utilizadas)
    - [Solução](#solução)
        - [Como Executar o Projeto](#como-executar-o-projeto)
            -[Execução com Docker (recomendada)](#execução-com-docker-recomendada)
            -[Execução local](#execução-local)

## Sobre
Este projeto faz parte do trabalho de conclusão da segunda fase da POSTECH FIAP de Arquitetura de Sistemas .Net com Azure.

[voltar](#índice)

## Integrantes

| Nome | RM | 
------------ | ------------- 
Alex Jussiani Junior | 350671 
Erick Setti dos Santos | 351206 
Fábio da Silva Pereira | 351053 
Lucas Santana de Souza | 351891  
Richard Kendy Tanaka| 351234 

[voltar](#índice)

## Tecnologias Utilizadas

| Tecnologias | Uso
------------ | -------------
[C#](https://docs.microsoft.com/en-us/dotnet/csharp/) | Linguagem de Programação
[.NET](https://dotnet.microsoft.com/) | Framework web
[Serilog](https://serilog.net/) | Captura de Logs
[Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) | Editor de Código
[Docker](https://www.docker.com/) | Criação de Containers

[voltar](#índice)

## Solução
Desenvolvimento de uma Web Api em .NET Core 6 que é entregue no docker hub e no azure container apps.

[voltar](#índice)

## Como Executar o Projeto

Execute o projeto utilizando o Docker. Para isso siga os passos abaixo:

1- Se você estiver no Windows instale o [WSL](https://learn.microsoft.com/pt-br/windows/wsl/install)

2- Instale o [Docker Desktop](https://www.docker.com/products/docker-desktop/)

3- Clone o repositório

4- No terminal vá até a pasta raiz do projeto e execute o comando `docker-compose up -d` para executar o container da aplicação

6- Abra o navegador e acesse:
    -  [http://localhost:9393/swagger](http://localhost:9393/swagger) para a documentação da API

[voltar](#índice)

## Como a pipeline funciona

A pipeline do GitHub Actions é disparada quando um push é feito nas seguintes branches:
    - main
    - Develop
    - feature/*
    - release/*
    
Ela executa os seguintes passos:
    - Build da imagem docker
        - O tageamento da imagem é feito de acordo com a branch: 
            - main: hml-{hash do commit}
            - Develop: stg-{hash do commit}
            - feature/*: dev-{hash do commit}
            - release/*: {tag da release}

    - Push da imagem docker para o Docker Hub
    - Deploy da imagem docker no Azure Container Apps

Após o deploy no Azure Container Apps, a aplicação pode ser acessada através da URL do swagger da aplicação.

No swagger é possível testar a API e verificar a versão publicada de acordo com a regra da pipeline.

[voltar](#índice)
