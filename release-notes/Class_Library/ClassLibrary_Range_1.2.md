---
uid: ClassLibrary_Range_1.2
---

# Class Library Range 1.2

> [!NOTE]
> Range 1.2.x.x is supported as from DataMiner version 10.0.3

### 1.2.2.8

An Interface containing logic with regard to 'interface utilization calculations' and 'interface counters discontinuity' has been added.

### 1.2.2.7

#### Add support for Services in IDmsView [ID_34999]

IDmsView now has an extra property *Services*, which will contain the services under that specific view. These are filtered out from the *Elements*'* property.

When looping over the *Elements* and requesting the protocol name, it will no longer throw an exception as it will now only contain the elements instead of the elements and the services.

#### Overloads have been added for specifying primary/display key [ID_35048]

Several IDmsColumn methods have been updated. By default, the software will check by Display Key. If no such key is found, it will then check by Primary Key.

An overload method for SetValue has been added to IDmsColumn to specify which KeyType is being used.

### 1.2.2.6

Methods for Rate calculations based on DateTime now require UTC DateTime values.

The example protocol *SLC SDF Rates - Custom* has also been adapted accordingly.

### 1.2.2.5

#### 'LogType does not exist in current context' error [ID_34469]

In some cases, the following error would be thrown:

```txt
The name 'LogType' does not exist in the current context
```

In order to prevent this error, from now on, *QActionHelperBaseClasses* will always be loaded together with *SLManagedScripting*.

#### Rate classes now include device reboot detection to avoid invalid rate calculations [ID_34470]

The Rate classes now include device reboot detection to avoid invalid rate calculations.

The example protocol *SLC SDF Rates - SNMP* has also been adapted accordingly.

### 1.2.2.4

#### Class Library is now able to process elements of which the RemoteElement property of the ElementInfoEventMessage is set to the maximum value \[ID_33751\]

The Class Library is now able to process elements of which the RemoteElement property of the ElementInfoEventMessage is set to the maximum value (i.e. "4294967295/4294967295").

#### Class Library folder structure has been updated \[ID_33872\]

The folder structure of the Class Library has been updated. "DataMiner\\Library" has been removed from the root path.

#### DllImport statement added to RateHelper class \[ID_33878\]

The RateHelper class lacked a DllImport statement. This has now been added.

### 1.2.2.3

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

### 1.2.2.2

*Internal release*

### 1.2.2.1

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

### 1.2.1.2

#### Class Library monitors now allow triggering an action when their own element is stopped \[ID_33097\]

A Class Library monitor now allows triggering an action when its own element is stopped.

#### Problem with redundant SLNet calls \[ID_33104\]

Up to now, in some cases, SLNet calls would be sent while it was unnecessary to do so. From now on, those redundant calls will no longer be sent.

#### Class Library NuGet package contained an incorrect DLL file \[ID_33106\]

Up to now, the Class Library NuGet package would contain an incorrect DLL file.

### 1.2.1.1

#### Class Library can now be installed and used as a NuGet package \[ID_33102\]

From now on, the Class Library can be installed and used as a NuGet package.

> [!WARNING]
> BREAKING CHANGE: From now on, InterAppCalls will no longer use reflection. This means that, when using InterApp calls, you will now always need to provide a list with all Known Class Types when deserializing or serializing messages. Also when linking a message to an executor, you will now need to provide a mapping.

### 1.2.0.8

#### Extended authentication algorithm support \[ID_30232\]

The class library now supports the following authentication algorithms:

- MD5
- HMAC-MD5
- SHA1
- HMAC-SHA1

### 1.2.0.7

#### RemotePort would throw 'null reference' exceptions when trying to retrieve a replicated element \[ID_30053\]

RemotePort would throw "null reference" exceptions when trying to retrieve a replicated element.

#### Monitors that subscribe to a table can now execute code whenever data in that table is updated \[ID_30055\]

Monitors that subscribe to a table can now execute code whenever data in that table is updated.

#### SLSpectrum wrappers were missing a GetMonitor call with the correct return format \[ID_30056\]

The SLSpectrum wrappers were missing a GetMonitor call with the correct return format.

### 1.2.0.6

#### IsSslTlsEnabled property of all ports of an element would incorrectly be reset to false when an element port had been updated \[ID_29440\]

When an element port was updated, up to now, the IsSslTlsEnabled property of all ports of that element would incorrectly be reset to false.

#### IElementCollection now implements IEnumerable \[ID_29442\]

The IElementConnectionCollection interface, which is implemented by the ElementConnectionCollection class, now extends IEnumberable\<T>, allowing it to be used, for example, in a foreach loop to iterate over the connections.

#### DmsService class can now be used to manage DataMiner services \[ID_29513\]

The class library now includes a DmsService class that can be used to manage DataMiner services.

#### Monitors added to subscribe to service alarm level and service state \[ID_29515\]

Monitors have been added to subscribe to service alarm level and service state.

### 1.2.0.5

#### Creating, updating and retrieving HTTP connections of elements \[ID_29070\]

IDms classes now support creating, updating and retrieving HTTP connections of elements.

#### Retrieving CI type information from connections \[ID_29071\]

In IDP environments, extension methods now allow you to retrieve CI type information from connections.

#### Creating and deleting properties in a DataMiner System \[ID_29072\]

IDms classes now support creating and deleting properties in a DataMiner System.

#### New SLNet wrapper methods to communicate with SLScheduler and SLSpectrum \[ID_29074\]

SLNet wrapper methods now allow you to safely communicate with the SLScheduler and SLSpectrum modules. Up to now, Scheduler and Spectrum Interop classes had to be used to communicate with those modules.

### 1.2.0.4

#### Name of an element with a RealConnection could no longer be updated \[ID_27783\]

In some cases, the name of an element with a RealConnection (SNMP, HTTP, SERIAL, etc.) could no longer be updated.

#### A matrix output could not be disconnected when it was connected to the first input \[ID_27784\]

Due to an error in the Matrix Helper class, in some cases, an output could not be disconnected when it was connected to the first input.

### 1.2.0.3

#### DataMiner System interface would thrown an exception when parsing elements in a view \[ID_26422\]

In some cases, the DataMiner System interface would throw an IndexOutOfRange exception when parsing elements in a view.

#### Incorrectly formatted input string would cause the GetElement method to throw an exception \[ID_26423\]

In some cases, an incorrectly formatted input string would cause the GetElement method to throw an exception.

### 1.2.0.2

#### Deserialization would fail when 'System.' classes were used \[ID_25933\]

In some cases, collection interface deserialization could fail if some of the classes were "System." classes located in System.dll.

Deserialization now supports classes located in both System.Core.dll and System.dll.

### 1.2.0.1

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

#### IEngine interface now supports the extension of the GetDms method \[ID_25632\]

The IEngine interface now supports the extension of the GetDms method.
