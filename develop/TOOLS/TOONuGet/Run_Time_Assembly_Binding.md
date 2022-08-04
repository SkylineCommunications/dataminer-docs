---
uid: Run_Time_Assembly_Binding
---

# Run-time assembly binding

This happens when code reaches a method that is present in a different DLL.

During run-time, assemblies are loaded the moment they are needed in the code. When the JIT compiler compiles IL, it sees which types are referenced. The JIT compiler will then determine the assemblies that define these types, and these will be loaded.

This means that at that point it will look for any dependencies. To find those assemblies, it will look through all the "hintpaths", which are directories that could contain those DLLs.

For DataMiner, because protocol.xml and script.xml are compiled in DataMiner itself, we add all the possible places such dependency DLLs may be present using the `<Param Ref>` tags in scripts or `dllImport` attributes in QActions.

To better understand this, imagine the following example: You have a custom solution using the Class Library, and you are using that custom solution in an Automation script. When the script is compiled, it will try to find the Class Library DLLs when it encounters a Class Library method. This means that if those DLLs are not present, it will only throw an exception about this at run-time. It may also throw exceptions if the DLLs with the right version are not present. For example, if V1 is needed, but V3 is present, it can throw an exception.

Typically, unification is performed (using binding redirects that are part of the .config file next to an .exe). This will for example say that any call to V1 should redirect to V3. All lower versions will be redirected to a single highest version. This is called "unification" of assemblies. In DataMiner, this approach is not supported at the moment. Instead, we provide all versions in their subfolders within the DllImports folder, so it can work without redirects. This does have some disadvantages like increased risk of versioning issues. This means that it is very important that you pay attention to your NuGet versions.
