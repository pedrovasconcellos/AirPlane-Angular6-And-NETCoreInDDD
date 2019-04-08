# AirPlane-Angular6-And-NETCoreInDDD
AirPlaneExample ( Front: Angular 6 ; BackEnd: ASP.NET Core 2.1 in DDD)


###Antes de fazer o projeto em DDD fiz uma API estática para desenvolver e testar o projeto criado em angular 6. 

#https://airplanedemo.azurewebsites.net 

###Armazenei ela na url acima. {obs: Não possui banco de dados, é uma versão diferente da WebAPI presente no repositório, devido os seus dados serem armazenados em uma váriavel estática};

###No repositório serão encontrados dois projetos distintos, [front em Angular 6 consumindo a API do Azure] e a [API com EntityFramework Core, DDD, RESTful, Injeção de dependência, feita em ASP.NET CORE (bônus: migration e massa de dados auto criada, basta colocar a sua connection string e executar o projeto que os dados e as tabelas serão criados automaticamente].

###Usei para gerar a documentação da WebAPI o Framework de configuração do Swagger que eu mesmo criei.

https://www.nuget.org/packages/Swashbuckle.SwaggerConfigurationExtension/1.0.6

https://github.com/pedrovasconcellos/SwaggerConfigurationExtension-ASP.NET-Core


###Para executar o projeto em angular6, entre no diretório e digite [ng serve --open] no console;
