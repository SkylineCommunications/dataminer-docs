---
uid: ClassLibrary_Range_1.1
---

# Class Library Range 1.1

> [!NOTE]
> Range 1.1.x.x is supported as from DataMiner version 9.6.3

### 1.1.4.7

#### Add support for Services in IDmsView [ID_34999]

IDmsView now has an extra property *Services*, which will contain the services under that specific view. These are filtered out from the *Elements*'* property.

When looping over the *Elements* and requesting the protocol name, it will no longer throw an exception as it will now only contain the elements instead of the elements and the services.

### 1.1.4.6

Methods for Rate calculations based on DateTime now require UTC DateTime values.

The example protocol *SLC SDF Rates - Custom* has also been adapted accordingly.

### 1.1.4.5

#### 'LogType does not exist in current context' error [ID_34469]

In some cases, the following error would be thrown:

```txt
The name 'LogType' does not exist in the current context
```

In order to prevent this error, from now on, *QActionHelperBaseClasses* will always be loaded together with *SLManagedScripting*.

#### Rate classes now include device reboot detection to avoid invalid rate calculations [ID_34470]

The Rate classes now include device reboot detection to avoid invalid rate calculations.

The example protocol *SLC SDF Rates - SNMP* has also been adapted accordingly.

### 1.1.4.4

#### Class Library is now able to process elements of which the RemoteElement property of the ElementInfoEventMessage is set to the maximum value \[ID_33751\]

The Class Library is now able to process elements of which the RemoteElement property of the ElementInfoEventMessage is set to the maximum value (i.e. "4294967295/4294967295").

#### Class Library folder structure has been updated \[ID_33872\]

The folder structure of the Class Library has been updated. "DataMiner\\Library" has been removed from the root path.

#### DllImport statement added to RateHelper class \[ID_33878\]

The RateHelper class lacked a DllImport statement. This has now been added.

### 1.1.4.3

#### InterAppCalls deserialize fails with KnownTypes having multiple Collections \[ID_33720\]

Deserialization would fail when using InterAppCalls as NuGets without a common DLL holding all the messages, i.e. when using KnownTypes with multiple Collections (as in the following example).

```csharp
KnownTypes = new List(){ typeof(List<MyClass>), typeof(List<MyClass2>)};
```

The JSON created by the sending element would incorrectly contain the name of the assembly holding List\<MyClass2> (i.e. QA2.dll), and trying to deserialize this on the receiver side would fail as QA2.dll could not be found.

JSON will now no longer contain assembly information, and deserialization has been improved so that the correct assembly can be found on the receiver side.

#### Monitor cleanup delay \[ID_33721\]

You can now override the default cleanup behavior by adding a delay to the cleanup. This can be useful to avoid having to recreate monitors when an element is restarted or migrated.

The cleanup is canceled when the source or destination element that triggered the cleanup is started again before the delay timer is done.

> [!NOTE]
> The element state is checked every 2 seconds, so it is best to create delays as a multiple of 2000 ms.

In the example below, cleanup after source element stop is delayed by 6 seconds.

```csharp
MonitorCleanupConfig monitorCleanupConfig = new MonitorCleanupConfig(0, 0, 6000);
protocol.SetupMonitorsCleanupConfig(monitorCleanupConfig);
```

By passing a MonitorCleanupConfig object to the protocol, you can define delays on:

- Cleanup after destination element deletion.
- Cleanup after source element deletion.
- Cleanup after source element stop.

#### Monitoring stopped elements \[ID_33722\]

Using the Class Library, it is now possible to request a standalone parameter or a table from a stopped element. This will allow you to create monitors that keep track of changes to parameters of stopped elements.

#### New bit rate calculation classes added \[ID_33877\]

The Class Library now contains new bit rate calculation classes.

### 1.1.4.2

*Internal release*

### 1.1.4.1

#### Simplified version of the MessageExecutor \[ID_33223\]

A simplified version of the MessageExecutor has been added (SimpleMessageExecutor\<T>), containing only a TryExecute method.

This MessageExecutor version can be used for small executors with a minimum of logic that do not need separate actions (DataGet, DataSet, Parse, etc.).

#### Replying to an InterAppCall \[ID_33233\]

Up to now, when you wanted to return a message after receiving an InterAppCall, you had to manually update the GUID to that of the incoming message.

From now on, you can use

- the Reply method on the incoming message to update the GUID of the return message, followed by
- the Send method with the ReturnAddress information from the incoming message.

#### 'Skyline.DataMiner.' prefix shortened to 'SLC.Lib.' \[ID_33257\]

The "Skyline.DataMiner." prefix for Class Library exceeded to 260-character path length limit of Microsoft Windows. This prefix has now been shortened to "SLC.Lib.".

> [!WARNING]
> For code using NuGets, this is a breaking change.

### 1.1.3.2

#### Class Library monitors now allow triggering an action when their own element is stopped \[ID_33097\]

A Class Library monitor now allows triggering an action when its own element is stopped.

#### Problem with redundant SLNet calls \[ID_33104\]

Up to now, in some cases, SLNet calls would be sent while it was unnecessary to do so. From now on, those redundant calls will no longer be sent.

#### Class Library NuGet package contained an incorrect DLL file \[ID_33106\]

Up to now, the Class Library NuGet package would contain an incorrect DLL file.

### 1.1.3.1

#### Class Library can now be installed and used as a NuGet package \[ID_33102\]

From now on, the Class Library can be installed and used as a NuGet package.

> [!WARNING]
> BREAKING CHANGE: From now on, InterAppCalls will no longer use reflection. This means that, when using InterApp calls, you will now always need to provide a list with all Known Class Types when deserializing or serializing messages. Also when linking a message to an executor, you will now need to provide a mapping.

### 1.1.2.12

#### Extended authentication algorithm support \[ID_30232\]

The class library now supports the following authentication algorithms:

- MD5
- HMAC-MD5
- SHA1
- HMAC-SHA1

### 1.1.2.11

#### RemotePort would throw 'null reference' exceptions when trying to retrieve a replicated element \[ID_30053\]

RemotePort would throw "null reference" exceptions when trying to retrieve a replicated element.

#### Monitors that subscribe to a table can now execute code whenever data in that table is updated \[ID_30055\]

Monitors that subscribe to a table can now execute code whenever data in that table is updated.

#### SLSpectrum wrappers were missing a GetMonitor call with the correct return format \[ID_30056\]

The SLSpectrum wrappers were missing a GetMonitor call with the correct return format.

### 1.1.2.10

#### Additional check to prevent elements to restart after being updated \[ID_29777\]

When an element is updated, it will be restarted whenever its port settings have been changed. Now, an additional check has been added to make sure an element is not restarted when, during an update, its port settings have not been changed.

### 1.1.2.9

#### IsSslTlsEnabled property of all ports of an element would incorrectly be reset to false when an element port had been updated \[ID_29440\]

When an element port was updated, up to now, the IsSslTlsEnabled property of all ports of that element would incorrectly be reset to false.

#### IElementCollection now implements IEnumerable \[ID_29442\]

The IElementConnectionCollection interface, which is implemented by the ElementConnectionCollection class, now extends IEnumberable\<T>, allowing it to be used, for example, in a foreach loop to iterate over the connections.

#### DmsService class can now be used to manage DataMiner services \[ID_29513\]

The class library now includes a DmsService class that can be used to manage DataMiner services.

#### Monitors added to subscribe to service alarm level and service state \[ID_29515\]

Monitors have been added to subscribe to service alarm level and service state.

### 1.1.2.8

#### Creating, updating and retrieving HTTP connections of elements \[ID_29070\]

Dms classes now support creating, updating and retrieving HTTP connections of elements.

#### Retrieving CI type information from connections \[ID_29071\]

In IDP environments, extension methods now allow you to retrieve CI type information from connections.

#### Creating and deleting properties in a DataMiner System \[ID_29072\]

IDms classes now support creating and deleting properties in a DataMiner System.

#### New SLNet wrapper methods to communicate with SLScheduler and SLSpectrum \[ID_29074\]

SLNet wrapper methods now allow you to safely communicate with the SLScheduler and SLSpectrum modules. Up to now, Scheduler and Spectrum Interop classes had to be used to communicate with those modules.

### 1.1.2.7

#### Name of an element with a RealConnection could no longer be updated \[ID_27783\]

In some cases, the name of an element with a RealConnection (SNMP, HTTP, SERIAL, etc.) could no longer be updated.

#### A matrix output could not be disconnected when it was connected to the first input \[ID_27784\]

Due to an error in the Matrix Helper class, in some cases, an output could not be disconnected when it was connected to the first input.

### 1.1.2.5

#### DataMiner System interface would thrown an exception when parsing elements in a view \[ID_26422\]

In some cases, the DataMiner System interface would throw an IndexOutOfRange exception when parsing elements in a view.

#### Incorrectly formatted input string would cause the GetElement method to throw an exception \[ID_26423\]

In some cases, an incorrectly formatted input string would cause the GetElement method to throw an exception.

### 1.1.2.4

#### Deserialization would fail when 'System.' classes were used \[ID_25933\]

In some cases, collection interface deserialization could fail if some of the classes were 'System.' classes located in System.dll.

Deserialization now supports classes located in both System.Core.dll and System.dll.

### 1.1.2.3

#### Retrieving data from partial tables \[ID_24951\]

The Class Library is now able to retrieve data from partial tables.

##### GetData method

The IDmsTable GetData method will now return the entire contents of a partial table.

Up to now, it would only return the first page of such a table.

##### QueryData method

The new IDmsTable QueryData method will return an IEnumerable\<object\[\]\>, i.e. a collection of row objects.

To this method, you can pass a column filter as an ICollection\<ITableFilter>, in which each ITableFilter item contains a ColumnPid, a ColumnValue and a CompareType property. If, for example, you only want to retrieve the rows in which column parameter 1003 is set to "test", you can specify the following:

```csharp
ITableFilterItem filter = new TableFilterItem
{
    ColumnPid = 1013,
    ColumnValue = "test",
    CompareType = CompareType.Equal
};
```

> [!NOTE]
>
> - Using GetData will retrieve the entire table in one request. If you only need to retrieve a portion of a table, consider using QueryData instead.
> - Using QueryData without a filter will retrieve the entire table in multiple requests (one request per page).
> - Using QueryData with a filter will retrieve the table rows matching the filter in one request.

#### Matrix Helper: Serialized matrix status information \[ID_25127\]

The Matrix Helper classes now have an extra constructor that allows passing the ID of the serialized parameter, a single displayed read parameter of which the measurement type is set to string. The Matrix Helper object will then fill this parameter with the entire matrix status (labels, locks, crosspoints, etc.) in JSON format.

This matrix status information can then be read by, for example, the Generic Matrix Virtualization protocol or any other external element that is able to deserialize the JSON content to an object of the MatrixStatus class, which can be found in the same namespace as the Matrix Helper.

#### InterApp calls: Problem when checking the mapping dictionary \[ID_25442\]

The InterApp calls allow to provide a dictionary that is a mapping between the Message class and the Executor class. When the Class Library was used as a DLL file, in some cases, the dictionary check would fail.

#### Retrieving SNMP connection information & creating elements with SNMP connections \[ID_25585\]

The Class Library now supports the retrieval of information from the following SNMP connections as well as the creation of elements with these types of connections:

- SNMPv1 connections
- SNMPv2 connections
- SNMPv3 connections
- Virtual connections

### 1.1.2.2

#### Problem recreating the monitor after an element restart \[ID_24756\]

When an element was restart, in some rare cases, an error could occur when recreating the Class Library monitor.

#### Enhanced handling of errors occurring while parsing element information returned by a GetElements method \[ID_24934\]

From now on, the Class Library will no longer throw an exception when an error occurs while parsing element information returned by a GetElements method.

- When element replication is not enabled for a particular element, then the replication properties of that element will no longer be parsed.

- When element replication is enabled for a particular element, and an error occurs while parsing the replicated remote element, then the incorrect ID will be logged, and the default remote element ID "-1/-1" will be used instead. This will make sure the element is included in the list of elements returned by the GetElements method.

- When a general error occurs while parsing the information of an element, then an entry will be added to the log, and the GetElements method will return all elements of which the information was parsed successfully.

### 1.1.2.1

#### DMS Monitors \[ID_24066\]

The new Monitor Extension methods provide stable logic to handle eventing. They encapsulate DataMiner subscriptions and handle all correct cleanup and stability guidelines, leaving a developer free to focus on what must happen when an event is triggered.

Currently, the supported methods provide the ability to monitor changes in the full DMS and trigger a C# method to run for:

- Standalone parameter value changes
- Table cell value changes
- Parameter alarm level changes
- Table cell alarm level changes
- Single element alarm changes
- Single element name changes
- All elements (DMS-level) alarm changes
- All elements (DMS-level) name changes

> [!NOTE]
> Class Library Monitors will only work in conjunction with DataMiner version 9.6.3 or higher.

#### New Rates namespace \[ID_24283\]

A new Rates namespace has been added. This namespace contains classes and methods that can be used to calculate all kind of rates, including bit rates for SNMP interface tables.

#### element.IsStartupComplete method would throw an exception when executed on an element that had been stopped \[ID_24290\]

In some cases, the IDmsElement IsStartupComplete method would throw an exception when it was executed on an element that had been stopped.

#### Problem when updating properties \[ID_24291\]

In some cases, it would not be possible to update properties that had a value equal to NULL.

#### Problem when requesting an element with duplicate properties \[ID_24293\]

When an element was requested via IDms, in some cases, an exception could be thrown when the element had duplicate properties.

From now on, when an element has duplicate properties, no exception will be thrown, but an entry will be added to the `C:\Skyline DataMiner\Logging\ClassLibrary.txt` log file.

#### Table cell subscriptions will now be established using the primary key \[ID_24456\]

Up to now, table cell subscriptions were established using the display key. From now on, they will be established using the primary key.

#### GetAlarmTemplates() and GetTrendTemplates() would not work when the protocol was a production protocol \[ID_24357\]

In some cases, it would not be possible to retrieve the alarm template or the trend template of a protocol via IDms when that protocol was a production protocol.

Also, the IDmsProtocol interface now has a new "ReferencedVersion" property.

### 1.1.0.2

#### View name would be retrieved when it was already known \[ID_22303\]

Up to now, in some cases, the name of a view would be retrieved when it was already known. From now on, when the name of a view is already known, it will no longer be retrieved a second time.

#### Element properties will only be retrieved when needed \[ID_23514\]

From now on, element properties will only be retrieved when needed.

#### Exception thrown after detecting an element with duplicate properties will now also contain the name of the ID of the element \[ID_23515\]

The exception that is thrown when an element with duplicate properties is detected will now also contain the name and the ID of the element in question.

### 1.1.0.1

#### New matrix classes added to facilitate matrix and router control implementations \[ID_23075\]

Under Skyline.DataMiner.Library.Protocol.Matrix, the Class Library now contains a collection of classes that will help you develop matrix and router control implementations.

Also, in the DIS Macros tool window, a new CreateMatrix macro was added. This macro will help you initiate a new matrix and/or router control.

#### New InterApp classes now provide a C# message/response architecture \[ID_23298\]

A collection of InterApp classes now provides a C# message/response architecture that will allow for easier communication

- among elements,
- between elements and Automation scripts, and
- between elements and external applications.
