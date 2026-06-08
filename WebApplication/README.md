# WebApplication API

API desenvolvida em **.NET 10**, utilizando arquitetura em camadas (Clean Architecture) e DDD (Domain-Driven Design), com autenticação JWT, MongoDB (Atlas), mensageria com RabbitMQ e envio de e-mails via SendGrid. Tudo integrado com front-end puro. A ideia é criar um pequeno microserviço de disparo de e-mails através de uma página de captura de dados (formulário). Nesse projeto, criei um nome fictício para representar o tipo de serviço requisitado, denominado **PathBank.**

## Link do Desafio e Critérios

Você pode acessar o desafio e os critérios utilizados no desenvolvimento através do link abaixo:

- **Desafio:** github.com/pathbit/pathbit-dotnet-test-level-2



# Arquitetura do Projeto:

O projeto segue o padrão **Clean Architecture**, dividido em camadas:

**Front-End**
    
    src/

    ├── Api (opcional para o futuro)

    ├── pages
        -   DataAddress
        -   DataBasic
        -   DataFinancial
        -   DataSecurity
        -   Validacao



**Back-End:**

    src/

    ├── Api

    ├── Application

    ├── Domain

    ├── Infrastructure

 
**Overview da estrutura:**

        ├── Api
        │ ├── Controllers
        │ └── Program.cs
        │
        ├── Application
        │ ├── DataAddress
        │ ├── DataBasic
        │ ├── DataFinancial
        │ ├── DataSecurity
        │ ├── DTOs
        │ └── Interfaces
        │
        ├── Domain
        │ ├── Entities
        │ │ ├── DataAddress.cs
        │ │ ├── DataBasic.cs
        │ │ ├── DataFinancial.cs
        │ │ └── DataSecurity.cs
        │ └── Notify
        │ └── Notification.cs
        │
        └── Infrastructure
        ├── Messaging
        │ ├── Consumer
        │ └── EmailService
        ├── Repository
        ├── Security
        ├── Settings
        └── ViaCep

## Tecnologias utilizadas
- .NET 10 (ASP.NET Core Web API)
- Clean Architecture + DDD
- JWT Authentication
- MongoDB (Atlas)
- RabbitMQ (mensageria)
- SendGrid (e-mail)
- Swagger (OpenAPI)
- Docker
- Front-end puro (HTML/CSS/JS)
  
## Pré-requisitos

Antes de iniciar, certifique-se de que seu ambiente atende aos seguintes requisitos:

- **.NET SDK 10 ou superior**
- **Docker e Docker Compose**
- **RabbitMQ (via Docker)**



## Verificando instalação do .NET

```bash
dotnet --version 
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 10.0.8
dotnet add package Microsoft.AspNetCore.OpenApi --version 10.0.8
dotnet add package Microsoft.EntityFrameworkCore --version 10.0.8
dotnet add package MongoDB.Driver --version 3.9.0
dotnet add package RabbitMQ.Client --version 6.8.1
dotnet add package SendGrid --version 9.29.3
dotnet add package Swashbuckle.AspNetCore --version 10.2.1
```

## Infraestrutura (Docker)
```bash
 docker-compose up -d
 ```
## Banco de Dados (MongoDB Atlas)
``` bash
"MongoDbSettings": {
"ConnectionString": "sua_string_do_mongo_atlas",
"DatabaseName": "PathBank"
}
```
## Executando o projeto

 ``` bash 
 dotnet run
 ```
## Frontend
Execute o frontend usando Live Server (VS Code).

## Observações
-   Configure o IP whitelist no MongoDB Atlas
-   Verifique as portas do RabbitMQ no Docker
-   Configure o SendGrid corretamente
-   Certifique-se de que o backend está rodando antes do frontend
  

# Um pouco sobre o desenvilvimento desse projeto:

   A ideia deste projeto era criar uma aplicação com uma linguagem simples e bem estruturada, facilitando a comunicação e a manutenção ao longo do desenvolvimento.

Com isso, pensei: *“e se eu criasse pequenas partes reutilizáveis que funcionassem como atalhos no futuro, facilitando determinadas funções?”*

A partir desse conceito, baseei boa parte do desenvolvimento na criação de componentes e abstrações que pudessem simplificar o fluxo da aplicação ao longo do tempo.

Um exemplo disso foi a criação da camada **Notify**, utilizada para centralizar validações básicas e notificações, permitindo um código mais limpo e organizado.

Outra ideia importante foi a implementação de padrões como **Repository** e **RequestFull**, com o objetivo de concentrar informações em pontos específicos da aplicação, ao invés de espalhar lógica detalhada em várias partes do código.

Essa abordagem não elimina a importância dos detalhes — pelo contrário, acredito que a qualidade da aplicação está justamente neles — porém, ao delegar responsabilidades mais genéricas para essas camadas, consegui manter o código mais limpo, organizado e sustentável durante o desenvolvimento.

Durante o processo, enfrentei diversos desafios e aprendi bastante com cada problema encontrado. Embora eu pudesse simplesmente replicar a estrutura do projeto anterior e reutilizar a mensageria, optei por reconstruir tudo do zero neste projeto, aproveitando uma visão mais fresca, o que contribuiu muito para o meu aprendizado.

O frontend foi desenvolvido a partir de um escopo criado previamente no Figma. A proposta era manter uma interface simples, porém com uma identidade visual inspirada em fintechs.

Acredito que o resultado poderia ter sido melhor caso tivesse dedicado mais atenção aos detalhes visuais e refinado alguns aspectos de usabilidade. Também faltaram algumas validações nos inputs para melhorar a experiência do usuário final.

Apesar disso, o frontend está funcional e cumpre seu objetivo principal, que é capturar e enviar corretamente os dados preenchidos pelo usuário.

## Autenticação e Segurança (JWT e Hash)

A estrutura de autenticação foi pensada para ser compatível com o uso de **JWT**, já prevendo uma possível evolução do sistema para cenários mais complexos no futuro, considerando que a aplicação lida com dados sensíveis.

Em relação ao armazenamento de senhas, foi utilizado **hash com salt**, com o objetivo de aumentar a segurança e dificultar ataques como brute force e rainbow tables, comuns em sistemas expostos.

A escolha dessa abordagem visa seguir boas práticas de mercado, garantindo que as credenciais dos usuários não sejam armazenadas de forma direta ou previsível.

Durante o desenvolvimento, foi considerado que a combinação de diferentes estratégias de autenticação e segurança deve ser feita de forma estruturada, pois a mistura incorreta desses conceitos pode dificultar o processo de serialização e validação dos dados criptográficos.

## Processo de comunicação (Rascunhos)
![racunho](./src/img/1.png)
![racunho](./src/img/2.png)
![racunho](./src/img/3.png)

## GitHub

Diferente do primeiro projeto, desta vez procurei seguir um fluxo mais organizado e consistente para o desenvolvimento e controle de commits.

Criei uma branch chamada **Developer**, responsável por centralizar todo o desenvolvimento do projeto. A partir dela, foram criadas as features de forma individual e bem definidas.

Acredito que essa abordagem ajuda a evitar a poluição do histórico de commits, além de manter o projeto mais estruturado, limpo e organizado a longo prazo.

## Conclusão

Ao concluir o projeto, percebo o vasto mar de informações que ainda tenho pela frente e o quanto ainda preciso evoluir tecnicamente.

Foi uma experiência muito interessante ao longo do desenvolvimento. Aprendi a estruturar ciclos de forma mais lógica e a entender como uma aplicação bem construída — desde as nomenclaturas até funções simples — pode facilitar muito o desenvolvimento.

Mesmo tendo concluído esses pequenos desafios, pretendo continuar me desafiando e enfrentando novos problemas e projetos. É um processo contínuo de aprendizado..

