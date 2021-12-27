# Meu Dio Séries.

##### Desta vez eu trago uma versão alternativa da solução Criando um APP simples de cadastro de séries em .NET, [presente neste repositório.](https://github.com/Luan-Ap/Criando-um-APP-simples-de-cadastro-de-s-ries-em-.NET)

Utilizei a metodologia Code First através do EntityFramework e de Migrations para adicionar uma persistência de dados à aplicação.

Dividi a solução em três camadas(projetos):

- Projeto AppConsole que se trata da camada de Apresentação com o qual o usuário interage, contendo o menu de opções e os métodos para acessar o restante das camadas;
- Projeto Dominio que se trata da camada de Domain, onde são definidas as entidades, regras de negócio, enum e interfaces(contratos) estabelecidos;
- Projeto Infra que se trata da camada de acesso aos dados, onde são definidas o DbContext com a string de conexão para o EntityFramework, a lógica para manipular os dados, as classes de Migrations e a implementação das interfaces da camada de Domain.

Links úteis:

- [**Eliézer Zarpelão** (Instrutor do projeto original)](https://github.com/elizarp);
- [**Digital Innovation One**](https://www.dio.me/)