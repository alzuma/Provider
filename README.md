# Provider
Dependency injection with provider

## Installation

```
Install-Package Provider
```

## Usage

#### Add Provider Injection in Startup.cs for your web app

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ****
    services.AddProviderInjection();
    // ****
}
```

#### Use provider as injection by specifying T which has to be provided
  
```csharp
public ValuesController(IProvider<ValueService> provider)
{
    _provider = provider;
}
```

####  Provider will instantiate a class and if needed will inject required instances from an ServiceProvider

```csharp
[HttpGet]
public IEnumerable<string> Get()
{
    return _provider.Get().GetValues();
}
```

####  Custom parameters can be passed to inject them

```csharp
[HttpGet("admin")]
public IEnumerable<string> GetAdmin()
{
	const string connectionString = "connectToAdminDB";
	return _provider.Get(connectionString).GetValues();
}
```
