#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#ENV http_proxy http://emea.zscaler.philips.com:9480
#ENV https_proxy http://emea.zscaler.philips.com:9480
COPY NuGet.Config ./
COPY ["TravelDiary.Blog.Command.Api/TravelDiary.Blog.Command.Api.csproj", "TravelDiary.Blog.Command.Api/"]
COPY ["TravelDiary.Blog.Command.Business/TravelDiary.Blog.Command.Business.csproj", "TravelDiary.Blog.Command.Business/"]
COPY ["TravelDiary.Blog.Command.Business.Interface/TravelDiary.Blog.Command.Business.Interface.csproj", "TravelDiary.Blog.Command.Business.Interface/"]
COPY ["TravelDiary.Blog.Command.Core/TravelDiary.Blog.Command.Core.csproj", "TravelDiary.Blog.Command.Core/"]
COPY ["TravelDiary.Blog.Command.Data/TravelDiary.Blog.Command.Data.csproj", "TravelDiary.Blog.Command.Data/"]

RUN dotnet restore "TravelDiary.Blog.Command.Api/TravelDiary.Blog.Command.Api.csproj" --interactive
COPY . .
WORKDIR "/src/TravelDiary.Blog.Command.Api"
RUN dotnet build "TravelDiary.Blog.Command.Api.csproj" -c Release -o /app/build

FROM build AS publish
#RUN dotnet publish "TravelDiary.Blog.Command.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#RUN rm ./NuGet.Config
ENTRYPOINT ["dotnet", "TravelDiary.Blog.Command.Api.dll"]