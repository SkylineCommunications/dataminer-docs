---
uid: Class_Library_packages
---

# Class Library packages

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [About the class library](xref:ClassLibraryIntroduction).
>
> If you have a connector or automation script that makes use of a community package, we recommend turning this into a NuGet package. For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.
>
> Note also that the class library has been split up into multiple NuGet packages and that the namespaces have been updated:
>
> - [Skyline.DataMiner.Core.DataMinerSystem.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Common) allows interaction with a DataMiner System.
> - [Skyline.DataMiner.Core.DataMinerSystem.Automation](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Automation) contains extension methods for accessing an IDms instance via the Engine class or IEngine interface.
> - [Skyline.DataMiner.Core.DataMinerSystem.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Core.DataMinerSystem.Protocol) contains extension methods for retrieving an IDms instance via the SLProtocol interface.
> - [Skyline.DataMiner.Core.InterAppCalls.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.InterAppCalls.Common) contains the InterApp functionality.
> - [Skyline.DataMiner.Core.Matrix.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Core.Matrix.Protocol) allows you to define a matrix component in a connector.
> - [Skyline.DataMiner.Utils.SNMP](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SNMP) defines types related to SNMP.
> - [Skyline.DataMiner.Utils.Rates.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Rates.Protocol) defines types for calculation rates in a connector.
> - [Skyline.DataMiner.Utils.Rates.Common](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Rates.Common) defines types related to calculating rates.
> - [Skyline.DataMiner.Utils.SafeConverters](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SafeConverters) defines types that allow safe conversion from double to integers.
> - [Skyline.DataMiner.Utils.Interfaces](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Interfaces) defines types for calculation rates of interfaces.
> - [Skyline.DataMiner.Utils.SNMP.Traps.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SNMP.Traps.Protocol) provides functionality to easily parse traps in a connector.
> - [Skyline.DataMiner.Utils.Table.ContextMenu](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Table.ContextMenu) provides functionality to easily create a custom context menu.
