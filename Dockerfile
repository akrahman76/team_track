# 1. Use the official SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /TeamTrack

# Copy everything and restore/publish
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o publish

# 2. Build the runtime image (keeps the final image size small for ECR)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /TeamTrack
COPY --from=build-env /TeamTrack/publish .
ENTRYPOINT ["dotnet", "TeamTrack.dll"]