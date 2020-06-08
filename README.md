# BlogAPI

## Server Set Up

install [.Net SDK](https://dotnet.microsoft.com/download)

```
dotnet tool install --global dotnet-ef
```
### Create database 
```sql
CREATE DATABASE blogdatabase
#if use Mysql run:
CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );
```
### Change Your SQL Provider
./__Startup.cs__ 
```c#
public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))); //MySQL <=== HERE
                // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //SQLServer <===HERE
        ...
```

### Edit your connetion string
./__appsettings.json__
```c#
{
  ,
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServer;User=username;Password=password;Database=BlogDatabase;" 
  }
}
```

### Migrate
```
dotnet ef migrations add InitialCreate --context DBContext
dotnet ef database update
dotnet run
```
