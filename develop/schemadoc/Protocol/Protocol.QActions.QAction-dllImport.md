---
uid: Protocol.QActions.QAction-dllImport
---

# dllImport attribute

Specifies the names of DLL files used by the QAction.

## Content Type

[TypeDllImport](xref:Protocol-TypeDllImport)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

Multiple values have to be separated by semicolons (”;”).

When a DLL provided by the Microsoft .NET Framework is used (e.g. System.Xml.dll), it is sufficient to just mention it in the dllImport attribute. System DLL files must be stored in the system dll directory. All other DLL files must be stored in the C:\Skyline DataMiner\ProtocolScripts directory.

The following DLL files do not have to be specified in the dllImport attribute as these are referenced by default:

- System.dll
- System.Core.dll
- System.Xml.dll (RN 19494)
- nestandard.dll (from DataMiner 10.1.11 onwards (RN 30755))
- SLManagedScripting.dll
- SLNetTypes.dll
- Interop.SLDms.dll
- [ProtocolName].[ProtocolVersion].QAction.Helper.dll
- QActionHelperBaseClasses.dll
- Skyline.DataMiner.Storage.Types.dll (from DataMiner 10.0.6 onwards (RN 25036))
- SLLoggerUtil.dll (from DataMiner 10.0.10 onwards (RN 26434))

> [!NOTE]
>
> - When assemblies are referenced using the dllImport attribute, the C:\Skyline DataMiner\ProtocolScripts folder is searched prior to the C:\Skyline DataMiner\Files folder. This means that when both these folders contain a DLL with the specified name, the DLL in the ProtocolScripts folder will be used.
> - From DataMiner 10.1.3 (RN 28653) onwards, it is possible to reference DLLs starting with either "System." or "Microsoft." if they do not exist as default .NET assembly but do exist in the ProtocolScripts folder. Prior to DataMiner 10.1.3, the C:\Skyline DataMiner\ProtocolScripts and C:\Skyline DataMiner\Files folders are not searched, as prior to that DataMiner version, these are considered system DLLs.

From DataMiner 8.0.9 (RN 4885) onwards, the following placeholders can be used in the dllImport statement:

- [ProtocolName]: The name of the protocol
- [ProtocolVersion]: The version of the protocol

These placeholders will be resolved at compile time. Thanks to these two placeholders, not all dllImports in a protocol have to be changed when the external assembly gets updated.

In case of version 1.1.0.48 of the “Microsoft Platform” protocol, the following statement will refer to an external assembly called “Microsoft Platform_1.1.0.48.dll”:

```xml
dllImport="[ProtocolName]_[ProtocolVersion].dll"
```

From DataMiner 9.6.12 (RN 23565) onwards, it is possible to refer to DLLs that are stored in a subfolder of the ProtocolScripts folder. In that case, you must mention the subfolder when you specify the DLL in the protocol. For example, to use "test.dll" stored in `C:\Skyline DataMiner\ProtocolScripts\SubFolder`, configure the dllImport attribute of the QAction tag as follows: dllImport="SubFolder\test.dll".

If the DLL file is stored in the `C:\Skyline DataMiner\ProtocolScripts\DllImport` folder, there is no need to specify the subfolder in the protocol. From DataMiner 9.6.12 (RN 23565) onwards, DLL files stored in *C:\Skyline DataMiner\ProtocolScripts\DllImport* will take precedence over DLL files stored in *C:\Skyline DataMiner\ProtocolScripts*.

From DataMiner 9.6.12 (RN 23565) onwards, it is also possible to reference DLLs with the same name but with different assembly versions within the same driver, though not within the same QAction.

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
> - DLL files stored in `C:\Skyline DataMiner\Files\` will take precedence over DLL files in other folders if they are not strongly named (signed). This is standard Microsoft .NET assembly resolving behavior. If the files in `C:\Skyline DataMiner\Files\` do not take precedence, DLL files stored in `C:\Skyline DataMiner\ProtocolScripts\DllImport` will take precedence over DLL files in other folders.
> - In the details of a DLL, "File Version" and "Product Version" reflect the projects file version at compilation. Other tools might be needed to check the actual assembly version
