---
uid: Protocol.QActions.QAction
---

# QAction element

Specifies the code that must execute when a parameter or a row has changed.

## Parent

[QActions](xref:Protocol.QActions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[dllImport](xref:Protocol.QActions.QAction-dllImport)|[TypeDllImport](xref:Protocol-TypeDllImport)||Specifies external DLL files used by the QAction.|
|[encoding](xref:Protocol.QActions.QAction-encoding)|[EnumQActionEncoding](xref:Protocol-EnumQActionEncoding)||Specifies the language in which the script has been written.|
|[entryPoint](xref:Protocol.QActions.QAction-entryPoint)|string||Defines the entry point method(s) corresponding with the parameter(s) triggering the QAction execution.|
|[id](xref:Protocol.QActions.QAction-id)|[TypeObjectId](xref:Protocol-TypeObjectId)|Yes|Specifies the unique QAction ID.|
|[include](xref:Protocol.QActions.QAction-include)|string||Specifies the name of the external script to be executed.|
|[inputParameters](xref:Protocol.QActions.QAction-inputParameters)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)||Specifies the IDs of the parameters that will be passed to functions inside the QAction script.|
|[name](xref:Protocol.QActions.QAction-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name of the QAction.|
|[options](xref:Protocol.QActions.QAction-options)|[TypeQActionOptions](xref:Protocol-TypeQActionOptions)||Allows you to specify a number of options, separated by semicolons.|
|[row](xref:Protocol.QActions.QAction-row)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If set to "true", the QAction will be executed when a row of a table has changed.|
|[triggers](xref:Protocol.QActions.QAction-triggers)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)||Specifies the IDs of the parameters that will cause the QAction to be executed each time their value changes.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Condition](xref:Protocol.QActions.QAction.Condition)|[0, 1]|Specifies a condition that must be met in order for the QAction to execute.|

## Remarks

The actual script code of a QAction must be placed inside a CDATA section. By placing code inside a CDATA section, characters like “<” and “&”, which are normally illegal when placed inside normal XML tags, will no longer be considered as such. A CDATA section starts with `<![CDATA[` and ends with `]]>`.

In order to interact with the SLProtocol process (e.g., to access parameters or to notify DataMiner of certain events)

- in Jscript or VBScript code, use the SLScript object. (Note the VBScript is [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement).)

- in C# code, use the Skyline.DataMiner.Scripting namespace.

For information on how to use C# in protocols, see <xref:LogicQActions>.

## Examples

```xml
<QAction id="1" encoding="csharp" triggers="2">
<![CDATA[
using System;
using System.IO;

using Skyline.DataMiner.Scripting;

public class Qaction
{
	public static void Run(SLProtocol protocol)
    {
		...
	}
}
]]>
</QAction>
```

```xml
<QAction id="1" encoding="jscript" triggers="500" include="http_get_post.js">
  ...
</QAction>
```

```xml
<QAction id="10000" name="D9036 Generic" triggers="109" encoding="csharp" options="dllname=D9036GenericClasses.dll" >
  ...
</QAction>
```
