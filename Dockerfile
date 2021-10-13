FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env


RUN mkdir -p /opt/app-root/src && mkdir -p /opt/app-root/app

WORKDIR /opt/app-root/src

COPY ./chatty/*.csproj ./chatty/

RUN dotnet restore ./chatty/chatty.csproj

COPY . ./

RUN dotnet publish ./chatty/chatty.csproj -c Release -o /opt/app-root/app

#Runtime image

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY --from=build-env /opt/app-root/app .
ENTRYPOINT ["dotnet", "chatty.dll"]