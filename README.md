# enson-project
An social network project for training.


## Build Status
| Build server    | Platform       | Status      |
|-----------------|----------------|-------------|
|Travis           | Linux / MacOS  |[![Build Status](https://travis-ci.com/DatNgoHaVan/enson-project.svg?token=44Dp4xgu5dU6gYhiYCoY&branch=dev)](https://travis-ci.com/DatNgoHaVan/enson-project)|
|Circle           | Linux / MacOS  |[![CircleCI](https://circleci.com/gh/DatNgoHaVan/enson-project.svg?style=svg)](https://circleci.com/gh/DatNgoHaVan/enson-project)|


## Visual Studio 2017 and Postgresql

#### Prerequisites

- [Postgresql](https://www.postgresql.org/download/windows/)
- [pgAdmin4](https://www.pgadmin.org/download/pgadmin-4-windows/)
- [Visual Studio 2017 version >= 15.8 with .NET Core SDK 2.2.101](https://www.microsoft.com/net/download/all)

#### Steps to run

- Be sure you are in "enson-be" folder.
- Build whole solution.
- In Solution Explorer, make sure that "enson-be" is selected as the Startup Project
- {Open Package Manager Console Window and make sure that "enson-be" is selected as Default project. Then type "Update-Database" then press "Enter". This action will create database schema.} NO NEED !!
- In Visual Studio, press "Control + F5".

## Mac/Linux with PostgreSQL

#### Prerequisite

- [Postgresql](https://www.postgresql.org/download/)
- [pgAdmin4](https://www.pgadmin.org/download/)
- [.NET Core SDK 2.2.101](https://www.microsoft.com/net/download/all)

#### Steps to run
- Be sure you are in enson-be folder.
- {Update the connection string in appsettings.json
- Run file linux-build.sh by "sudo ./linux-build.sh". For ubuntu 18 "sudo bash linux-build.sh"} NO NEED!!
- In the terminal, type "dotnet run" or "dotnet watch run" and hit "Enter".
- Call register API: http://localhost:5000/api/register/

## Guide for Postgresql GUI with pgAdmin4
- Create new Server in "Browser"
- Naming "enson-project" in General tab
- In "Connection" tab put:
    - Host name/address: ec2-54-221-236-144.compute-1.amazonaws.com
    - Port:5432
    - Maintenance database: de2vih2jcgbu4k
    - Username: zdkttvdaxhtdxw
    - Password: b1e03365232c9676072635def7ca577b19bb7d3c00ccad42963f47b3a0109e36
- In Database, let find "de2vih2jcgbu4k" database. It is our database.