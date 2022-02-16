---
uid: Class_Library_packages
---

# Class Library packages

A Class Library package (CLP) contains generic code that can be shared by multiple QActions and Automation scripts.

In a Class Library package, you can add extension methods, vendor-specific code (which, for example, processes data from proprietary communication protocols), project-specific code that needs to be used by different protocols, etc.

- When DIS detects that a QAction uses code from a loaded Class Library package, it will generate a separate QAction (with ID 63000) containing only the code necessary to be able to use the wanted functionally.
- When DIS detects that code from a loaded Class Library package is used in EXE blocks of an Automation script, it will

    - add a new EXE block to that script containing only the code necessary to be able to use the wanted functionally, and
    - add references in the EXE blocks using that Class Library code to the newly added EXE block containing the Class Library code.

> [!NOTE]
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

When DIS generates a Class Library QAction (with ID 63000) or a Class Library EXE block, it will copy the contents of the Manifest.xml file to the QActions section of the Protocol.xml file or the top of the EXE block respectively. That way, when the Protocol file or Automation script file is opened later on, DIS will be able to determine from which Class Library packages code was copied.

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
> *\<CodePackage xmlns=”http://www.skyline.be/ClassLibrary”>*

## Version numbering

### Base packages

Base packages, i.e. default packages shipped with DIS, have a version number made up of four components:

| Component | Description |
|-----------|-------------|
| Major release | Start with “1” for the first release, and increment each time you make a new major release. |
| Minimum DataMiner version | This number indicates the minimum DataMiner version required for the package to work (e.g. 1=DM 8.5, 2=DM 9.6, etc.). |
| Major change | Increment this number when the package contains changes that break functionality present in the previous version (e.g. API changes). |
| Iteration | Increment this number when the package contains changes that do not break functionality present in the previous version (e.g. API additions). |

### Community packages

If you create a custom community package, you are free to use your own versioning system as long as the version number is made up of four components.

## DLL references

When an external DLL file is needed to be able to execute a piece of code, a “DllImport” line has to be added above that piece of code.

Whenever DIS detects at least one such line above a piece of code that is being used in a QAction, it will automatically add a DLL import statement when it generates the Class Library QAction. This means, that you do not have to add a “DllImport” line above every possible piece of code. Instead, you can just add one above a piece of code of which you know it will be included in the code that DIS will generate.

In the following example, a "DllImport" line was added above a piece of code:

```txt
[Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")]
Void Method1(){…}
```

## Restrictions

When DIS loads a package, it will combine C# code from different sources into a single C# code unit. This means, that it will not be possible to use certain C# features.

The following C#/.NET features are currently not supported:

- With regard to LINQ queries, “query syntax” is not supported. Only “method syntax” is supported.

    > [!NOTE]
    > For more information about the difference between these two types of syntax, see<br>https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

- #region tags are only allowed within members of a class (properties, methods, etc.).
- DllImport tags need to be fully qualified. Use e.g. *\[Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")\]* instead of *\[DllImport("Newtonsoft.Json.dll")\]*. If a DllImport tag is not fully qualified, DIS will not be able to detect the DLL file before compiling the code.

## Class Library versions

### Ranges

| Range   | Supported as from DataMiner version... |
|---------|----------------------------------------|
| 1.0.x.x | 9.0.0                                  |
| 1.1.x.x | 9.6.3                                  |
| 1.2.x.x | 10.0.3                                 |

### Released versions

[DIS 2.18](https://community.dataminer.services/documentation/dis-v2-18-release-notes/)

- 1.0.0.1

    - RN 22296: SetParameterMessage messages will no longer generate information events
    - RN 22297: GetAgents (IDms) would fail if the response contained a DataMiner Agent ID equal to 0
    - RN 22299: Property type is now passed along when updating element properties
    - RN 22301: ‘Name’ and ‘HostName’ properties added to IDma interface
    - RN 22302: New classes to easily parse trap information

[DIS 2.19](https://community.dataminer.services/documentation/dis-v2-19-release-notes/)

- No changes to the Class Library base packages

[DIS 2.20](https://community.dataminer.services/documentation/dis-v2-20-release-notes/)

- No changes to the Class Library base packages

[DIS 2.21](https://community.dataminer.services/documentation/dis-v2-21-release-notes/)

- 1.0.0.2

    - RN 23075: New matrix classes added to facilitate matrix and router control implementations

- 1.1.0.1

    - RN 23075: New matrix classes added to facilitate matrix and router control implementations
    - RN 23298: New InterApp classes now provide a C# message/response architecture

[DIS 2.22](https://community.dataminer.services/documentation/dis-v2-22-release-notes/)

- No changes to the Class Library base packages

[DIS 2.23](https://community.dataminer.services/documentation/dis-v2-23-release-notes/)

- 1.0.0.3

    - RN 22303: View name would be retrieved when it was already known
    - RN 23514: Element properties will only be retrieved when needed
    - RN 23515: Exception thrown after detecting an element with duplicate properties will now also contain the name of the ID of the element

- 1.1.0.2

    - RN 22303: View name would be retrieved when it was already known
    - RN 23514: Element properties will only be retrieved when needed
    - RN 23515: Exception thrown after detecting an element with duplicate properties will now also contain the name of the ID of the element

[DIS 2.24](https://community.dataminer.services/documentation/dis-v2-24-release-notes/)

- 1.0.1.1

    - RN 24283: New Rates namespace
    - RN 24290: element.IsStartupComplete method would throw an exception when executed on an element that had been stopped
    - RN 24291: Problem when updating properties
    - RN 24293: Problem when requesting an element with duplicate properties
    - RN 24357: GetAlarmTemplates() and GetTrendTemplates() would not work when the protocol was a production protocol

- 1.1.2.1

    - RN 24066: DMS Monitors
    - RN 24283: New Rates namespace
    - RN 24290: element.IsStartupComplete method would throw an exception when executed on an element that had been stopped
    - RN 24291: Problem when updating properties
    - RN 24293: Problem when requesting an element with duplicate properties
    - RN 24357: GetAlarmTemplates() and GetTrendTemplates() would not work when the protocol was a production protocol
    - RN 24456: Table cell subscriptions will now be established using the primary key

[DIS 2.25](https://community.dataminer.services/documentation/dis-v2-25-release-notes/)

- 1.0.1.2

    - RN 24756: Problem recreating the monitor after an element restart
    - RN 24934: Enhanced handling of errors occurring while parsing element information returned by a GetElements method

- 1.1.2.2

    - RN 24756: Problem recreating the monitor after an element restart
    - RN 24934: Enhanced handling of errors occurring while parsing element information returned by a GetElements method

[DIS 2.26](https://community.dataminer.services/documentation/dis-v2-26-release-notes/)

- 1.0.1.3

    - RN 25127: Matrix Helper: Serialized matrix status information

- 1.1.2.3

    - RN 24951: Retrieving data from partial tables
    - RN 25127: Matrix Helper: Serialized matrix status information
    - RN 25442: Class Library - InterApp calls: Problem when checking the mapping dictionary
    - RN 25585: Retrieving SNMP connection information & creating elements with SNMP connections

- 1.2.0.1

    - RN 24951: Retrieving data from partial tables
    - RN 25127: Matrix Helper: Serialized matrix status information
    - RN 25442: Class Library - InterApp calls: Problem when checking the mapping dictionary
    - RN 25585: Retrieving SNMP connection information & creating elements with SNMP connections
    - RN 25632: IEngine interface now supports the extension of the GetDms method

[DIS 2.27](https://community.dataminer.services/documentation/dis-v2-27-release-notes/)

- 1.1.2.4

    - RN 25933: Deserialization now supports classes located in both System.Core.dll and System.dll.

- 1.2.0.2

    - RN 25933: Deserialization now supports classes located in both System.Core.dll and System.dll.

[DIS 2.28](https://community.dataminer.services/documentation/dis-v2-28-release-notes/)

- 1.1.2.5

    - RN 26422: DataMiner System interface would thrown an exception when parsing elements in a view
    - RN 26423: Incorrectly formatted input string would cause the GetElement method to throw an exception

- 1.2.0.3

    - RN 26422: DataMiner System interface would thrown an exception when parsing elements in a view
    - RN 26423: Incorrectly formatted input string would cause the GetElement method to throw an exception

[DIS 2.29](https://community.dataminer.services/documentation/dis-v2-29-release-notes/)

- No changes to the Class Library base packages

[DIS 2.30](https://community.dataminer.services/documentation/dis-v2-30-release-notes/)

- 1.1.2.7

    - RN 27783: Name of an element with a RealConnection could no longer be updated
    - RN 27784: A matrix output could not be disconnected when it was connected to the first input

- 1.2.0.4

    - RN 27783: Name of an element with a RealConnection could no longer be updated
    - RN 27784: A matrix output could not be disconnected when it was connected to the first input

[DIS 2.31](https://community.dataminer.services/documentation/dis-v2-31-release-notes/)

- No changes to the Class Library base packages

[DIS 2.32](https://community.dataminer.services/documentation/dis-v2-32-release-notes/)

- 1.1.2.8

    - RN 29070: IDms classes now support creating, updating and retrieving HTTP connections of elements
    - RN 29071: In IDP environments, extension methods now allow you to retrieve CI Type information from connections
    - RN 29072: IDms classes now support creating and deleting properties in a DataMiner System
    - RN 29074: SLNet wrapper methods now allow you to safely communicate with the SLScheduler and SLSpectrum modules

- 1.2.0.5

    - RN 29070: IDms classes now support creating, updating and retrieving HTTP connections of elements
    - RN 29071: In IDP environments, extension methods now allow you to retrieve CI Type information from connections
    - RN 29072: IDms classes now support creating and deleting properties in a DataMiner System
    - RN 29074: SLNet wrapper methods now allow you to safely communicate with the SLScheduler and SLSpectrum modules

[DIS 2.33](https://community.dataminer.services/documentation/dis-v2-33-release-notes/)

- 1.1.2.9

    - RN 29440: IsSslTlsEnabled property of all ports of an element would incorrectly be reset to false when an element port had been updated
    - RN 29442: IElementCollection now implements IEnumerable
    - RN 29513: DmsService class can now be used to manage DataMiner services
    - RN 29515: Monitors added to subscribe to service alarm level and service state

- 1.1.2.10

    - RN 29777: Additional check to prevent elements to restart after being updated

- 1.1.2.11

    - RN 30053: RemotePort would throw “null reference” exceptions when trying to retrieve a replicated element
    - RN 30055: Monitors that subscribe to a table can now execute code whenever data in that table is updated
    - RN 30056: SLSpectrum wrappers were missing a GetMonitor call with the correct return format

- 1.2.0.6

    - RN 29440: IsSslTlsEnabled property of all ports of an element would incorrectly be reset to false when an element port had been updated
    - RN 29442: IElementCollection now implements IEnumerable
    - RN 29513: DmsService class can now be used to manage DataMiner services
    - RN 29515: Monitors added to subscribe to service alarm level and service state

- 1.2.0.7

    - RN 30053: RemotePort would throw “null reference” exceptions when trying to retrieve a replicated element
    - RN 30055: Monitors that subscribe to a table can now execute code whenever data in that table is updated
    - RN 30056: SLSpectrum wrappers were missing a GetMonitor call with the correct return format

[DIS 2.34](https://community.dataminer.services/documentation/dis-v2-34-release-notes/)

- 1.1.2.12

    - RN 30232: Extended authentication algorithm support

- 1.2.0.8

    - RN 30232: Extended authentication algorithm support

[DIS 2.35](https://community.dataminer.services/documentation/dis-v2-35-release-notes/)

- No changes to the Class Library base packages

[DIS 2.36](https://community.dataminer.services/documentation/dis-v2-36-release-notes/)

- No changes to the Class Library base packages
