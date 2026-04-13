---
uid: AssemblyResolvingAutomationScripts
---

# Assembly binding automation scripts

In an automation script, the assembly file paths mentioned in the [Param](xref:DMSScript.Script.Exe.Param) elements of type "ref" are used as follows:

- **Compilation time**: The assembly file paths are added as references to the compiler.
- **Runtime**: The folder denoted by the assembly file path is added as a hint path for the assembly resolver.

In an automation script, there is no support for providing folder paths to be added as hint paths at runtime (i.e., only file paths are supported in the [Param](xref:DMSScript.Script.Exe.Param) elements of type "ref"). Therefore, when you reference assemblies, it is important to **only reference a single version** of that assembly. Otherwise, issues might occur during script execution.

For example, suppose a script references two versions of an assembly, version 1.1.3.1 and version 1.1.3.2 (for example, because of transitive dependencies the script has on NuGet packages it uses), and the Param element specifies a reference to version 1.1.3.2 (only a reference to one version is provided as providing both would result in ambiguous references in the compiler).

When the runtime reaches the point where types of version 1.1.3.1 are needed, it will not find the path to this assembly based on the hint paths of that automation script. The assembly resolver will try to find an exact match in the list of hint paths in the resolver module. This list is built up from all assembly paths referenced in all automation scripts as these are compiled or executed. This means that which assembly will be loaded will now depend on the paths defined in other automation scripts, which is something that must be avoided.

An exact match could be found if another automation script references version 1.1.3.1. If not, the resolver will perform a fallback to an assembly with the same name but another version. If it resolves to another version, this can for instance result in MissingMethodExceptions in case the method is not present in the resolved assembly.

> [!IMPORTANT]
> When referencing a NuGet package in an automation script, either directly or through a transitive dependency, make sure the script only references a single version of that NuGet package. Also, when creating a NuGet package that will be used by an automation script, that package should only reference one version of another NuGet package.

> [!NOTE]
> Note that the behavior in connectors is different from that in automation scripts, as **in connectors it is possible to specify a folder path as hint path**. For more information, refer to [Assembly binding connectors](xref:AssemblyResolvingConnectors).
