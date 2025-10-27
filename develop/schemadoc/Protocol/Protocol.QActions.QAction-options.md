---
uid: Protocol.QActions.QAction-options
---

# options attribute

Allows you to specify a number of options, separated by semicolons.<!-- RN 6457 -->

## Content Type

[TypeQActionOptions](xref:Protocol-TypeQActionOptions)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

The following options are available:

### binary

If specified, all values in "inputParameters" are forwarded to the QAction as a byte array holding the raw content of the parameter.

### debug

By default, the DataMiner compilation engine compiles with the optimization level option set to Release. When the debug option is specified, the compilation engine compiles with the optimization level option set to Debug, which disables all optimizations, and instruments the generated code to improve the debugging experience.

In addition, when this option is used, next to the DLL, a program database file (.pdb) will be generated. This way, you get more information when exceptions occur (e.g. the line number).

### dllname=name.dll

> [!IMPORTANT]
> Avoid using this option if possible. Support for this option ends in DataMiner 10.7 (see [Software support lifecycles](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)).

By default, every QAction is compiled into a DLL file at first use. This DLL file is stored in the C:\Skyline DataMiner\ProtocolScripts directory, and is assigned a name that is constructed in the following format:

`[ProtocolName].[ProtocolVersion].QAction.[QactionID].dll`

Example: Microsoft Platform.1.5.0.36.Qaction.27.dll

When you want the DLL file to include a meaningful name, enter that name in this options attribute.

This name will then replace the QAction.[QActionID] part:

```xml
<QAction id="100" name="Example" encoding="csharp" triggers="100" options="dllName=[CustomName]">
```

`[ProtocolName].[ProtocolVersion].[CustomName].dll`

> [!NOTE]
>
> - It is not required to include the .dll extension. If it is not provided as part of the custom name, DataMiner will add this extension automatically.
> - When you use the dllName option, no DLLs per process will be generated when the
> /DataMiner/ProcessOptions@scriptingProcesses attribute in the DataMiner.xml configuration file has been set to "protocol".
> - If you specify `*` or `<No Name>` (i.e. `options="dllName=<No Name>"`), no DLL file will be compiled.
> - The DLL will be refreshed when the QAction that creates this DLL is run. This means that when something changes in the QAction it does not immediately change in the (running) DLL. When the QAction is triggered, the (running) DLL is updated and run with the new data.

### group

When you specify this option, the "OldRow()" method will return the values retrieved by that group.

> [!CAUTION]
> This option can be used in case of high-volume polling. Use with care!

### precompile

<!-- RN 6457 -->

Compile the QAction immediately. Do not wait for a trigger.

Can be used when importing a QAction into another QAction.

Please note the following:

- The QActions are precompiled in the order they appear in the protocol. Therefore, when importing a precompiled QAction in another QAction (using the dllImport attribute), the QAction that is referred to must appear before the referring QAction in the protocol.

  For example, here QAction 1 must appear before QAction 2:

  ````xml
  <QAction id="1" name="Precompiled Code" encoding="csharp" options="precompile">
    ...
  </QAction>
  <QAction id="2" name="Additional Precompiled Code" encoding="csharp" options="precompile" dllImport="[ProtocolName].[ProtocolVersion].QAction.1.dll">
    ...
  </QAction>
  ```

- Compilation errors for QActions that are marked with the "precompile" option will be logged in both the element log file and the SLErrorsInProtocol.txt log file at compilation time.<!-- RN 21645 -->

### queued

The QAction will be executed on a separate thread. This implies that the QAction is triggered and set in the background.

Note that queued QActions are triggered in sequence with the other QActions, but the execution itself is performed on a separate thread. This allows for other QActions to trigger while the queued QAction is executing. It does not allow the queued QAction to start while another non-queued QAction is running.

Be careful when using this option and make sure to also implement Locking when this QAction is called more than once.

## Examples

```xml
<QAction id="1" encoding="jscript" triggers="500" include="http_get_post.js">
  ...
</QAction>
<QAction id="10000" name="D9036 Generic" triggers="109" encoding="csharp" options="dllname=D9036GenericClasses.dll" >
  ...
</QAction>
```
