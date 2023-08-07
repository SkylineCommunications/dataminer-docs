---
uid: Run_Time_Assembly_Binding
---

# Run-time assembly binding

> [!IMPORTANT]
> In scenarios where all of the following is applicable:
>
> - You installed a NuGet package "A" that has a dependency on another NuGet package "B".
> - You also installed NuGet package "B".
> - NuGet package "A" exposes types from NuGet package "B".
> - You use types from package "B" through package "A" (e.g. calling a method defined in package "A" that has as argument a type from package "B", or using a method from package "A" that returns a type of package "B").
>
> Make sure that the version of package "B" you installed is the same version as the version of package "B" that package "A" depends on. Otherwise you could experience run-time issues as explained in more detail below.

This happens when code reaches a method that is present in a different DLL.

At run-time, assemblies are loaded the moment they are needed in the code. When the Just-In-Time (JIT) compiler compiles the intermediate language (IL) to native code, it sees which types are referenced. The JIT compiler will then determine the assemblies that define these types, and these will be loaded.

This means that at that point it will look for any dependencies. To find those assemblies, it will look through all the "hintpaths", which are directories that could contain those DLLs.

For DataMiner, because protocol.xml and script.xml are compiled in DataMiner itself, we add all the possible places such dependency DLLs may be present using the [Param type="ref"](xref:DMSScript.Script.Exe.Param-type) tags in scripts or [dllImport](xref:Protocol.QActions.QAction-dllImport) attributes in QActions.

To better understand this, imagine the following example: You have a custom solution using the Class Library, and you are using that custom solution in an Automation script. When the script is compiled, it will try to find the Class Library DLLs when it encounters a Class Library method. This means that if those DLLs are not present, it will only throw an exception at run-time. It may also throw exceptions if the DLLs with the right version are not present. For example, if V1 is needed, but V3 is present, it can throw an exception.

Typically, unification is performed (using [BindingRedirect](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/bindingredirect-element) elements in the [configuration file](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/)). A binding redirect could then for example state that assembly V1 should be redirected to V3. This is called "unification" of assemblies. In DataMiner, this approach is currently not supported as by default all QActions run in the same SLScripting process in a single AppDomain. Instead, all versions of the required DLLs are provided in their subfolders within the DllImports folder. As no unification is performed, this could lead to versioning issues (see also [Best Practices for Assembly Loading](https://learn.microsoft.com/en-us/dotnet/framework/deployment/best-practices-for-assembly-loading#avoid_loading_multiple_versions)).

## Example

Suppose you are creating an API to be used in a connector (releasing your API as a NuGet package), and that the API uses the class library NuGet package version 1.3.0.1.

Let us assume that the API defines the following method in a public class named *Example*:

```csharp
public void Install(IDms dms);
```

Now the *Install* method has an argument of type *IDms*, which is defined in the class library package version 1.3.0.1. In other words, the API exposes a type used from the class library v1.3.0.1.

When this API is used from a connector that uses the class library NuGet version 1.3.0.1, everything will work fine:

```csharp
IDms dms = protocol.GetDms();
Example example = new Example();
example.Install(dms);
```

However, if the class library version used in the QAction is different, this will lead to issues. Suppose the QAction in the connector references class library version 1.3.0.2:

```csharp
IDms dms = protocol.GetDms(); // An instance of IDms from 1.3.0.2 is created.
Example example = new Example();
example.Install(dms); // An instance of IDms v1.3.0.1 is expected, but v1.3.0.2 is provided.
```

This will result in a *MissingMethodException* being thrown: `System.MissingMethodException: Method not found: 'Void Example.Install(IDms)'`.

Even though the signature of the method gives the impression that this method is actually present, the exception gets thrown because the versions of the assemblies in which the types are defined are different: The *protocol.GetDms* method in the connecter constructs an *IDms* instance from assembly v1.3.0.2, while the *Install* method expects an instance of assembly v1.3.0.1 and therefore throws a *MissingMethodException*.

Another type of exception you could observe when mixing different versions is an *InvalidCastException*. The element log would then contain a message as follows:

```txt
System.InvalidCastException: [A]<namespace>.<type> cannot be cast to [B]<namespace>.<type>. Type A originates from '<assemblyName>, Version=<assemblyVersion>, Culture=neutral, PublicKeyToken=null' in the context 'LoadNeither' in a byte array. Type B originates from '<assemblyName>, Version=<assemblyVersion>, Culture=neutral, PublicKeyToken=null' in the context 'LoadNeither' in a byte array.
   at QAction.Run(SLProtocol protocol)
```

It is important to be aware of this when developing e.g. APIs, as otherwise the exceptions above could occur at run-time.
