---
uid: Protocol.QActions.QAction-entryPoint
---

# entryPoint attribute

Defines the entry point method(s) corresponding with the parameter(s) triggering the QAction execution.

## Content Type

string

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

This attribute contains the name(s) of the entry point methods. In case multiple entry points are defined, these are separated by a semicolon (“;”). The number and order of the entry point methods must correspond with the parameter IDs defined in the triggers attribute.

Prior to DataMiner 10.2.9, only one instance was retained per QAction. The entry point methods therefore all had to be part of the same class. From DataMiner 10.2.9 onwards (RN 33965), this is no longer a requirement: entry point methods are allowed to be part of different classes.

## Examples

```xml
<QAction id="2" triggers="21;22" entryPoint="Method1;Method2" encoding="csharp">
<![CDATA[
using System.IO;
using System;
using System.Text;

using Skyline.DataMiner.Scripting;

public class QAction
{
	int _instanceVariable = 0;
	
	public void Method1(SLProtocolExt protocol)
	{
		protocol.Qaction2Result = "Executed Methodl: " + _instanceVariable;
		instanceVariable++;
	}

	public void Method2(SLProtocolExt protocol)
	{
		protocol.Qaction2Result = "Executed Method2: " + _instanceVariable;
		instanceVariable++;
	}
}
]]>
</QAction>
```

By default, the Run method of the QAction class in the global namespace is used as the entry point of the QAction. The entryPoint attribute allows you to specify another method to be used as the entry point.

The expected format is as follows: [ClassName.]MethodName, where ClassName is optional and defaults to "QAction". Note that the specified class must be a class defined in the global namespace.

The following example defines the Timeout method of the IfTable class to be used as the entry point:

```xml
<QAction id="990" name="If Table" encoding="csharp" triggers="990" entryPoint="IfTable.Timeout " dllImport="[ProtocolName].[ProtocolVersion].QAction.1.dll ">
```
