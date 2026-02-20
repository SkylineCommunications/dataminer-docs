---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.1
---

# Skyline DataMiner Core DataMinerSystem Range 1.1

> [!NOTE]
> Range 1.1.x.x is supported as from **DataMiner 10.1.11**. It makes use of a change introduced in DataMiner 10.1.11 that makes it possible to obtain table cell data using the primary key. In earlier DataMiner versions, the display key was needed to obtain this data.

### 1.1.3.8

#### Enhancement - Improved scaling for parameter and table cell monitors [ID 41602]

When used with **DataMiner 10.5.0/10.5.1** or higher, parameter, table cell, and table column monitors now have enhanced scaling, allowing **more monitors to be active simultaneously**.

> [!IMPORTANT]
> This enhancement is only available when the library is used with DataMiner 10.5.0/10.5.1 or higher.<!-- RN 41256 -->

#### New feature - New table column monitor added [ID 44034]

A new table column monitor has been added.

> [!IMPORTANT]
> This new monitor can only be used from DataMiner 10.5.0/10.5.1 onwards.<!-- RN 41256 -->

Example usage:

```csharp
IDmsElement element = dms.GetElement("MyElement");

const int InterfaceTableId = 100;
const int OperationalStatusId = 102;

var table = element.GetTable(InterfaceTableId);
var column = table.GetColumn<int>(OperationalStatusId);

void OnChange(ColumnValueChange<int> change)
{
    foreach (KeyValuePair<string, int> cellUpdate in change.ColumnUpdates)
    {
        Log($"Interface {cellUpdate.Key} went {(cellUpdate.Value == 1 ? "up" : "down")}.");
    }
}

column.StartValueMonitor(protocol, OnChange);
```

#### New feature - Service alarm level and state monitors usable outside of protocols

Service monitors can now be used **outside of protocol contexts** (e.g., in Automation scripts or other external integrations), allowing you to subscribe to changes without relying on *SLProtocol*.

> [!IMPORTANT]
> These monitors create **stateful SLNet subscriptions** in the background. Subscriptions **must be explicitly stopped** using the corresponding *StopMonitor* methods. Failing to do so may result in **hanging subscriptions** that persist in the system and continue to consume resources.

Example usage:

```csharp
IDmsService service = dms.GetService("MyService");

var sourceId = Guid.NewGuid().ToString();

void OnChange(ServiceAlarmLevelChange change)
{
    Log($"Service {service.Name} switched to state {change.State}.");
}

service.StartAlarmLevelMonitor(sourceId, OnChange);

try
{
    // ... other logic while the monitor is running ...
}
finally
{
    // Important: stop it when you are done.
    service.StopAlarmLevelMonitor(sourceId);
}
```

### 1.1.3.7

#### New feature - Improved API for Scheduler [ID 44556]

The Scheduler component now supports task and action configuration via builders. The `IDmsScheduler` interface includes `CreateTaskBuilder` methods to configure tasks, while `DmsSchedulerActionBuilders` provides builders for Automation scripts, Email, SMS, and Information actions.

The `CreateTask` and `UpdateTask` methods have been extended to support `IDmsSchedulerTask` objects, providing a strongly-typed alternative to the manual `object[]` construction.

Example usage:

```csharp
var scheduler = dma.Scheduler;
var action = DmsSchedulerActionBuilders.CreateScriptAction()
    .WithScriptName("MyScript")
    .Build();

var task = scheduler.CreateTaskBuilder()
    .WithTaskName("Weekly Backup")
    .WithStartTime(DateTime.Now.AddDays(1))
    .WithEndTime(DateTime.Now.AddYears(1))
    .WithRepetitionType(DmsSchedulerRepetitionType.Daily)
    .AddAction(action)
    .Build();

int taskId = scheduler.CreateTask(task);
```

#### Enhancement - Performance of GetElements and GetServices methods improved [ID 44525]

The performance of the `GetElements` and `GetServices` methods in the `Dma` class has been improved. The underlying `GetInfoMessage` now uses `LocalElementInfo` and `LocalServiceInfo` instead of `ElementInfo` and `ServiceInfo`.

### 1.1.3.6

#### New feature - SkipCertificateVerification property added to IHttpConnection [ID 44066]

The IHttpConnection interface has been extended with a SkipCertificateVerification property. This enables configuration of whether SSL/TLS certificate verification should be skipped when setting up or modifying an element's HTTP connection. This corresponds to the *Skip SSL/TLS certificate verification* checkbox in Cube.

> [!IMPORTANT]
> This property is only effective if DataMiner 10.4.12/10.5.0 or higher is used, as the underlying support is introduced in those versions. With earlier versions, setting this property will have no effect.

This example shows how to create an HTTP element with the SkipCertificateVerification option enabled:

```csharp
IDms dms = protocol.GetDms();
IDmsProtocol elementProtocol = dms.GetProtocol("MyHttpProtocol", "1.0.0.1");
ITcp port = new Tcp("127.0.0.1", 443);
IHttpConnection myHttpConnection  = new HttpConnection(port) { SkipCertificateVerification = true };

var configuration = new ElementConfiguration(
                  dms,
                  elementName,
                  elementProtocol,
                  new List<IElementConnection> { myHttpConnection });

IDma agent = dms.GetAgent(protocol.DataMinerID);
var createdElement = agent.CreateElement(configuration);
```

### 1.1.3.5

#### Fix - AgentId property of DmsAutomationScriptRunOptions ignored when executing a script [ID 43923]

When an Automation script was executed via DmsAutomationScript, the AgentId specified in DmsAutomationScriptRunOptions was not applied when constructing the SLNet message, causing the script to run on the default/incorrect Agent. This has been corrected so that the specified AgentId is now respected.

### 1.1.3.4

#### New feature - Added TryParse methods to DmsElementId and DmsServiceId structs [ID 43535]

The DmsElementId and DmsServiceId structures have been extended with a TryParse method.

Example usage:

```csharp
string dmaEidString = "208/13";
bool result = DmsElementId.TryParse(dmaEidString, out var dmaEid);
```

#### Fix - Fixed implementation of IsVersionHigher method of IDma interface [ID 43446]

The implementation of the IsVersionHigher (IDma) method has been corrected so that it now correctly compares the version of the Agent with the specified version.

This method verifies if the provided version number is higher than the DataMiner Agent version. Note that this method only supports the formats "V.W.X.Y" or "V.W.X.Y-CUZ" where V, W, X, Y, and Z are numbers. The CU is ignored in the comparison. The method returns **true** if the specified version number is higher than the version of this DataMiner Agent; otherwise, **false** is returned.

Example usage:

```csharp
string version = "10.0.3.0-CU0";

var agent = dms.GetAgent();
var isHigher = agent.IsVersionHigher(version);
```

### 1.1.3.3

> [!IMPORTANT]
> In this version, **new monitors** have been added to support **usage outside of protocols** (e.g. in Automation scripts or ad hoc data sources). These allow external code to subscribe to state, name, or alarm level changes without relying on SLProtocol. However, subscriptions created using these monitors **must be explicitly stopped** using the corresponding *StopMonitor* methods. Failing to do so may result in **hanging subscriptions** that persist in the system. Only monitors on *IDms*, *IDmsElement*, *IDmsTable*, and **IDmsStandaloneParameter** are supported for now. If you need monitor support elsewhere, please contact <support.boost@skyline.be> to request it.

#### New feature - Added monitor methods to standalone parameter interfaces

The `IDmsStandaloneParameter` and `IDmsStandaloneParameter<T>` interfaces have been extended with the following methods to allow the monitoring of value changes:

- `IDmsStandaloneParameter` interface:
  - `void StopValueMonitor(string sourceId, bool force = false)`
  - `void StopValueMonitor(string sourceId, TimeSpan subscribeTimeout, bool force = false)`
- `IDmsStandaloneParameter<T>` interface:
  - `void StartValueMonitor(string sourceId, Action<ParamValueChange<T>> onChange)`
  - `void StartValueMonitor(string sourceId, Action<ParamValueChange<T>> onChange, TimeSpan subscribeTimeout)`

### 1.1.3.2

> [!IMPORTANT]
> In this version, **new monitors** have been added to support **usage outside of protocols** (e.g. in Automation scripts or ad hoc data sources). These allow external code to subscribe to state, name, or alarm level changes without relying on SLProtocol. However, subscriptions created using these monitors **must be explicitly stopped** using the corresponding *StopMonitor* methods. Failing to do so may result in **hanging subscriptions** that persist in the system. Only monitors on *IDms*, *IDmsElement*, and *IDmsTable* are supported for now. If you need monitor support elsewhere, please reach out to request it.

#### New feature - Monitor support for non-protocol use cases

The *IDms*, *IDmsElement*, and *IDmsTable* interfaces have been extended with new `Start*Monitor` and `Stop*Monitor` methods, enabling stateful event subscriptions **outside of protocols** (e.g. in ad hoc data sources or external integrations). These are alternative APIs for monitoring DataMiner behavior in custom contexts without direct use of SLProtocol. This extension provides flexible, lightweight monitoring capabilities for many integration scenarios outside the traditional protocol-based flow.

The following types of monitors are supported:

- On *IDmsElement*:

  - `StartAlarmLevelMonitor` / `StopAlarmLevelMonitor`
  - `StartNameMonitor` / `StopNameMonitor`
  - `StartStateMonitor` / `StopStateMonitor`

- On *IDms*:

  - `StartElementAlarmLevelMonitor` / `StopElementAlarmLevelMonitor`
  - `StartElementNameMonitor` / `StopElementNameMonitor`
  - `StartElementStateMonitor` / `StopElementStateMonitor`
  - `StartServiceStateMonitor` / `StopServiceStateMonitor`
  - `StartViewStateMonitor` / `StopViewStateMonitor`

- On *IDmsTable*:

  - `StartValueMonitor` / `StopValueMonitor`: Supports monitoring all or filtered columns using the primary key index.

Each monitor requires a *sourceId* to uniquely identify the subscription and a callback delegate (e.g. `Action<ElementStateChange>`). Subscriptions can be initiated using either a default timeout or a user-defined *TimeSpan*.

For example, to monitor an element's alarm level and state:

```csharp
string sourceId = Guid.NewGuid().ToString();

element.StartAlarmLevelMonitor(sourceId, change =>
{
    Log($"{change.NewLevel} alarm raised on element {change.ElementId}");
});

element.StartStateMonitor(sourceId, change =>
{
    Log($"Element {change.ElementId} changed state to {change.NewState}");
});
```

When your use case is complete or the script is exiting, you must **explicitly stop the subscriptions**:

```csharp
element.StopAlarmLevelMonitor(sourceId);
element.StopStateMonitor(sourceId);
```

If needed, you can use overloads to specify a timeout and to specify whether to forcefully remove the subscription:

```csharp
element.StopAlarmLevelMonitor(sourceId, TimeSpan.FromSeconds(10), force: true);
```

**Filtering table columns** is supported using the following overload on *IDmsTable*:

```csharp
table.StartValueMonitor(sourceId, pkIndex, new[] { 1001, 1003 }, change =>
{
    Log($"Row {change.PrimaryKey} changed.");
});
```

### 1.1.3.1

#### New feature - API added for retrieving element and service count on each Agent [ID 41795]

The IDms interface has been extended with the following method: `DmsInfo GetDmsInfo()`, which will return information about the DataMiner Agents. It returns a *DmsInfo* object, which has an *Agents* member. This member is a list of *DmaInfo* objects. Each *DmaInfo* object gives an overview of the Agent ID, the number of elements hosted on that Agent, and the number of services hosted by that Agent.

Example usage:

```csharp
IDms dms = protocol.GetDms();

DmsInfo dmsConfig = dms.GetDmsInfo();
IEnumerable<DmaInfo> dmaConfigs = dmsConfig.Agents;

foreach (var dmaConfig in dmaConfigs)
{
    int elementCount = dmaConfig.ElementCount;
    int serviceCount = dmaConfig.ServiceCount;
}
```

#### New feature - Support added for configuring and retrieving SlowPoll, SlowPollBase, and PingInterval settings [ID 41797]

The class library now includes support for retrieving and configuring the slow poll settings of an element.

When an element is created, the slow poll settings can be configured under the advanced settings. Two types of configuration are supported: *DurationBasedSlowPollSettings* and *TimeoutCountBasedSlowPollSettings*. If slow polling is not configured, the property value is null.

This example shows how to create an element with duration-based slow poll settings:

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(protocol.DataMinerID);
IDmsProtocol protocol = dms.GetProtocol(
   Settings.HttpConnectionTestProtocolName,
   Settings.HttpConnectionTestProtocolVersion);

ITcp port = new Tcp("127.0.0.1", 80);
IHttpConnection myHttpConnection = new HttpConnection(port);

var configuration = new ElementConfiguration(
                  dms,
                  elementName,
                  protocol,
                  new List<IElementConnection> { myHttpConnection })
{
   Description = "my test element",
   State = ConfigurationElementState.Active
};

configuration.AdvancedSettings.Timeout = new TimeSpan(0, 0, 0, 30);
configuration.AdvancedSettings.SlowPollSettings = new DurationBasedSlowPollSettings(TimeSpan.FromSeconds(12), TimeSpan.FromSeconds(22));
DmsElementId id = agent.CreateElement(configuration);
```

Creating an element with timeout count-based slow poll settings is similar but instead an instance of *TimeoutCountBasedSlowPollSettings* should be provided for the *SlowPollSettings* property:

```csharp
configuration.AdvancedSettings.SlowPollSettings = new TimeoutCountBasedSlowPollSettings(TimeSpan.FromSeconds(12), 18);
```

To retrieve the slow poll configuration of an existing element, access the *SlowPollSettings* under the *AdvancedSettings*. The value is either null (no slow polling configured) or an instance of *DurationBasedSlowPollSettings* or *TimeoutCountBasedSlowPollSettings*.

```csharp
slowPollSetings  = element.AdvancedSettings.SlowPollSettings;
if(slowPollSetings != null)
{
  if(slowPollSettings is TimeoutCountBasedSlowPollSettings)
  {
      // ...
  }else if(slowPollSettings is DurationBasedSlowPollSettings)
  {
     // ...
  }
}
```

To update the slow poll settings, create an instance of either *TimeoutCountBasedSlowPollSettings* or *DurationBasedSlowPollSettings*, assign it to the *SlowPollSettings* of the element, and then call the *Update* method on the element.

#### Enhancement - Element creation with empty user name prevented for elements with SNMPv3 connection and support added for using credential library with SNMPv3 connections [ID 41805]

Up to now, it was possible to create an instance of the *SnmpV3SecurityConfig* class with an empty string as user name, or a user name that only consisted of whitespace characters (e.g. spaces, tabs, newlines, etc.). As these are not valid SNMPv3 user names, there is now a check in place to verify that the user name is not one of those options. When this check fails, an *ArgumentException* is thrown, and the creation of the *SnmpV3SecurityConfig* object fails.

This means that the following restrictions now apply for the user name:

- `username != null` (this check was already in place; an *ArgumentNullException* is thrown on failure)
- `username != ""` (new; an *ArgumentException* is thrown on failure)
- The user name string does not only contain whitespace characters (an *ArgumentException* is thrown on failure).

In addition, support has been added to use the credential library with SNMPv3 connections.

#### Fix - Exception when changing state of an element fails [ID 41807]

Up to now, when the *DmsElement.Delete()* method was executed and something went wrong, no exception was thrown (and no logging was generated for this). Moreover, further actions on that element object would throw an *ElementNotFoundException*, which was incorrect because the element still existed.

Similar issues could occur when *DmsElement.Start()*, *DmsElement.Stop()*, *DmsElement.Restart()*, or *DmsElement.Pause()* was executed.

From now on, the *SetElementStateResponseMessage* will be processed, and a *DMSException* will be thrown when:

- No response is returned from the DMS (the returned *SetElementStateMessage* is null).
- The contents of the *SetElementStateMessage* indicates that something went wrong while performing the state change (`SetElementStateResponseMessage.HasSucceeded == false`).

This check is performed when *DmsElement.Delete()*, *DmsElement.Start()*, *DmsElement.Stop()*, *DmsElement.Restart()*, or *DmsElement.Pause()* is called.

#### Fix - Refactored logging for duplicate property detection [ID 42292]

To improve logging efficiency, the duplicate property detection logic has been refactored. It is now executed once at the start of the *Parse* methods in *DmsElement*, *DmsService*, and *DmsView* classes, preventing unnecessary checks within loops. This reduces redundant processing and redundant logging, improving overall performance.

#### New feature - FunctionSettings property added to IDmsElement [ID 42841]

The *IDmsElement* interface now has an additional *FunctionSettings* property, which has the following two properties:

- *IsFunctionElement (bool)*: When true is returned, this indicates that the element is linked to a function resource.
- *FunctionId*: The GUID of the linked function resource. If there is no linked function resource, *Guid.Empty* is returned.

### 1.1.2.2

#### Fix - Cached property definitions cleared when PropertyExists is called [ID 41610]

The property definitions are cached in the class library. However, when a server call is made to retrieve the properties again (through the PropertyExists method), the cached values should be cleared and repopulated. Until now, the cached values were not cleared, leading to the possible situation where a property that was deleted in DataMiner would still be present in the cache of the class library.

### 1.1.2.1

#### API changes for improved performance [ID 41178]

Version 1.1.2.1 introduces changes (some of which are breaking) to the class library API to reduce the number of SLNet calls that are executed in the background.

##### Extended IDms interface

The IDms interface has been extended with additional methods for retrieving an object that represents an existing DataMiner object (without checking whether it actually exists):

- IDma GetAgentReference(int agentId)
- IDmsElement GetElementReference(DmsElementId dmsElementId)
- IDmsView GetViewReference(int viewId)

These methods can be used as an alternative to the *IDms.GetElement(DmsElementId)*, *IDms.GetView(int)*, and *IDms.GetAgent(int)* methods. The *IDms.GetElement(DmsElementId)*, *IDms.GetView(int)*, and *IDms.GetAgent(int)* methods will perform an SLNet call in the background to request info about the item. With the new *GetAgentReference*, *GetElementReference*, and *GetViewReference* methods, this additional SLNet call will only be called when information is requested. Therefore if you perform a set, e.g. a parameter set on an element, the *SetParameterMessage* SLNet call is performed in the background without having to request additional data from SLNet.

However, note that if you request a reference to an object that does not exist in the system by providing an invalid ID, an exception will only be thrown when a call to the server is performed. If the *IDms.GetElement(DmsElementId)*, *IDms.GetView(int)* or *IDms.GetAgent(int)* method is used, an exception will already be thrown if the Agent does not exist when the method is executed.

In summary, you can use these methods if you are sure the item exists, and these can result in improved performance because some additional SLNet calls can be avoided. If you do not know whether the item exists, you should use the *IDms.GetElement(DmsElementId)*, *IDms.GetView(int)*, or *IDms.GetAgent(int)* method instead.

Behavior prior to this change:

```csharp
var dms = protocol.GetDms();
var element = dms.GetElement(new DmsElementId(346, 100)); // Performs an SLNet call to obtain info about the element.
var parameter = element.GetStandaloneParameter<double?>(10);
parameter.SetValue(100); // Throws ElementStoppedException in case the State property of the ElementInfoEvent message obtained in the GetElement call indicates the element is stopped. In this case no server call is executed.
```

Behavior since this change:

```csharp
var dms = protocol.GetDms();
var element = dms.GetElement(new DmsElementId(346, 100)); // Performs an SLNet call to obtain info about the element.
var parameter = element.GetStandaloneParameter<double?>(10);
parameter.SetValue(100); // Does not check State property of the ElementInfoEvent message obtained in the GetElement call indicates the element is stopped. Server call is executed.
```

Alternative to avoid additional SLNet call:

```csharp
var dms = protocol.GetDms();
var element = dms.GetElementReference(new DmsElementId(346, 100)); // No SLNet call executed.
var parameter = element.GetStandaloneParameter<double?>(10);
parameter.SetValue(100); // Does not check State property of the ElementInfoEvent message obtained in the GetElement call indicates the element is stopped. Server call is executed.
```

##### Breaking changes

Some breaking changes have been introduced in the API with regard to exceptions that are thrown because the *State* property for an element is no longer checked before a set is executed. This means that some calls no longer throw an ElementStoppedException but instead an ElementNotFoundException or no exception at all.

To see if and when an exception is thrown, refer to the documentation on the methods in the API section (e.g. [GetElement](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma.GetElement*)).

- IDmsElement.GetStandaloneParameter\<T\> no longer throws an ElementNotFoundException.
- IDmsElement.GetTable no longer throws an ElementNotFoundException.
- IDmsColumn.GetAlarmLevel no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsColumn.GetDisplayValue no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsColumn\<T\>.GetValue no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsColumn.Lookup no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsColumn\<T\>.SetValue no longer throws an exception.
- IDmsStandaloneParameter.GetAlarmLevel no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsStandaloneParameter.GetDisplayValue no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsStandaloneParameter\<T\>.GetValue no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsStandaloneParameter\<T\>.SetValue no longer throws an exception.
- IDmsTable.AddRow no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.DeleteRow no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.DeleteRows no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.GetDisplayKey no longer throws an ElementStoppedException but instead will return null if the element is stopped.
- IDmsTable.GetDisplayKeys no longer throws an ElementStoppedException but instead will return an empty set if the element is stopped.
- IDmsTable.GetPrimaryKey no longer throws an ElementStoppedException but instead will return null if the element is stopped.
- IDmsTable.GetPrimaryKeys no longer throws an ElementStoppedException but instead will return an empty set if the element is stopped.
- IDmsTable.GetRow no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.GetRows no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.RowExists no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.
- IDmsTable.SetRow no longer throws an ElementStoppedException but instead will throw an ElementNotFoundException if the element is stopped.

##### Updated/changed SLNet calls

Additionally, some changes have been made to the SLNet calls that are executed in the background:

- When info for a single view is requested, the *GetInfo* message of type *ViewInfo* will now have the *viewId* mentioned in the *ExtraData* property of the SLNet call. If the request is sent to a DataMiner version that supports this (see [RN 41169](xref:General_Feature_Release_10.5.1#slnet-getinfo-messages-for-the-propertyconfiguration-and-viewinfo-types-now-support-retrieving-information-for-a-specific-item-id-41169)), DataMiner will only provide info in the response for that view instead of for all views.
- When property configurations are requested, the *GetInfo* message of type *PropertyConfiguration* will now include the requested type (e.g. ELEMENT, SERVICE, or VIEW) so the response only includes the property configurations of the requested type.
- The *ReferencedVersion* property of *IDmsProtocol* will now be obtained via a *GetInfo* SLNet call of type *Protocols* instead of a *GetProtocolMessage* call. Performance tests indicate that this is a less impacting call.

Note that only in DataMiner versions where [RN 41169](xref:General_Feature_Release_10.5.1#slnet-getinfo-messages-for-the-propertyconfiguration-and-viewinfo-types-now-support-retrieving-information-for-a-specific-item-id-41169) is implemented, DataMiner will respond with only the requested information. If the request is made to an older DataMiner version, all info will be in the response. In that case, the class library will just filter out the needed info.

### 1.1.1.13

#### New feature - SendMessages method added to ICommunications interface

The ICommunications interface has been extended with the following method:

```csharp
DMSMessage[] SendMessages(DMSMessage[] messages);
```

### 1.1.1.12

#### Fix - Breaking change reverted for InterAppCalls

When the Skyline.DataMiner.Core.InterAppCalls.Common NuGet package was used, versions 1.1.1.10/1.1.1.11 of the DataMinerSystem package could cause runtime errors. This breaking change has been reverted.

### 1.1.1.11

#### New feature - Retrieve alarm level for a view

*IDmsView* has a new method *GetAlarmLevel()*, which will retrieve the alarm level of a view.

### 1.1.1.10

#### New feature - Monitors Start and Stop methods overload with subscribe timeout

The Start and Stop extension methods now have additional overloads that take an additional subscribeTimeout (TimeSpan) argument, which allows you to set a timeout for the SLNet subscriptions when starting or stopping a subscription.

```csharp
try
{
    element.StartAlarmLevelMonitor( 
    protocol,
    (change) =>
    {
        var dms = change.Dms;
        var myElement = dms.GetElement(new DmsElementId(change.MonitorSource));
        var detectedElementAlarmParam = myElement.GetStandaloneParameter<string>(303);
        detectedElementAlarmParam.SetValue(change.Alarm.ToString());
    }, TimeSpan.FromSeconds(30));
}
catch(InvalidOperationException e)
{
    // SLNet subscribe timeout occurred.
}
```

The overloads that do not have the subscribeTimeout argument will use a default timeout of 10 minutes (which can result in an RTE). If you want to avoid an RTE, use the overload with the additional subscribeTimeout argument and provide a value that is small enough to avoid the RTE.

> [!NOTE]
> In the background, multiple SLNet subscriptions can be created when a single Start or Stop method is called. You should therefore make sure the timeout value is kept small enough to avoid an RTE.

### 1.1.1.9

#### New feature - Monitors added to subscribe to view alarm level and view state

Monitors have been added to subscribe to view alarm level and view state.

#### Enhancement - Support added for scripted connector types

With the introduction of the Data API module and scripted connectors, the *ConnectionType* enum has been extended with the following new types:

- *Grabber*
- *AutoGenerated*

### 1.1.1.8

#### Fix - View settings on service elements correctly updated

When the *IDmsService.Update()* method is used, the service will no longer be moved to the root view.

#### New feature - AsWriteable() method added to properties

*IDmsProperty* now has the *AsWritable()* method and *IsWritable* property. If the property is not writable, the method will throw an InvalidOperationException.

For an example, see [Setting a property and renaming the element](xref:ClassLibraryExamples#setting-a-property-and-renaming-the-element)

### 1.1.1.7

#### Fix - Advanced settings on service elements updated

When the *IDmsService.Update()* method is used, changes in the *AdvancedSettings* property are now taken into account.

### 1.1.1.6

#### New feature - Serial connections will now be read on element retrieval

When an IDmsElement is retrieved, the connections will now include the serial connections as well.

Element creation with serial connections is not supported yet.

### 1.1.1.5

#### Fix - Element deletion will be fully deleted

When an IDmsElement is deleted, a flag will now be set to properly delete an element like when this is done via Cube.

Without the flag, it could happen that active alarms were not deleted.

### 1.1.1.4

#### Fix - 1-minute timeout on Start and Stop Monitors increased to 10 minutes

When starting or stopping a Monitor, in some cases, creating or clearing the underlying subscription could time out after 1 minute on heavily loaded DataMiner Systems.

The timeout has now been increased to 10 minutes. Also, the exception logging has been improved to make it more clear to the user that this was an SLNet problem.

### 1.1.1.3

#### New feature - Partial table support for QueryData method in DmsTable class

The *QueryData* method in the DMSTable class can be used to retrieve very specific table data using column filters. Those filters have been changed into interfaces.

*QueryData* now also supports retrieving and filtering data from partial tables.

#### Fix - Partial table support for table monitors

Up to now, monitors on partial tables only worked for the first page.

This has been changed so that you can now monitor value changes on all pages of a partial table.

> [!NOTE]
> Monitoring on value changes of a partial table requires a lot of extra computing power in the background, so there is a drop in scalability and performance when monitoring partial tables. It should be OK to monitor a few of them, but benchmarking shows that setting up 20 monitors for a partial table will limit the ability to handle "burst" events (value changes every 100 ms) to around 300 events before more than 5 seconds are needed to handle an event (this compared to 1400 events before the same occurs on non-partial tables).

#### New feature - Migrated GetParameters and SetParameters from the Community Utility Library

When you retrieve the local element from IDms, you can now perform a special *GetParameters* call that retrieves multiple parameters and converts them into their given types. This can be done for both standalone parameters and column parameters.

When you retrieve the local element from IDms, you can now also perform a special *SetParameters* call that allows you to group together *SetParameterRequest* objects or provide a dictionary of parameter IDs and values to perform a single call.

#### New feature - Automation script execution enhanced with async execution and additional run flags

You can now trigger the execution of an Automation script asynchronously. In addition, you can provide several different run options similar to the options you get when triggering a script manually (e.g. LockElements, CheckSets, WaitWhenLocked, etc.).

### 1.1.1.2

#### Fix - Monitors could stop working for long duration user actions

When many monitors were started, and the actions you provided took several seconds to execute, there could be a race condition, and the monitor for an element could go into a faulted state because of the incoming initial events. The element would then ignore all new events coming in until the monitors were manually stopped and then started again.

This has been fixed by adding additional low-level locking. Benchmark tests show no negative impact on efficiency from this change.

### 1.1.1.1

#### Breaking Change - AddSubscriptions in ICommunication

A breaking change was introduced in the ICommunication interface. This will only affect users that directly access and use RemotingCommunication.

#### Breaking Change - Initial data on monitors no longer received

A breaking change was introduced: Starting a monitor will now not always return the initial data as an event. This is no longer possible with the way the monitors add subscription filters in the background. We recommend using other IDms calls to retrieve initial data if this is required.

#### New feature - .NET DataFlow applied to monitors

Scalability and performance of the monitors has been improved through the use of .NET DataFlow technology and parallel processing in the background. This version moves the largest bottleneck away from the software and places it mostly with the user hardware. Also, where before you would have affected other elements by using monitors, this is now much more isolated between elements.

The latest benchmark tests, at the time of release, demonstrate that the system's capacity to handle large workloads has increased by a factor ranging from 4 to 150 times depending on the hardware.

>[!Note]
> Scalability and performance depend on your system's ability to execute monitor handlers in parallel.

#### Fix - Automation scripts failed to parse with EXE blocks other than C\#

IDms can now retrieve Automation scripts that have EXE blocks that do not contain C# code.

#### New feature - Creation of service properties

IDms can now create service properties.

#### New feature - Monitors on tables now allow filtering on columns

Starting a value monitor on tables can now be done on only a few columns. This allows more efficiency by only subscribing to the changes you need.

### 1.1.0.5

#### New feature - LocalElement and GetColumns support

It is now possible to ask IDms for your local element. On that element you can perform additional code, such as GetColumns on a retrieved table, a call often missed in the Protocol interface provided in QActions.

This code was extracted from a popular internal community library "Utility Library", which can serve as an example for future extraction.

### 1.1.0.4

#### Fix - RemotingConnection replaced [ID 36324]

To prepare for the deprecation and removal of RemoteConnection, RemoteConnection has been replaced with a more secure connection type.

#### Fix - Views.Elements now returns stopped and paused elements [ID 36325]

Asking for all elements under a view will now return all stopped and paused elements.

### 1.1.0.3

#### New feature - Automation script retrieval support

Support has been added to retrieve and create automation scripts.

The following calls have been added:

- GetScripts
- GetScript
- CreateScript
- ScriptExists

### 1.1.0.2

#### Fixes to element creation

Element creation through this library produced corrupt elements since DataMiner version 10.3.4 [ID 33515]. This version fixes that issue.

### 1.1.0.1

#### New feature - Migration from Class Library

IDms classes and functionality have been extracted alongside Class Library monitors into a public available NuGet library. This was extracted from Class Library range 1.3.0.X

#### Overloads added for specifying primary/display key [ID 35048]

A number of IDmsColumn methods have been marked obsolete. They have now been replaced with new methods in which a KeyType will indicate whether a primary key or a display key is being used.

Also, an overload method for SetValue has been added to IDmsColumn to specify which KeyType is being used.
