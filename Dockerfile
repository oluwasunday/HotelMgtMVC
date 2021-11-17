#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HotelMgtMVC/HotelMgtMVC.csproj", "HotelMgtMVC/"]
COPY ["HotelMgtModel/HotelMgtModel.csproj", "HotelMgtModel/"]
COPY ["HotelMgtServices/HotelMgtServices.csproj", "HotelMgtServices/"]
RUN dotnet restore "HotelMgtMVC/HotelMgtMVC.csproj"
COPY . .
WORKDIR "/src/HotelMgtMVC"
RUN dotnet build "HotelMgtMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelMgtMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "HotelMgtMVC.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HotelMgtMVC.dll