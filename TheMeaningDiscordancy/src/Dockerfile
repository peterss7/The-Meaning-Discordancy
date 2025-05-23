FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR .

# Copy
COPY TheMeaningDiscordancy.Api/TheMeaningDiscordancy.Api.csproj ./TheMeaningDiscordancy.Api/TheMeaningDiscordancy.Api.csproj
COPY TheMeaningDiscordancy.Core/TheMeaningDiscordancy.Core.csproj ./TheMeaningDiscordancy.Core/TheMeaningDiscordancy.Core.csproj
COPY TheMeaningDiscordancy.Infrastructure/TheMeaningDiscordancy.Infrastructure.csproj ./TheMeaningDiscordancy.Infrastructure/TheMeaningDiscordancy.Infrastructure.csproj

# Restore
RUN dotnet restore ./TheMeaningDiscordancy.Api/TheMeaningDiscordancy.Api.csproj
RUN dotnet publish ./TheMeaningDiscordancy.Api/TheMeaningDiscordancy.Api.csproj -c Release -o /app/publish



# # Runtime
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "TheMeaningDiscordancy.Api.dll"]