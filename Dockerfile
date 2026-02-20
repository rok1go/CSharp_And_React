FROM mcr.microsoft.com/dotnet/sdk:9.0-preview

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build

CMD ["dotnet", "run"]   