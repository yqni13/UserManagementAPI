# yqni13 | $\texttt{\color{violet}{UserManagementAPI}}$
### $\textsf{\color{brown}{v1.0.0}}$

#### Coursera certificate ASP.NET Core project (user management api in .NET v10).

<br>

## 🪄 $\textsf{\color{salmon}Getting started}$


### $\textsf{\color{teal}Prerequisites}$
- .NET: v10.0.400

<br>

### $\textsf{\color{teal}Local setup}$
Download or clone project
```sh
git clone https://github.com/yqni13/UserManagementAPI.git
```

Manually add Properties/launchSettings.json to config port and environment secrets.
See configs for local development/testing and add values for <port> and <token>:
```sh
{
    "$schema": "https://json.schemastore.org/launchsettings.json",
    "profiles": {
        "http": {
            "commandName": "Project",
            "dotnetRunMessages": true,
            "launchBrowser": true,
            "launchUrl": "swagger",
            "applicationUrl": "http://localhost:<port>",
            "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development",
                "AUTH_TOKEN": <token>
            }
        }
    }
}
```

<br>

Restore ...
```sh
dotnet restore
```
... and build (bin/ and obj/ are created) ...
```sh
dotnet build
```

... before you run the application and wait for SwaggerUI to open in your browser.
```sh
dotnet run
```

<br>

## 🧩 $\textsf{\color{salmon}Features}$

| Feature | Description |
|---------|-------------|
| CRUD | Basic operations (Get all/single, Create, Update, Delete user)
