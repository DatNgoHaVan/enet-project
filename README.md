# enson-project
An social network project for training.


## Build Status
| Build server    | Platform       | Status      |
|-----------------|----------------|-------------|
|Travis           | Linux / MacOS  |[![Build Status](https://travis-ci.com/DatNgoHaVan/enson-project.svg?branch=dev)](https://travis-ci.com/DatNgoHaVan/enson-project) |

##THESE GUIDE FOR RUNNING BACK-END

## Visual Studio 2017 and SQL Server

#### Prerequisites

- SQL Server
- [Visual Studio 2017 version >= 15.8 with .NET Core SDK 2.2.101](https://www.microsoft.com/net/download/all)

#### Steps to run

- Be sure you are in "enson-be" folder.
- Update the connection string in appsettings.json.
- Build whole solution.
- In Solution Explorer, make sure that "enson-be" is selected as the Startup Project
- Open Package Manager Console Window and make sure that "enson-be" is selected as Default project. Then type "Update-Database" then press "Enter". This action will create database schema.
- In Visual Studio, press "Control + F5".

## Mac/Linux with PostgreSQL

#### Prerequisite

- PostgreSQL
- [.NET Core SDK 2.2.101](https://www.microsoft.com/net/download/all)

#### Steps to run
- Be sure you are in enson-be folder.
- Update the connection string in appsettings.json
- Run file linux-build.sh by "sudo ./linux-build.sh". For ubuntu 18 "sudo bash linux-build.sh"
- In the terminal, type "dotnet run" or "dotnet watch run" and hit "Enter".
- Call register API: http://localhost:5000/api/register/