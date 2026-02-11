---
uid: ClassLibraryIntroduction
description: The Skyline.DataMiner.Core.DataMinerSystem namespace defines types you can use to implement DataMiner-related logic in protocols and scripts.
---

# About the class library

The Skyline.DataMiner.Core.DataMinerSystem namespace defines types that can be used to implement DataMiner-related logic in protocols and Automation scripts. It provides types for interacting with a DataMiner System to e.g. create elements, update element settings, work with views, edit properties, etc.

The namespace consists of three sub-namespaces:

- [Skyline.DataMiner.Core.DataMinerSystem.Common](xref:Skyline.DataMiner.Core.DataMinerSystem.Common): This namespace contains all the types that can be used in both protocols and Automation scripts.
- [Skyline.DataMiner.Core.DataMinerSystem.Protocol](xref:Skyline.DataMiner.Core.DataMinerSystem.Protocol): This namespace contains all the types that are only relevant in protocols.
- [Skyline.DataMiner.Core.DataMinerSystem.Automation](xref:Skyline.DataMiner.Core.DataMinerSystem.Automation): This namespace contains all the types that are only relevant in Automation scripts.

> [!IMPORTANT]
>
> - If you encounter abbreviations like *SLC*, *Lib*, or *CLib*, make sure to update the NuGet packages to the latest version, as these are considered obsolete.
> - QAction 63000 Auto-generated Class Library is obsolete and should be replaced by the latest NuGet packages. See [Obsolete namespaces](xref:Obsolete_namespaces).

To use the class library in a protocol, install the following NuGet package: [Skyline.DataMiner.Core.DataMinerSystem.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Protocol).

To use the class library in an automation script, install the following NuGet package: [Skyline.DataMiner.Core.DataMinerSystem.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Automation).

Both packages have a dependency on the [Skyline.DataMiner.Core.DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common) NuGet package. Therefore, this package is installed automatically when Skyline.DataMiner.Core.DataMinerSystem.Protocol or Skyline.DataMiner.Core.DataMinerSystem.Automation are installed.

> [!NOTE]
> Using this class library, you can retrieve parameter values, tables, etc. from elements. However, it is important to note that this should only be used for obtaining values from other elements. To perform operations on the local element, it is advised to use the [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) API as this is much more efficient (This is because the operation is then performed in the SLProtocol process immediately).

For example, to start using the DMS class library **from a QAction**, use the [GetDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Protocol.SlProtocolExtensions.GetDms(Skyline.DataMiner.Scripting.SLProtocol)) extension method:

```xml
IDms dms = slProtocol.GetDms();
```

The GetDms method (see [SLProtocolExtensions.GetDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Protocol.SlProtocolExtensions.GetDms(Skyline.DataMiner.Scripting.SLProtocol)) method) is an extension method on the SLProtocol interface that returns an object that implements the IDms interface.

To start using the DMS class library **from an automation script**, use the [GetDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Automation.EngineExtensions.GetDms(Skyline.DataMiner.Automation.Engine)) extension method:

```xml
IDms dms = engine.GetDms();
```

The GetDms method (see [Engine.GetDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Automation.EngineExtensions.GetDms(Skyline.DataMiner.Automation.Engine)) method) is an extension method on the Engine interface that returns an object that implements the IDms interface.

Refer to [Examples](xref:ClassLibraryExamples) for some example use cases.

> [!NOTE]
> If you are a Skyline employee and you are interested in adding or changing the base class library, see [ClassLibraryDevelopment](xref:ClassLibraryDevelopment).
