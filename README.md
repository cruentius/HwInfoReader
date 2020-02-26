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
This interface contains two methods:

```C#
public interface IHwInfoReader
{
    IEnumerable<HwInfoSensorElement> ReadSensors();

    IEnumerable<HwInfoSensorReadingElement> ReadSensorReadings();
}
```

# Usage
ReadSensors() method reads the available motherboard sensors and will return an enumeration of HwInfoSensorElements. Each HwInfoSensorElement looks like this:

```C#
    public struct HwInfoSensorElement
    {
        public uint dwSensorID; 
        public uint dwSensorInst;
        public string szSensorNameOrig;
        public string szSensorNameUser;
    };
```

| Field  | Description |
| ------------- | ------------- |
| dwSensorID  |  a unique Sensor ID |
| dwSensorInst  | the instance of the sensor (together with dwSensorID forms a unique ID) |
| szSensorNameOrig  | original sensor name |
| szSensorNameUser  | sensor name displayed, which might have been renamed by user |

ReadSensorReadings() method reads the available motherboard sensor readings and will return an enumeration of HwInfoSensorReadingElements. Each HwInfoSensorReadingElement looks like this:

```C#
    public struct HwInfoSensorReadingElement
    {
        public SensorReadingType tReading;
        public uint dwSensorIndex;
        public uint dwReadingID;
        public string szLabelOrig;
        public string szLabelUser;
        public string szUnit;
        public double Value;
        public double ValueMin;
        public double ValueMax;
        public double ValueAvg;
    };
```

| Field  | Description |
| ------------- | ------------- |
| tReading  | type of sensor reading (e.g Clock, Temp, Volt) |
| dwSensorIndex  | this is the index of sensor in the Sensors[] array to which this reading belongs to |
| dwReadingID  | a unique ID of the reading within a particular sensor |
| szLabelOrig  | original label (e.g. "Chassis2 Fan") |
| szLabelUser  | label displayed, which might have been renamed by user |
| szUnit  | e.g. "RPM" |
| Value  | value of the sensor |
| ValueMin  | min value of the sensor |
| ValueMax  | max value of the sensor |
| ValueAvg  | average value of the sensor |
