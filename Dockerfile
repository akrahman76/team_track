# 1. Use the official SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /src

# Copy only the project files first for a clean restore cache
COPY TeamTrack/*.csproj ./TeamTrack/
COPY TeamTrack.Application/*.csproj ./TeamTrack.Application/
COPY TeamTrack.Domain/*.csproj ./TeamTrack.Domain/
COPY TeamTrack.Infrastructure/*.csproj ./TeamTrack.Infrastructure/

RUN dotnet restore TeamTrack/TeamTrack.csproj

# Copy the remaining source code and publish
COPY . ./
RUN dotnet publish TeamTrack/TeamTrack.csproj -c Release -o /app/publish

# 2. Build the runtime image (keeps the final image size small for ECR)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "TeamTrack.dll"]