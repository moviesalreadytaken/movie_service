FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY . ./
EXPOSE 10002
ENTRYPOINT [ "dotnet", "run"]
# RUN dotnet restore
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build /app/out .

# ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]

