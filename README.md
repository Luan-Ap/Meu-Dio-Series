# Meu Dio Séries.

##### Desta vez eu trago uma versão alternativa da solução Criando um APP simples de cadastro de séries em .NET, [presente neste repositório.](https://github.com/Luan-Ap/Criando-um-APP-simples-de-cadastro-de-s-ries-em-.NET)

Além do aplicativo console desenvolvido na solução original, adicionei uma aplicação ASP.NET Core MVC para praticar o desenvolvimento Web e criei as classes SerieViewModel e GeneroViewModel para validar a entrada de alguns dados na página
No entanto, não foquei muito no front-end da solução, dedicando mais esforço para a parte back-end.
Utilizei a metodologia Code First através do EntityFramework e de Migrations para adicionar uma persistência de dados à aplicação.
Apliquei injeção de dependência para diminuir o nível de acoplamento entre as camadas e a utilização do AutoMapper para fazer o mapeamento entre os objetos Serie e SerieViewModel, Genero e GeneroViewModel.

Dividi a solução em 5 camadas(projetos):

- Projeto MeuDioSeries.AppConsole que se trata da camada de Apresentação em modo console com o qual o usuário interage, contendo o menu de opções e os métodos para acessar o restante das camadas;
- Projeto MeuDioSeries.Dominio que se trata da camada de Domain, onde são definidas as entidades, regras de negócio, interfaces(contratos) estabelecidos;
- Projeto MeuDioSeries.Infra que se trata da camada de acesso aos dados, onde são definidas o DbContext com a string de conexão para o EntityFramework, a lógica para manipular os dados, as classes de Migrations e a implementação das interfaces IRepositorioBase, ISerieRepositorio e IGeneroRepositorio da camada de Dominio.
- Projeto MeuDioSeries.AppWeb que se trata da camada de Apresentação feita em ASP.NET Core MVC, onde também é configurado a injeção de depedência para a utilização das interfaces e do AutoMapper.
- Projeto MeuDioSeries.Service que se trata da camada de Serviço que media a comunicação das camadas de Apresentação com MeuDioSeries.Infra, implemetando a interface IServiceBase, ISerieService e IGeneroService da camada de Dominio e a utilização do AutoMapper.

Além disso, também adicionei um processo de Autenticação e Autorização com cookies na aplicação MVC, criando dois tipos de usuário: Admin e Visitante.
O usário Visitante tem acesso apenas as funcionalidades de consulta. Já o usuário Admin tem acesso a todas as funcionalidades até então desenvolvidas.

Para acessar como Visititante as credenciais são as seguintes:
- Usuário: luan.visitante@email.com;
- Senha: visitanteLuan123.

Para acessar como Admin, as credenciais são as seguintes:
- Usuário: luan.admin@email.com
- Senha: adminLuan123 

Links úteis:

- [**Eliézer Zarpelão** (Instrutor do projeto original)](https://github.com/elizarp);
- [**Digital Innovation One**](https://www.dio.me/)