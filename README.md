# ONG Adota Pet
Este projeto está sendo desenvolvido como estudo para a prática de desenvolvimento de software, aplicação de design patterns e aplicação de boas práticas de programação, além de ser utilizado para um projeto de graduação.

## Objetivo da aplicação
Está aplicação tem como objetivo ser o backend de uma aplicação WEB (que ainda será desenvolvida), onde uma ONG disponibilizará e efetuara o gerenciamento de de solicitações de adoções de animais bem como clientes poderão se cadastrarem e efetuarem solicitações para a adoção de algum pet disponivel.

## Caracteristicas gerais
### Módulos
Este projeto inicialmente contará com os modulos:
 - Persons: Onde os usuários poderão se cadastrar, atualizar suas informações, ativar ou desativar suas contas; (EM DESENVOLVIMENTO)
 - Pets: Onde somente os Colaboradores da Ong poderão cadastrar animais para adoção e usuários poderão verificar quais animais estão disponiveis para adoção; (A DESENVOLVER)
 - Adoptions: Onde os colaboradores da ONG poderão verificar todas as requisições de adoções e os usuários poderão verificar suas solicitações, efetuar cancelamentos (A DESENVOLVER)
 - Login: Parte do projeto responsável para geração de tokens de acesso com o esquema JWT (EM DESENVOLVIMENTO).

Contará com os perfis (EM DESENVOLVIMENTO):
 - users: Público em geral
 - admin: Gerenciadores com acesso total ao sistema (exceto a informações sensiveis)
 - collaborators: Colaboradores da ONG.

Este projeto já conta com uma classe que faz a conversão das senhas dos usuários para uma Hash, antes de salvar no banco de dados, para que esta, por ser uma informação sensivel não ficar exposta na forma pura e pessoas não autorizadas terem acesso. Futuramente, novos dados serão salvos da mesma maneira (ex.: CPF). A expectativa é que o projeto fique de acordo com a LGPD.

### Tecnologias utilizadas
#### Backend
 - Entity Framework
 - C# - .Net8
 - Containers

 #### Backend - Design Patterns
 - CQRS
 - Unity of work

#### Frontend
 - A Definir


## OBSERVAÇÕES
Projeto ainda em desenvolvimento e passará por refatoração para aplicação das boas práticas de programação e identificação de melhorias
