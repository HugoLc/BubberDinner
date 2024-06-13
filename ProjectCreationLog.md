/Dev/Curso-Dotnet
$ dotnet new sln -o BubberDinner
O modelo "Arquivo de Solução" foi criado com êxito.

/Dev/Curso-Dotnet
$ cd BubberDinner/

/Dev/Curso-Dotnet/BubberDinner
$ dotnet new webapi -o BubberDinner.Api
O modelo "API Web do ASP.NET Core" foi criado com êxito.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet new classlib -o BubberDinner.Contracts
O modelo "Biblioteca de Classes" foi criado com êxito.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet new classlib -o BubberDinner.Infrastructure
O modelo "Biblioteca de Classes" foi criado com êxito.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet new classlib -o BubberDinner.Application
O modelo "Biblioteca de Classes" foi criado com êxito.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet new classlib -o BubberDinner.Domain
O modelo "Biblioteca de Classes" foi criado com êxito.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet build
Compilação com êxito.
C:\Program Files\dotnet\sdk\8.0.204\NuGet.targets(169,5): warning : Não é possível encontrar um projeto para restaurar! [E:\Dev\Curso-Dotnet\BubberDinner\BubberDinner.sln]
    1 Aviso(s)
    0 Erro(s)

/Dev/Curso-Dotnet/BubberDinner
$ dotnet sln add **/*.csproj
O projeto ‘BubberDinner.Api\BubberDinner.Api.csproj’ foi adicionado à solução.
O projeto ‘BubberDinner.Application\BubberDinner.Application.csproj’ foi adicionado à solução.
O projeto ‘BubberDinner.Contracts\BubberDinner.Contracts.csproj’ foi adicionado à solução.
O projeto ‘BubberDinner.Domain\BubberDinner.Domain.csproj’ foi adicionado à solução.
O projeto ‘BubberDinner.Infrastructure\BubberDinner.Infrastructure.csproj’ foi adicionado à solução.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet build
Compilação com êxito.
    0 Aviso(s)
    0 Erro(s)

/Dev/Curso-Dotnet/BubberDinner
$ dotnet add ./BubberDinner.Api reference ./BubberDinner.Contracts/ ./BubberDinner.Application/
A referência ‘..\BubberDinner.Contracts\BubberDinner.Contracts.csproj’ foi adicionada ao projeto.
A referência ‘..\BubberDinner.Application\BubberDinner.Application.csproj’ foi adicionada ao projeto.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet add ./BubberDinner.Infrastructure/ reference ./BubberDinner.Application/
A referência ‘..\BubberDinner.Application\BubberDinner.Application.csproj’ foi adicionada ao projeto.

/Dev/Curso-Dotnet/BubberDinner
$ dotnet add ./BubberDinner.Application/ reference ./BubberDinner.Domain/       A referência ‘..\BubberDinner.Domain\BubberDinner.Domain.csproj’ foi adicionada ao projeto.