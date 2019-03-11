FROM microsoft/aspnetcore-build
 
WORKDIR /home/app
 
COPY . .
 
RUN dotnet restore
 
RUN dotnet publish ./AccountOwnerServer/AccountOwnerServer.csproj -o /publish/
 
WORKDIR /publish
 
ENTRYPOINT ["dotnet", "AccountOwnerServer.dll"]
