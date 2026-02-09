---
uid: LogicQActionsEntryPointMethods
---

# Entry point methods

The entry method is the entry point of a QAction. DataMiner invokes the entry point method when the QAction gets triggered.

It is possible for a QAction to not define any entry point method. In that case, it should also not have a [triggers](xref:Protocol.QActions.QAction-triggers) attribute defined. A QAction without an entry point mainly serves as an assembly that defines some types used by other QActions.

By default, the Run method of the QAction class in the global namespace is used as the entry point of the QAction. The entry point method must be a public method of a public class. Both static or instance entry methods are supported, and a QAction can have multiple entry point methods, as described below.

## Static entry methods

In the example below, the Run method of the QAction class is defined as a static method.

```xml
<QAction id="100" name="Count Executions" encoding="csharp" triggers="100">
<![CDATA[
    using System;
    using Skyline.DataMiner.Scripting;

    public static class QAction
    {
        public static void Run(SLProtocol protocol)
        {
            int count = Convert.ToInt32(protocol.GetParameter(10));
            count++;
            protocol.SetParameter(10, count);

            protocol.Log("Number of times button was pressed on this element: " + count, LogType.Error, LogLevel.NoLogging);
        }
    }
]]>
</QAction>
```

## Instance entry methods

To use instance entry methods in QActions, define the entry method as an instance method, by removing the `static` keyword of the `Run` method.<!-- RN 5481 --> If your QAction class has the `static` keyword, it should also be removed.

When instance entry methods are used, DataMiner will create one instance per element of the class that defines the entry point method: When a QAction is triggered, DataMiner will first verify whether the entry method is an instance method. If this is the case, it will verify whether an instance of the class that defines the entry method (typically this is the QAction class) has already been created for this element. If no instance has been created yet for this element, an instance will be created. Otherwise, the existing instance will be reused. If the entry point is a static method, no instance is required and DataMiner just invokes the static method.

The instance persists as long as the SLScripting process is running and the element is not removed, stopped, or restarted.

The following example will count the number of times the button has been used for this element (note that the value will be set to 0 again if the element is stopped or restarted, or if the SLScripting process is restarted):

```xml
<QAction id="100" name="Count Executions" encoding="csharp" triggers="100">
<![CDATA[
    using Skyline.DataMiner.Scripting;

    public class QAction
    {
        private int executionCount = 0;

        public void Run(SLProtocol protocol)
        {
            executionCount++;
        }
    }
]]>
</QAction>
```

## Multiple entry methods

The Run method of the QAction class is the default entry point method of a QAction. Using the [entryPoint](xref:Protocol.QActions.QAction-entryPoint) attribute, a different entry point method can be defined for every parameter that triggers the QAction.

For example, in the following QAction, two parameters can trigger a QAction. Depending on which parameter triggered the QAction execution, another entry point method is selected.

- If parameter 200 triggers the execution of the QAction, the entry point method will be `Initialize`.
- If parameter 201 triggers the execution of the QAction, the entry point method will be `ProcessMessages`.

```xml
<QAction id="200" name="Subscriptions" encoding="csharp" triggers="200;201" entryPoint="Initialize;ProcessMessages" dllImport="[ProtocolName].[ProtocolVersion].QAction.0.dll">
```

By default, the entry method is expected to be defined in the QAction class. However, it is possible to refer to a method of another class as an entry point method. Refer to [entryPoint](xref:Protocol.QActions.QAction-entryPoint) for more information.

## Entry point method arguments

### SLProtocol(Ext) instance

The entry point method of a QAction can be defined with an argument of type [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) or [SLProtocolExt](xref:Skyline.DataMiner.Scripting.SLProtocolExt).

When DataMiner is about to execute a QAction, a new instance of SLProtocol or SLProtocolExt is created and passed as an argument to the entry point method (if the entry point method defines an argument of type SLProtocol or SLProtocolExt). This new instance contains the following information:

- Trigger parameter ([GetTriggerParameter](xref:Skyline.DataMiner.Scripting.SLProtocol.GetTriggerParameter))
- Element ([ElementID](xref:Skyline.DataMiner.Scripting.SLProtocol.ElementID) and [DataMinerID](xref:Skyline.DataMiner.Scripting.SLProtocol.DataMinerID))
- Element name ([ElementName](xref:Skyline.DataMiner.Scripting.SLProtocol.ElementName))
- Protocol name and version ([ProtocolName](xref:Skyline.DataMiner.Scripting.SLProtocol.ProtocolName), [ProtocolVersion](xref:Skyline.DataMiner.Scripting.SLProtocol.ProtocolVersion), and [ElementProtocolVersion](xref:Skyline.DataMiner.Scripting.SLProtocol.ElementProtocolVersion))
- User ([UserInfo](xref:Skyline.DataMiner.Scripting.SLProtocol.UserInfo) and [UserCookie](xref:Skyline.DataMiner.Scripting.SLProtocol.UserCookie))
- Database type ([GetLocalDatabaseType](xref:Skyline.DataMiner.Scripting.SLProtocol.GetLocalDatabaseType))
- Any additional values that should be passed along as input arguments to the QAction entry point method (see [Via inputParameters Attribute](xref:LogicQActionsSLProtocolInteraction#via-inputparameters-attribute))

If the QAction is triggered on a row, additional information is passed along:

- The IDX ([RowIndex](xref:Skyline.DataMiner.Scripting.SLProtocol.RowIndex))
- The primary key ([RowKey](xref:Skyline.DataMiner.Scripting.SLProtocol.RowKey))
- Old row data ([OldRow](xref:Skyline.DataMiner.Scripting.SLProtocol.OldRow))
- New row data ([NewRow](xref:Skyline.DataMiner.Scripting.SLProtocol.NewRow))
- Ping RTT ([RowRTT](xref:Skyline.DataMiner.Scripting.SLProtocol.RowRTT))
- Timestamp ([RowPingTimestamp](xref:Skyline.DataMiner.Scripting.SLProtocol.RowPingTimestamp))

> [!NOTE]
> The SLProtocolExt interface extends the SLProtocol interface with additional members that can improve code readability. However, if you do not make use of the additional functionality provided by SLProtocolExt, we recommend defining the entry point method with an argument of type SLProtocol instead of SLProtocolExt.
