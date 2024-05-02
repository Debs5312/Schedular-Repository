# Schedular-Repository

This is a schedular repository service. Main objective is to design and maintain jobs to delivery and creation of metadata.

# Create a solution file

add a new solution file --> dotnet new sln

# make directory and create a new webapi project

mkdir ProcessAPI
cd ProcessAPI/
dotnet new webapi

mkdir HistoryAPI
cd HistoryAPI/
dotnet new webapi

mkdir UserAPI
cd UserAPI/
dotnet new webapi

mkdir Migrations
cd Migrations/
dotnet new classlib

mkdir Models
cd Models/
dotnet new classlib

mkdir SchedularUI

# Add API and Class Libraries to Schedular-Repository solution

dotnet sln add UserAPI/UserAPI.csproj

dotnet sln add HistoryAPI/HistoryAPI.csproj

dotnet sln add ProcessAPI/ProcessAPI.csproj

dotnet sln add Models/Models.csproj

dotnet sln add Migrations/Migrations.csproj

# Add classlib reference to individual project

cd UserAPI/

dotnet add reference ../Models/Models.csproj

dotnet add reference ../Migrations/Migrations.csproj

cd ..

cd ProjectAPI/

dotnet add reference ../Migrations/Migrations.csproj

dotnet add reference ../Models/Models.csproj

cd ..

cd HistoryAPI/

dotnet add reference ../Migrations/Migrations.csproj

dotnet add reference ../Models/Models.csproj

# Restoring Projects

dotnet restore
