# FirehouseSubs-NET [![FirehouseSubs NuGet](https://img.shields.io/nuget/vpre/FirehouseSubs?label=FirehouseSubs&style=flat-square)](https://www.nuget.org/packages/FirehouseSubs/)
A client for the unofficial Firehouse Subs API, written in C#/NET. You can get information for stores that are in a city, state, or zip code.

## Features:
- Asynchrous method calls
- Written in .NET 6.0 LTS
- Support for city, state, and zip code input. Also up to date endpoints!

## Notes:
- Exceptions are AggregateException with the InnerException property being HttpRequestException

## Examples:
### Get stores by state
```csharp
FirehouseClient client = new FirehouseClient();
List<FirehouseSubsStore> stores = client.GetStoresByStateAsync("Florida").Result;
foreach (FirehouseSubsStore store in stores) 
{
	Console.WriteLine("Store ID: " + store.Id);
	Console.WriteLine("Store Address: " + store.Address + store.Address2);
	Console.WriteLine("Store Online Order URL: " + store.OnlineOrderUrl);
}
```

### Get stores by city
```csharp
FirehouseClient client = new FirehouseClient();
List<FirehouseSubsStore> stores = client.GetStoresByCityAsync("Jacksonville").Result;
foreach (FirehouseSubsStore store in stores) 
{
	Console.WriteLine("Store ID: " + store.Id);
	Console.WriteLine("Store Address: " + store.Address + store.Address2);
	Console.WriteLine("Store Online Order URL: " + store.OnlineOrderUrl);
}
```

### Get stores by zip code
```csharp
FirehouseClient client = new FirehouseClient();
List<FirehouseSubsStore> stores = client.GetStoresByZipCodeAsync(32034).Result;
foreach (FirehouseSubsStore store in stores) 
{
	Console.WriteLine("Store ID: " + store.Id);
	Console.WriteLine("Store Address: " + store.Address + store.Address2);
	Console.WriteLine("Store Online Order URL: " + store.OnlineOrderUrl);
}
```
