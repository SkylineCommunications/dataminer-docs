---
uid: Class_Library_packages
---

# Class Library packages

## [From DIS 2.41 onwards](#tab/CLP-1)

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.
>
> Note also that the class library has been split up into multiple NuGet packages and that the namespaces have been updated:
>
> - [Skyline.DataMiner.Core.DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common): This NuGet package allows interaction with a DataMiner System.
> - [Skyline.DataMiner.Core.DataMinerSystem.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Automation): This NuGet package contains extension methods for accessing an IDms instance via the Engine class or IEngine interface.
> - [Skyline.DataMiner.Core.DataMinerSystem.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Protocol): This NuGet package contains extension methods for retrieving an IDms instance via the SLProtocol interface.
> - [Skyline.DataMiner.Core.InterAppCalls.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.InterAppCalls.Common): This NuGet package contains the InterApp functionality.
> - [Skyline.DataMiner.Core.Matrix.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Core.Matrix.Protocol): This NuGet package allows you to define a matrix component in a connector.
> - [Skyline.DataMiner.Utils.SNMP](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SNMP): This NuGet package defines types related to SNMP.
> - [Skyline.DataMiner.Utils.Rates.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Rates.Protocol): This NuGet package defines types for calculation rates in a connector.
> - [Skyline.DataMiner.Utils.Rates.Common](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Rates.Common): This NuGet package defines types related to calculating rates.
> - [Skyline.DataMiner.Utils.SafeConverters](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SafeConverters): This NuGet package defines types that allow safe conversion from double to integers.
> - [Skyline.DataMiner.Utils.Interfaces](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Interfaces): This NuGet package defines types for calculation rates of interfaces.
> - [Skyline.DataMiner.Utils.SNMP.Traps.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SNMP.Traps.Protocol): This NuGet package provides functionality to easily parse traps in a connector.
> - [Skyline.DataMiner.Utils.Table.ContextMenu](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Table.ContextMenu): This NuGet package provides functionality to easily create a custom context menu.

## [Prior to DIS 2.41](#tab/CLP-2)

A Class Library package (CLP) contains generic code that can be shared by multiple QActions and Automation scripts.

In a Class Library package, you can add extension methods, vendor-specific code (which, for example, processes data from proprietary communication protocols), project-specific code that needs to be used by different protocols, etc.

- When DIS detects that a QAction uses code from a loaded Class Library package, it will generate a separate QAction (with ID 63000) containing only the code necessary to be able to use the wanted functionally.
- When DIS detects that code from a loaded Class Library package is used in EXE blocks of an Automation script, it will

  - add a new EXE block to that script containing only the code necessary to be able to use the wanted functionally, and
  - add references in the EXE blocks using that Class Library code to the newly added EXE block containing the Class Library code.

> [!NOTE]
>
> - Interfaces, base classes and their implementations will all be copied together into the generated QAction or Automation script.<br>If the generator detects that an interface is being used while the class that implements it is not, then the latter will be copied along into the generated code. Also, if a class is being used while the interface is not, then both will be copied into the generated code.
> - The generated code will contain all fields and properties of classes, unless they are private, even when those fields and properties are not being used.

## Types of Class Library packages

There are two types of Class Library packages:

| Type | Description |
|------|-------------|
| Base packages | Default packages shipped with DIS. |
| Custom packages, a.k.a Community packages | Packages containing code which was written specifically for a particular vendor or project and which is maintained by a dedicated team of developers. |

## Structure of a Class Library package

A Class Library package is basically a zip file containing

- a mandatory Manifest.xml file in the root folder, and
- one or more C# files, which can be organized in subfolders.

Example:

```txt
Package.zip
    Manifest.xml
    Class1.cs
    Directory1
        Class2.cs
        Class3.cs
    Directory2
        ...
```

## Manifest.xml file

The Manifest.xml file, which must be placed in the zip file’s root folder, describes the content of the package and lists the dependencies between the package in question and other packages.

When DIS generates a Class Library QAction (with ID 63000) or a Class Library EXE block, it will copy the contents of the Manifest.xml file to the QActions section of the *protocol.xml* file or the top of the EXE block respectively. That way, when the Protocol file or Automation script file is opened later on, DIS will be able to determine from which Class Library packages code was copied.

A Manifest.xml file could, for example, contain the following information:

```xml
<CodePackage xmlns="http://www.skyline.be/ClassLibrary">
  <Identity>
    <Name>Custom Library</Name>
    <Version>1.0.2.4</Version>
  </Identity>
  <MinimumRequiredVersion>9.6.0.0 - 8235</MinimumRequiredVersion>
  <Dependencies>
    <Dependency min="1.0.0.1" max="1.0.0.2">Class Library</Dependency>
  </Dependencies>
</CodePackage>
```

For more information about the tags used in a Manifest.xml file, see below:

| Tag | Mandatory? | Description |
|-----|------------|-------------|
| Identity.Name | Yes | The (unique) name of the package. |
| Identity.Version | Yes | The version of the package.<br>For more information, see [Version numbering](#version-numbering) |
| MinimumRequiredVersion | No | The minimum required version of the DataMiner Agent (or another application) needed for the package to be used.<br>Currently, this tag is for informational purposes only. |
| Dependencies.Dependency | No | The name of another package DIS has to load before it can use the package.<br>A Dependency tag has two optional attributes:<br>-  min: The lowest compatible version of the package<br>-  max: The highest compatible version of the package<br>Note: When DIS cannot find a package specified in a Dependency tag, it will show a warning message, saying that the package (i.e. the one specified in the Identity tag) could not be loaded. |

> [!NOTE]
> If you want IntelliSense support when creating a Manifest.xml file, make sure to add the correct XML namespace to the \<CodePackage> tag:
> *\<CodePackage xmlns="http://www.skyline.be/ClassLibrary">*

## Version numbering

### Base packages

Base packages, i.e. default packages shipped with DIS, have a version number made up of four components:

| Component | Description |
|-----------|-------------|
| Major release | Start with "1" for the first release, and increment each time you make a new major release. |
| Minimum DataMiner version | This number indicates the minimum DataMiner version required for the package to work (e.g. 1=DM 8.5, 2=DM 9.6, etc.). |
| Major change | Increment this number when the package contains changes that break functionality present in the previous version (e.g. API changes). |
| Iteration | Increment this number when the package contains changes that do not break functionality present in the previous version (e.g. API additions). |

### Community packages

If you create a custom community package, you are free to use your own versioning system as long as the version number is made up of four components.

## DLL references

When an external DLL file is needed to be able to execute a piece of code, a "DllImport" line has to be added above that piece of code.

Whenever DIS detects at least one such line above a piece of code that is being used in a QAction, it will automatically add a DLL import statement when it generates the Class Library QAction. This means, that you do not have to add a "DllImport" line above every possible piece of code. Instead, you can just add one above a piece of code of which you know it will be included in the code that DIS will generate.

In the following example, a "DllImport" line was added above a piece of code:

```txt
[Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")]
Void Method1(){…}
```

## Restrictions

When DIS loads a package, it will combine C# code from different sources into a single C# code unit. This means, that it will not be possible to use certain C# features.

The following C#/.NET features are currently not supported:

- With regard to LINQ queries, "query syntax" is not supported. Only "method syntax" is supported.

    > [!NOTE]
    > For more information about the difference between these two types of syntax, see<br>https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

- #region tags are only allowed within members of a class (properties, methods, etc.).
- DllImport tags need to be fully qualified. Use e.g. *\[Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")\]* instead of *\[DllImport("Newtonsoft.Json.dll")\]*. If a DllImport tag is not fully qualified, DIS will not be able to detect the DLL file before compiling the code.
