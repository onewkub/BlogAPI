# BlogAPI

## Server Set Up

install [.Net SDK](https://dotnet.microsoft.com/download)

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --context DBContext
dotnet ef database update
dotnet run
```
