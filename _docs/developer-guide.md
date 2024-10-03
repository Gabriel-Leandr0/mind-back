# Guia de Desenvolvimento

O objetivo deste guia, é direcionar o desenvolvimento utilizando os padrões arquiteturais. Afim de manter a padronização entre os projetos e facilitar as tomadas de decisões durante do desenvolvimento.

## Padrão Arquitetural

Essa API, utiliza o padrão arquitetural chamado Clean Architecture. A principal ideia por trás do Clean Architecture é a separação de responsabilidades, onde a lógica de negócio é separada das preocupações técnicas e dos detalhes de implementação.

## Camadas


### 1. WebApi
**Responsabilidade:** Esta camada é responsável por expor os endpoints da API para os consumidores externos. Atua como a interface entre o sistema e os clientes (navegadores, aplicações móveis, outros serviços).

**Componentes:**
- **Controllers/Endpoints:** Pontos de entrada da aplicação que recebem as requisições HTTP, as validam e as direcionam para os casos de uso apropriados na camada de aplicação.
- **DTOs (Data Transfer Objects):** Objetos usados para transferir dados entre a API e o cliente.

### 2. Application
**Responsabilidade:** Coordena o fluxo de dados entre a WebApi e a camada de domínio. Contém a lógica de aplicação, incluindo casos de uso específicos que descrevem como a aplicação deve comportar-se.

**Componentes:**
- **Use Cases/Services:** Representam as operações específicas da aplicação, encapsulando a lógica de aplicação e orquestrando a interação entre as entidades e os repositórios.
- **DTOs:** Usados para transferir dados entre a camada de aplicação e a camada de infraestrutura.

### 3. Domain
**Responsabilidade:** Contém a lógica de negócio e as regras do domínio. Esta camada é independente de frameworks e bibliotecas externas.

**Componentes:**
- **Entidades:** Representam os objetos do domínio com suas propriedades e comportamentos.
- **Value Objects:** Objetos que representam valores e comportamentos imutáveis no domínio.
- **Agregados:** Grupos de entidades que são tratadas como uma única unidade.
- **Serviços de Domínio:** Implementam regras de negócio que não cabem em uma única entidade.
- **Interfaces de Repositório:** Definem contratos para as operações de persistência de dados, sendo implementadas na camada de infraestrutura.

### 4. Infrastructure
**Responsabilidade:** Implementa os detalhes técnicos, como persistência de dados, comunicação com APIs externas e outros serviços de infraestrutura. É a camada mais externa e depende diretamente das tecnologias específicas usadas no sistema.

**Componentes:**
- **Repositórios (Implementações):** Implementam as interfaces de repositório definidas na camada de domínio. Lidam com operações de banco de dados.
- **Adaptadores:** Conectores para tecnologias específicas, como APIs externas, filas de mensagens, etc.
- **Serviços de Infraestrutura:** Serviços que fornecem funcionalidades técnicas, como envio de e-mails, logging, etc.
- **Data Context:** Contexto de dados para acessar o banco de dados, por exemplo, DbContext no Entity Framework.

## Fluxo de Dados entre as Camadas

1. **Requisição:** O cliente faz uma requisição para a **WebApi**.
2. **Validação e Encaminhamento:** A WebApi valida a requisição e encaminha para um caso de uso na **camada de aplicação**.
3. **Lógica de Aplicação:** O caso de uso na camada de aplicação processa a lógica, interagindo com a **camada de domínio** para aplicar regras de negócio e com os **repositórios implementados na camada de infraestrutura** para persistência e comunicação externa.
4. **Resposta:** A camada de aplicação prepara a resposta e a envia de volta para a WebApi, que a retorna para o cliente.

