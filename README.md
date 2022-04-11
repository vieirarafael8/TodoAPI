# Todo API

> Todo API is a .NET Core App that serves as a ticket managament web api.

## Requirements
* .NET 6
* SQL Server DBs

## Development Setup Instructions (With Docker & Make)
- Install Docker
- Run using Bash: `$ make local-docker-resources && make local-api` to run docker containers (sqlserver, etc...) and run the app
  - By default, runs app in `watch` mode. If you want to run without the mode watch use: `$ make local-api MODE=run`
- **Hint:** to remove all docker containers: `$ docker rm -f $(docker ps -aq)` 
- **Hint:** alternative to Sql Studio: `DBeaver`
- **Hint:** if you don't have/want to use `make`, you can check `Makefile` file, to see the scripts/commands


## Tests
All tests are inside `Unit-Tests`.

* Integration Tests needs a `SQL Server` instance, it's recommended you have `docker` so you can easilly setup container for it (contains db schemas & some test data), you can run `$ make local-docker-resources` to load a sql server docker container.