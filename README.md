# Teste Frog Pay
## Segue teste realizado conforme o enunciado

##  _Detalhes_
### Projeto fo construido utlizando 
- Dotnet Core
- Entity Framework
- Postgres
- Elastichsearch
- Kibana
- Docker
<img width="1350" alt="image" src="https://github.com/EmersonGaldino/frogpay/assets/29602710/dcb37adf-088b-4c57-8bd9-beaa5cca8874">

  

# Estrutura do projeto
<img width="303" alt="image" src="https://github.com/EmersonGaldino/frogpay/assets/29602710/0e3890bf-0e88-49c7-b382-8af6074ead56">

## Projeto está separado em camadas, sendo elas:
- API - onde contem todos os IO/s da aplicação
- AppService - Centralizador de ações voltadas a infra do projeto exemplo enviar email.
- Domain - Onde é aplicada toda regra de negócio
- Bootstrapper - Centraliza toda a configuração da aplicação
- Repository - Camada responssavel por realziar a comunicação com o banco de dados

  
*Obs: Dentro da aplicação na camanda principal te um arquivo docker-compose que executa todo o projeto, para rodar execute o comando:
``docker-compose up -d ``

# Quando subir as aplicações você terá três endpoints disponiveis
## [API](http://localhost:9090/swagger/index.html) Aqui abre o swagger da aplicação com a documentação de cada endpoint
<img width="1674" alt="image" src="https://github.com/EmersonGaldino/frogpay/assets/29602710/2365ea99-52bd-47a9-8cb7-9f1b96ef412c">


## [Kibana](http://localhost:5601/app/discover) Aqui abre o observability da aplicação 
<img width="1697" alt="image" src="https://github.com/EmersonGaldino/frogpay/assets/29602710/c2d26ee5-3380-4fb4-a587-5f306abbddf6">

## [DOC](https://www.elastic.co/guide/en/kibana/master/observability.html) Obs: Aqui para conseguir ver os logs é necessário setar o index Pattern do kibana 

# Collection
## Segue dentro da estrutura de pasta um arquivo contendo todos os endpoint pra teste via insonminia
- Pasta Solution items

  <img width="1195" alt="image" src="https://github.com/EmersonGaldino/frogpay/assets/29602710/fe64b416-cb35-450a-ab8e-0a6a181039c7">

