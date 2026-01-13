---
uid: Assembly_Binding
---

# Assembly binding

NuGet packages use and install assemblies in the background. Issues may occur from assembly binding that might be difficult to debug.

These issues have to do with:

- Assemblies for the same library but with other versions.
- Dependencies between assemblies and NuGet packages.

This can cause exceptions during serializing and deserializing, for example "Class A not being able to deserialize into a type of Class A".

Make sure you keep library versions in sync as much as possible.

To help with debugging, it can be useful to know more about how assemblies are loaded in the .NET Framework and DataMiner. There are two parts to loading assemblies:

- [Compilation-time assembly binding](xref:Compilation_Time_Assembly_Binding), and
- [Runtime assembly binding](xref:Run_Time_Assembly_Binding).

Remember that even when compilation succeeds, issues could still occur at runtime.

Note also that the [behavior in Automation scripts](xref:AssemblyResolvingAutomationScripts) is different from the [behavior in connectors](xref:AssemblyResolvingConnectors).
