---
uid: Assembly_Binding
---

# Assembly binding

NuGets use and install DLLs in the background. Issues may occur from assembly binding that might be difficult to debug.

These issues have to do with:

- DLLs for the same library but with other versions.

- Dependencies between DLLs and NuGet packages.

This can cause exceptions during serializing and deserializing, for example “Class A not being able to deserialize into a type of Class A”.

Make sure you keep the versions of libraries in sync as much as possible.

To help with debugging, it can be useful to know more about how DLLs are loaded in DataMiner. There are two parts to loading assemblies: [Compilation-time assembly binding](xref:Compilation_Time_Assembly_Binding) and [Run-time assembly binding](xref:Run_Time_Assembly_Binding).

Remember that it is not because compilation succeeds that no issues can occur at run-time.
