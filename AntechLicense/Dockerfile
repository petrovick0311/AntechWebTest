#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0
FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY /bin/Release/net5.0/publish/ AntechLicense/

ENV ASPNETCORE_ENVIRONMENT Production

EXPOSE 5000
WORKDIR /AntechLicense
ENTRYPOINT ["dotnet", "AntechLicense.dll", "--urls=http://0.0.0.0:5000"]





