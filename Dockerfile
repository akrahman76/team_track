# 1. Use the official SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /TeamTrack

# Create the folder structure inside Docker and copy the project file
COPY TeamTrack/*.csproj ./TeamTrack/
RUN dotnet restore TeamTrack/*.csproj

# Copy the remaining source code and publish
COPY . ./
RUN dotnet publish TeamTrack/*.csproj -c Release -o /TeamTrack/publish

# 2. Build the runtime image (keeps the final image size small for ECR)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /TeamTrack
COPY --from=build-env /TeamTrack/publish .
ENTRYPOINT ["dotnet", "TeamTrack.dll"]