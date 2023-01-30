---
uid: ClassLibraryIntroduction
---

# Class library introduction

The Skyline.DataMiner.Core.DataMinerSystem namespace defines types that can be used to implement DataMiner-related logic in protocols and Automation scripts. It provides types for interacting with a DataMiner Agent to e.g. create elements, update element settings, work with views, edit properties, parse traps, etc.

The namespace consists of three sub-namespaces:

- [Skyline.DataMiner.Core.DataMinerSystem.Common](xref:Skyline.DataMiner.Library.Common): This namespace contains all the types that can be used in both protocols and Automation scripts.
- [Skyline.DataMiner.Core.DataMinerSystem.Protocol](xref:Skyline.DataMiner.Library.Protocol): This namespace contains all the types that are only relevant in protocols.
- [Skyline.DataMiner.Core.DataMinerSystem.Automation](xref:Skyline.DataMiner.Library.Protocol): This namespace contains all the types that are only relevant in Automation scripts.

> [!NOTE]
> Using this class library, you can retrieve parameter values, tables, etc. from elements. However, it is important to note that this should only be used for obtaining values from other elements. To perform operations on the local element, it is advised to use the [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) API as this is much more efficient (This is because the operation is then performed in the SLProtocol process immediately).

For example, to start using the DMS class library from a QAction, use the [GetDms](xref:Skyline.DataMiner.Library.Protocol.SlProtocolExtensions.GetDms(Skyline.DataMiner.Scripting.SLProtocol)) extension method:

```xml
IDms dms = slProtocol.GetDms();
```

The GetDms method (see SLProtocolExtensions.GetDms method ) is an extension method on the SLProtocol interface that returns an object that implements the IDms interface.

Refer to [Examples](xref:ClassLibraryExamples) for some example use cases.

> [!NOTE]
> If you are a Skyline employee and you are interested in adding or changing the base class library, see [ClassLibraryDevelopment](xref:ClassLibraryDevelopment).
