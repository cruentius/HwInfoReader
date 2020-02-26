# HwInfoReader

.Net Core Library which uses the HwInfoLibrary dll to read HwInfo sensors and readings. 


HwInfoLibrary source code found here: https://github.com/Antiserum420/HwInfoLibrary

| Package  | Description |
| ------------- | ------------- |
| HwInfoReader  | The core package. Use this on the executable dll (e.g. the WebApi project)  |
| HwInfoReader.Abstractions  | 	The interfaces for classes that implement the HwInfoReader. Use this project for netstandard dlls (e.g. the infrastructure or connectors project)  |
| HwInfoReader.AspNetCore  | ASP.NET Core package which contains dependency injection extensions for registering HwInfoReader in AspNet Core projects  |
