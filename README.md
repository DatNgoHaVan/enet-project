# enson-project
An social network project for training.


## Build Status
| Build server    | Platform       | Status      |
|-----------------|----------------|-------------|
|Travis           | Linux / MacOS  |[![Build Status](https://travis-ci.com/DatNgoHaVan/enson-project.svg?branch=dev)](https://travis-ci.com/DatNgoHaVan/enson-project) |

#THESE GUIDE FOR RUNNING BACK-END

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