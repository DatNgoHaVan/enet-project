#!/bin/bash
set -e

sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.1" />|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.2.0" />|' enson-be.csproj
sed -i'' -e 's/UseSqlServer/UseNpgsql/' Startup.cs

rm -rf Migrations/*

dotnet restore && dotnet build


dotnet ef migrations add initialSchema \
&& dotnet ef database update
	
echo "The database schema has been created."
echo "Then type 'dotnet run' to start the app."