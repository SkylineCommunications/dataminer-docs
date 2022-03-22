---
uid: Compilation_Time_Assembly_Binding
---

# Compilation-Time Assembly Binding

This happens when:
- Visual Studio Building
- First time a QAction runs on DataMiner
- Automationscript is uploaded or its library script changes

To compile, the compiler only requires the directly referenced assemblies.
The compiler doesn’t know about transitive dependencies for that assembly.

    To understand better, the following example will be used:
    you have a custom solution using the class Library and you’re using that custom solution in an automation script.
    
    During compile time of the script it will search for the custom solution dll and verify for errors.
    It won’t care about class library DLLs being present or not
    It won’t report any errors that may happen from the class library being present or not.
