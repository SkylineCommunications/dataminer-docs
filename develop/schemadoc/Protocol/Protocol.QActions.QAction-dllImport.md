---
uid: Protocol.QActions.QAction-dllImport
---

# dllImport attribute

Specifies the names of DLL files used by the QAction. Multiple values have to be separated by semicolons (`;`).

## Content Type

[TypeDllImport](xref:Protocol-TypeDllImport)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Items mentioned in the *dllImport* attribute will be added as references to the Roslyn compiler when DataMiner compiles the QAction. The items are also used to add additional hint paths to be used by the assembly resolver. For more information, refer to [Run-time assembly binding](xref:Run_Time_Assembly_Binding).

When an assembly that is part of the Base Class Library (BCL) of .NET Framework is used (e.g. System.Xml.dll), it is sufficient to just mention it in the *dllImport* attribute. Assemblies that are part of the BCL must **not** be included in the protocol package.

Other assemblies that are used by the protocol must be stored in the `C:\Skyline DataMiner\ProtocolScripts\DllImport` (or `C:\Skyline DataMiner\ProtocolScripts\`) directory.

> [!NOTE]
> Assemblies that are located in the `C:\Skyline DataMiner\ProtocolScripts\DllImport` directory are synchronized across Agents in the cluster. .dmprotocol packages will automatically put assemblies included in the package in this folder.

The following assemblies do not have to be specified in the *dllImport* attribute, as these are referenced by default:

- System.dll
- System.Core.dll
- System.Xml.dll<!-- RN 19494 -->
- nestandard.dll<!-- RN 30755 -->
- SLManagedScripting.dll
- SLNetTypes.dll
- Interop.SLDms.dll
- [ProtocolName].[ProtocolVersion].QAction.Helper.dll
- QActionHelperBaseClasses.dll
- Skyline.DataMiner.Storage.Types.dll<!-- RN 25036 -->
- SLLoggerUtil.dll<!-- RN 26434 -->

> [!NOTE]
>
> - In legacy DataMiner versions prior to DataMiner 10.1.3, it is not possible to reference assemblies starting with either "System." or "Microsoft." that are not part of the .NET Framework BCL, even if they do exist in the `ProtocolScripts\DllImport` or `ProtocolScripts` folder.<!-- RN 28653 -->

The following placeholders can be used in the *dllImport* statement:<!-- RN 4885 -->

- [ProtocolName]: The name of the protocol
- [ProtocolVersion]: The version of the protocol

These placeholders will be resolved at compile time. Thanks to these two placeholders, not all *dllImport* values in a protocol have to be updated when the external assembly gets updated.

In case of version 1.1.0.48 of the "Microsoft Platform" protocol, the following statement will refer to an external assembly called "Microsoft Platform.1.1.0.48.QAction.1.dll":

```xml
dllImport="[ProtocolName].[ProtocolVersion].QAction.1.dll"
```

To refer to DLLs that are stored in a subfolder of the `ProtocolScripts\DllImport` or `ProtocolScripts` folder, you must mention the subfolder when you specify the DLL in the protocol. For example, to use "test.dll" stored in `C:\Skyline DataMiner\ProtocolScripts\DllImport\SubFolder`, configure the `dllImport` attribute of the QAction tag as follows: `dllImport="SubFolder\test.dll`.<!-- RN 23565 -->

If the DLL file is stored in the `C:\Skyline DataMiner\ProtocolScripts\DllImport` folder, there is no need to specify the subfolder in the protocol. DLL files stored in `C:\Skyline DataMiner\ProtocolScripts\DllImport` will take precedence over DLL files stored in `C:\Skyline DataMiner\ProtocolScripts`.<!-- RN 23565 -->

It is also possible to reference DLLs with the same name but with different assembly versions within the same connector; however, not within the same QAction.<!-- RN 23565 -->

For example, the following QAction definitions are possible within a single protocol:

```xml
<QActions>
  <QAction id=100 dllImport="test.dll"></QAction>
  <QAction id=200 dllImport="MyCustomDlls\v2\test.dll"></QAction>
  <QAction id=300 dllImport="MyCustomDlls\v3\test.dll"></QAction>
</QActions>
```

> [!NOTE]
>
> - A leading slash before the folder name is supported, but not required.
> - A folder separator can be a forward slash or backslash.
> - For more information regarding assembly resolving in DataMiner, refer to [Run-time assembly binding](xref:Run_Time_Assembly_Binding).
> - In the details of a DLL, "File Version" and "Product Version" reflect the projects file version at compilation. These are not used by the assembly resolver to resolve an assembly. The assembly resolver uses the assembly version. To see the assembly version of an assembly, other tools might be used such as [dotPeek](xref:dotPeek).
