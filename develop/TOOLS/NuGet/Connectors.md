---
uid: AssemblyResolvingConnectors
---

# Connectors

In connectors, the assembly file paths mentioned in the [QAction@dllImport](xref:Protocol.QActions.QAction-dllImport) attribute are used as follows:

- compile time: The assembly file paths are added as references to the compilation engine. If the specified path denotes a folder, it is not added as a reference to the compiler.
- run time: The folder denoted by the path is added as a hint path to the assembly resolver.

In connectors, there is support to provide a folder path in the `QAction@dllImport` attribute. Therefore, you can reference multiple versions of an assembly in your connector (e.g. when multiple versions of a NuGet package are used because of transitive NuGet package references). The most recent version of the assembly will be added as a reference for compilation and both folder paths will be added as hint paths for resolving at run time.

However, to avoid issues, it is important to adhere to the limitations stated in [Multiple versions of the same assembly](xref:Run_Time_Assembly_Binding#multiple-versions-of-the-same-assembly).

> [!NOTE]
> Note that the behavior in Automation scripts is different from connectors as in Automation scripts it **is not** possible to specify a folder path as hint path. For more information, refer to [Automation scripts](xref:AssemblyResolvingAutomationScripts).
