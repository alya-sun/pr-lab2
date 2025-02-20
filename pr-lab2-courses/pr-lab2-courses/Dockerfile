FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y curl
USER $APP_UID
WORKDIR /app
EXPOSE 7128

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["pr-lab2-courses/pr-lab2-courses.csproj", "pr-lab2-courses/"]
RUN dotnet restore "pr-lab2-courses/pr-lab2-courses.csproj"
COPY . .
WORKDIR "/src/pr-lab2-courses"
RUN dotnet build "pr-lab2-courses.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "pr-lab2-courses.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pr-lab2-courses.dll"]
