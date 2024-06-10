
# ApiTestePraticoDesenvolvedor

## Solution:

 __1 - API__:  
Contém a Aplicação com os Controllers.

 __2 - Application__:  
Contém os Serviços.

__3 - Infrastructure__:  
Contém Migration, Repositorios e o DatabaseContext.

__4 - Domain__:  
Contém Entities e DTOs.

__5 - Tests__:  
Contém os Projetos referente aos Teste de Unidade.

 ![image info](./docs/img/solution.png)

## Postman Collections:
Collection do Postman para auxiliar os testes:

[Ir para a Collection](./docs/Davi_ApiTestePraticoDesenvolvedor.postman_collection.json)

_A API retornar os Erros com Código 422_


## Azure:
__Swagger:__  
https://apitestepraticodesenvolvedor.azurewebsites.net/swagger/index.html

A Aplicação está em um [__Web App__](https://azure.microsoft.com/pt-br/products/app-service/web) conectada ao um [__SQL database__](https://azure.microsoft.com/pt-br/products/azure-sql/database).

 ![image info](./docs/img/azure.png)

## GitHub Actions:

## main_apitestepraticodesenvolvedor.yml:
Quando o código é recebido na branch __main__.  
É feito as seguintes ações:
- Checkout
- SonarCloud
- Build
- Deploy Azure

 __Print:__  

 ![image info](./docs/img/main_apitestepraticodesenvolvedor.png)

## main_develop_pull_request.yml:
Quando o código é recebido na branch __develop__ ou quando é feito PR para branchs __main__ e __develop__.
É feito as seguintes ações:
 - Checkout
 - SonarCloud

 __Print:__  
 ![image info](./docs/img/main_develop_pull_request.png)

 ## SonarCloud:

__SonarCloud__  
 https://sonarcloud.io/summary/new_code?id=davihenrique97_ApiTestePraticoDesenvolvedor

 ![image info](./docs/img/sonarcloud.png)

Utilizado o SonarCloud para verificar a qualidade e a cobertura dos testes de Unidade.


## Pacotes Nugets Utilizados:

### AutoMapper
![image info](./docs/img/pacotes/automapper.png)

Pacote Nuget utilizado para fazer mapeamento de objetos.  
Utilizado para deixar o código mais limpo e facilitar o mapeamento de objetos.

## FluentValidation

![image info](./docs/img/pacotes/fluentvalidation.png)

Pacote Nuget utilizado para fazer validações de objetos.  
Utilizado para validar o corpo das requisições.  

## Entity Framework Core
![image info](./docs/img/pacotes/ef-core.png)

Biblioteca de mapeamento objeto-relacional (ORM).  
Utilizado para fazer a abordagem "Code First".

## Scrutor
![image info](./docs/img/pacotes/scrutor.png)  
Pacote Nuget utilizado para realizar a injeção de dependência.  


## coverlet.collector
![image info](./docs/img/pacotes/coverlet.collector.png)  
Pacote Nuget utilizado  para medir cobertura de testes.


## FluentAssertions
![image info](./docs/img/pacotes/fluentassertions.png)  
Pacote Nuget com conjunto de métodos que permitem especificar de forma mais natural o resultado esperado de testes de unidade.

## xunit
![image info](./docs/img/pacotes/xunit.png)  
Pacote Nuget para Testes de Unidade.