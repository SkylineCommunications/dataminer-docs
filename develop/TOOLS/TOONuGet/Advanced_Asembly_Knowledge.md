---
uid: Advanced_Assembly_Knowledge
---

# Advanced Assembly Knowledge

NuGets will be using and installing DLLs in the background. Issues may occur from assembly binding that might be difficult to debug.

Issues having to do with:
>- DLLs for the same library but with other versions.
>- Dependencies between DLLs and NuGet packages.

This can cause exceptions during Serialize & Deserialize for example. (“Class A not being able to deserialize into a type of Class A”)

Our suggestion here is to try and make sure you keep the versions of libraries in-sync as much as possible.

The following is detailed background information that explains more about how DLLs are loaded up in DataMiner, which can help with debugging.

There are two parts to loading assemblies. Compilation Time Assembly Loading and Run-time Assembly loading. Remember that it’s not because something works during compilation that it will work at runtime.

- [Compilation-Time Assembly Binding](xref:Compilation_Time_Assembly_Binding)

- [Run-Time Assembly Binding](xref:Run_Time_Assembly_Binding)