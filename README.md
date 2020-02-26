# HwInfoReader

.Net Core Library which uses the HwInfoLibrary dll to read HwInfo sensors and readings. 


HwInfoLibrary source code found here: https://github.com/Antiserum420/HwInfoLibrary

| Package  | Description |
| ------------- | ------------- |
| HwInfoReader  | The core package. Use this on the executable dll (e.g. the WebApi project)  |
| HwInfoReader.Abstractions  | 	The interfaces for classes that implement the HwInfoReader. Use this project for netstandard dlls (e.g. the infrastructure or connectors project)  |
| HwInfoReader.AspNetCore  | ASP.NET Core package which contains dependency injection extensions for registering HwInfoReader in AspNet Core projects  |

# Release notes

version 1.0.0:
- Initial release

# Setup
Add the appropriate package(s) to your solution. Normally, you would add `HwInfoReader.Abstractions` to the project containing the infrastructure implementations, and `HwInfoReader.AspNetCore` to the MVC.Net project(s).

When using the HwInfoReader implementation, add the following code to the `ConfigureServices` method of your application:

```C#
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddHwInfoReader();
}
```

This will add an IHwInfoReader object to dependency injection that can be used to read HwInfo sensors and readings.
This interface contains three methods:

```C#
public void ConfigureServices(IServiceCollection services)
{
    IEnumerable<HwInfoSensorElement> ReadSensors();

    IEnumerable<HwInfoSensorReadingElement> ReadSensorReadings();
}
```
