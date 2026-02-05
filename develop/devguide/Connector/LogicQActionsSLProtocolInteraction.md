---
uid: LogicQActionsSLProtocolInteraction
---

# QActions SLProtocol interaction

## Retrieving data from SLProtocol

Often, a QAction needs to retrieve parameter values from the SLProtocol process. There are two different ways to retrieve parameter values in a Quick Action:

- By including the parameter IDs in the [inputParameters](xref:Protocol.QActions.QAction-inputParameters) attribute.
- By retrieving the values via an instance of the SLProtocol or SLProtocolExt interface (e.g. by using the [GetParameter](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameter(System.Int32)) method).

Which approach should be used to retrieve data from the SLProtocol process depends on the situation:

- For tables, we advise you to use inputParameters when you will need the entire table. If inputParameters is used, the SLScripting process will convert the table to a usable object, whereas when the data is retrieved using the SLProtocol interface, the SLProtocol process is responsible for doing this conversion. This offloads some of the load from the SLProtocol process to the SLScripting process.

   See [Via inputParameters attribute](xref:LogicQActionsSLProtocolInteraction#via-inputparameters-attribute).

- In all other cases, retrieve the value via the SLProtocol(Ext) instance.

   See [Via SLProtocol(Ext) interface](xref:LogicQActionsSLProtocolInteraction#via-slprotocolext-interface).

## Via inputParameters Attribute

When the inputParameters attribute is used, the parameter values are cast to an object in the Run method of the QAction. This is done by the SLScripting process.

> [!NOTE]
> It is important to note that objects referred to via inputParameters will contain the value of the parameters at the time the QAction started.

Also keep in mind that DataMiner needs to convert the parameter to an object that can be used in the QAction. This will increase the load of the SLScripting process. The object itself is stored in memory.

A reference to the input parameters can be obtained by providing an additional parameter of type object for each input parameter defined in the inputParameters attribute.

In the example below, the values of parameters with ID 200 and 201 are passed to the QAction via the objects errors and time span respectively.

```xml
<QAction id="100" name="Process Errors" encoding="csharp" triggers="100" inputParameters="200;201">
<![CDATA[
using Skyline.DataMiner.Scripting;

public static class QAction
{
    /// <summary>
    /// Quick Action entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    /// <param name="errors">Errors that need to be processed.</param>
    /// <param name="timespan">Timespan in which the errors occurred.</param>
    public static void Run(SLProtocol protocol, object errors, object timespan)
    {
        //// ...
    }
}
]]>
</QAction>
```

Alternatively, the [GetInputParameter](xref:Skyline.DataMiner.Scripting.SLProtocol.GetInputParameter(System.Int32)) method can be used:

```xml
<QAction id="100" name="Process Errors" encoding="csharp" triggers="100" inputParameters="200;201">
<![CDATA[
using Skyline.DataMiner.Scripting;

public static class QAction
{
    /// <summary>
    /// Quick Action entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        string errors = Convert.ToString(protocol.GetInputParameter(0));
        //// ...
    }
}
]]>
</QAction>
```

## Via SLProtocol(Ext) interface

Instead of passing all the needed parameters, it is possible to retrieve the parameter values by invoking methods on the SLProtocol interface. To do this, there are multiple methods defined in the SLProtocol interface.

In the example below, the values of two standalone parameters are retrieved by parameter ID and by parameter name using the GetParameter method. This will retrieve the current value of the parameter (not the value at the time the QAction started as in the previous section).

```csharp
using System;
using Skyline.DataMiner.Scripting;

public static class QAction
{
    /// <summary>
    /// Quick Action example.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        string errors = Convert.ToString(protocol.GetParameter(10));
        int timespan = Convert.ToInt32(protocol.GetParameter(Parameter.timespan));
    }
}
```

When data is retrieved via the SLProtocol interface, the load is spread over the SLScripting and SLProtocol processes.

It is important to realize that almost every method invoked on the protocol object results in inter-process communication between the SLScripting process and the SLProtocol process, which is a costly operation. Therefore, the number of method invocations on the SLProtocol interface should always be reduced to an absolute minimum. The example above could be improved by using the GetParameters method to obtain the parameter values in one call:

```csharp
public static void Run(SLProtocol protocol)
{
   object[] parameters = (object[]) protocol.GetParameters(new uint[] { 10, 12 });

   string errors = Convert.ToString(parameters[0]);
   int timespan = Convert.ToInt32(parameters[1]);
}
```

In order to avoid so-called magic numbers, the Parameter or ProtocolExt class can be used.

For example, using the Parameter class:

```csharp
object[] parameters = (object[])protocol.GetParameters(new uint[] { Parameter.errors, Parameter.timespan });
```

or using the SLProtocolExt interface:

```csharp
string errors = Convert.ToString(protocol.Errors);
```
