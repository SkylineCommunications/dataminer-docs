---
uid: Run_Time_Assembly_Binding
---

# Run-Time Assembly Binding

This happens when:
- code reaches a method that’s present in a different DLL

During Run-Time assemblies are loaded the moment the code needs it.
When the JIT Compiler compiles IL it sees which types are referenced. The JIT Compiler will then determine the assemblies that define these types and these will be loaded.

So this means that at that point it will look for any dependencies. To find those assemblies, it will look through all the ‘hintpaths’ which are directories that could contain those DLLs.

In the case of DataMiner, because protocol.xml and script.xml compiles on DataMiner itself, we add all the possible places such dependency DLLs may be present using the <Param Ref> tags in scripts or dllImport attributes in QActions.

    To understand better, the following example will be used:
    you have a custom solution using the class Library and you’re using that custom solution in an automation script.

    In the above example it means it would also try to find the class library DLLs when it encounters a class library method.
    That would mean if those DLLs were not present, it would only throw an exception about it at run-time.
    It might also throw exceptions if the DLLs of the right version are not present. 
    e.g., If V1 is needed but V3 is present, then it can throw exceptions. 

Typically, unification is performed (using Binding Redirects which are part of the .config file next to an .exe).
That says that any call to V1 should redirect to V3 for example.

This is called ‘unification’ of assemblies. Having all lower versions redirect to a single highest version.
In DataMiner this approach is currently not usable. Instead, we provide all versions in their subfolders within DllImport so it can work without redirects. This does have some disadvantages like increased risk of versioning issues. So pay attention to your NuGet versions.