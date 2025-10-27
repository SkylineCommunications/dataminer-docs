---
uid: DisInfoBars
---

# Info bars

When opening a solution supported by DIS, e.g. a connector solution, DIS will perform some checks on the solution and show an info bar when it found an issue.

The following info bars are available:

- **DevPack usage**: One or more projects in the solution reference DataMiner assemblies, but do not use the [DataMiner DevPack NuGet packages](xref:TOODataMinerDevPackages).
- **Incorrect references**: One or more incorrect assembly references are detected in the solution.
- **Incorrect target framework**: Not all C# projects target .NET Framework 4.8.
- **Obsolete class library generation feature**: The solution uses the deprecated [class library generation feature](xref:Class_Library_packages).
- **Outdated analyzer files**: One or more code analysis files or settings in the solution are not up to date.
- **Protocol extensions NuGet**: One or more projects in the solution do not reference the [Protocol Extensions NuGet package](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) or reference an outdated version. Introduced in DIS 3.1.7<!-- RN 42021 -->.
- **Secure Coding NuGet**: One or more projects in the solution do not reference the [Secure Coding Analyzers NuGet package](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SecureCoding.Analyzers) or reference an outdated version.
- **StyleCop Analyzers NuGet**: One or more projects in the solution do not use the correct StyleCop.Analyzers NuGet package.
- **UTF-8 header**: The file does not contain the UTF-8 header signature bytes. This could cause problems when uploading this file to DataMiner.

As of DIS version 3.1.5 <!-- RN 41840 -->, the info bar logic is triggered 30s after opening the solution.
