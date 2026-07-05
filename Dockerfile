# 1. Use the official SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /src

# Copy the project file into the container's TeamTrack folder
COPY TeamTrack/*.csproj ./TeamTrack/
RUN dotnet restore TeamTrack/

# Copy the remaining source code and publish
# Copy the remaining source code and publish
COPY . ./
RUN dotnet publish TeamTrack/*.csproj -c Release -o /app/publish

# 2. Build the runtime image (keeps the final image size small for ECR)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "TeamTrack.dll"]