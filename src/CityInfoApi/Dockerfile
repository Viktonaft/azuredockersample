FROM microsoft/aspnetcore:2.0.0

ARG source=publish
COPY $source /app

WORKDIR /app

ENV SQLCONNSTR_DBConnection="Server=tcp:dmn-sql01.database.windows.net;Database=CityInfo_Dev;User Id=adminUser;Password=P@ssw0rd!."
ENV ASPNETCORE_URLS http://*:5000
#ENV LTTNG_UST_REGISTER_TIMEOUT 0

EXPOSE 5000
RUN mkdir logs
VOLUME /logs:/logs


ENTRYPOINT ["dotnet", "CityInfo.Api.dll"]