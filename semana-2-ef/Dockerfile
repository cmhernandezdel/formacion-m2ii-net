FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Example.EntityFramework/Example.EntityFramework.csproj", "Example.EntityFramework/"]
RUN dotnet restore "Example.EntityFramework/Example.EntityFramework.csproj"
COPY . .
WORKDIR "/src/Example.EntityFramework"
RUN dotnet build "Example.EntityFramework.csproj" -c Release -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "Example.EntityFramework.csproj" -c Release -o /app/publish

# Stage 4: Run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.EntityFramework.dll"]