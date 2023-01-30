---
uid: ClassLibraryMonitorsGettingStarted
---

# Getting started

> [!NOTE]
> An example protocol "SLC SDF Monitors" is available in the Protocol Development Guide Companion Files.

The monitor methods are extension methods on the current DMS classes framework provided with the class library.

To access these extension methods you need the following two namespaces:

- `using Skyline.DataMiner.Core.DataMinerSystem.Common.Subscription.Monitors;`
- `using Skyline.DataMiner.Core.DataMinerSystem.Protocol.Subscription.Monitors;`

This will provide access to Start and Stop methods to manipulate the monitors on parameters, elements and DMS objects.

A StartMonitor method requires:

- The SLProtocol object, which it uses to identify your local element and mark this as the MonitorSource.
- An Action that contains the logic that has to happen every time the chosen change is detected.

  > [!IMPORTANT]
  > SLProtocol should not be used in this logic.

- The primary key of the row, in case of table manipulation (optional).

A StopMonitor method requires:

- The SLProtocol object, which it uses to identify your local element and filter this on the MonitorSource.

The action you provide to the StartMonitor can be written as:

- A lambda expression. For example:

    ```csharp
    element.StartAlarmLevelMonitor( 
    protocol,
    (change) =>
    {
        var dms = change.Dms;
        var myElement = dms.GetElement(new DmsElementId(change.MonitorSource));
        var detectedElementAlarmParam = myElement.GetStandaloneParameter<string>(303);
        detectedElementAlarmParam.SetValue(change.Alarm.ToString());
    });
    ```

- A separate method with the correct method parameters. For example:

    ```csharp
    thisDms.StartElementStateMonitor(protocol, OnStateChange);
    
     public static void OnStateChange(ElementStateChange change)
    {
        var dms = change.Dms;
        var localElement = dms.GetElement(new DmsElementId(change.MonitorSource));
        var tableToSet = localElement.GetTable(1000);
        var columnToSet = tableToSet.GetColumn<string>(1003);
    
        columnToSet.SetValue(change.DataSource.ToString(), change.State.ToString());
    }
    ```

Depending on what you are monitoring, you will be provided with a different “OnXChange” object that encapsulates the important data received from an event.

Note that it also contains an instance of the Dms class that should be used for all sets and gets in this logic. It is important to realize that the code you are writing in the action is running on the SLNet Process and not the SLScripting process. You should therefore treat it as running outside of your protocol and possibly in parallel with other code.

Always use methods and calls that work for inter-element communication. Never use SLProtocol and try to avoid manipulating collections that are not part of the action.

A common strategy inside an action can be to perform an external parameter set using the DMS classes on the MonitorSource element. Then you can trigger a new QAction on that change. At that point you will have access to SLProtocol and can treat it as any other piece of QAction logic.
