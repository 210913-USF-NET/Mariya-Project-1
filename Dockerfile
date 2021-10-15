#base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 as Build

#Work directory
WORKDIR /app

COPY *.sln ./
COPY StoreBL/*.csproj ./StoreBL/
COPY DL/*.csproj ./DL/
COPY Models/*.csproj ./Models/
COPY WebUI/*.csproj ./WebUI/
COPY Test/*.csproj ./Test/

#navigating to webui and restore dependancies 
RUN cd WebUI && dotnet restore


COPY . ./

RUN dotnet publish WebUI -c Release -o publish --no-restore

#pair down build and hide source code
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as run

WORKDIR /app

COPY --from=build /app/publish ./

CMD [ "dotnet", "WebUI.dll" ]