---
uid: Compilation_Time_Assembly_Binding
---

# Compilation-time assembly binding

This happens at the following times:

- During Visual Studio building.
- Right before the first execution of the QAction (if the [precompile](xref:Protocol.QActions.QAction-options#precompile) option is used, the QAction is compiled immediately).
- When an Automation script is uploaded or its library script changes.

To compile, the compiler only requires the directly referenced assemblies. The compiler does not know about transitive dependencies for that assembly.

To better understand this, imagine the following example: You have a custom solution using the Class Library, and you are using that custom solution in an Automation script. During compile time of the script, it will search for the custom solution DLL and verify for errors. It will not care about whether Class Library DLLs are present. It will not report any errors that may happen because the Class Library is or is not present.
