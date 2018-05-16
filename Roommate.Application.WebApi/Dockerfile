FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY *.sln ./
COPY Roommate.Application.WebApi/Roommate.Application.WebApi.csproj Roommate.Application.WebApi/
COPY Roommate.Application/Roommate.Application.csproj Roommate.Application/
COPY Roommate.Application.Shared/Roommate.Application.Shared.csproj Roommate.Application.Shared/
COPY Roommate.Business/Roommate.Business.csproj Roommate.Business/
COPY Roommate.Repository/Roommate.Repository.csproj Roommate.Repository/
COPY Roommate.Repository.Exchange/Roommate.Repository.Exchange.csproj Roommate.Repository.Exchange/
RUN dotnet restore
COPY . .
WORKDIR /src/Roommate.Application.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Roommate.Application.WebApi.dll"]
