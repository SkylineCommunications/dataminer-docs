---
uid: TOONuGet
---

# NuGet packages

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

NuGet is the package manager for .NET. DIS and our CI/CD pipeline provide tools to produce and consume NuGet Packages for use in System Development (protocols, Automation scripts, custom solutions). A package is a collection of DLLs (and possibly also other items) with well-tested code that can easily be distributed, upgraded and shared.

The NuGet Gallery (<https://nuget.org>) is the central package repository used by all package authors and consumers.
Within Skyline, we also use an internal NuGet server: <https://devcore3/nuget>.

- [Consuming NuGet packages](xref:Consuming_NuGet)

- [Producing NuGet](xref:Producing_NuGet)

- [Middleware NuGet packages](xref:Nuget_Communication_Middleware)

  - [OpenConfig Middleware](xref:DSI_OpenConfig_Middleware): Facilitates OpenConfig implementations in a DataMiner environment.

- [Assembly binding](xref:Assembly_Binding)
