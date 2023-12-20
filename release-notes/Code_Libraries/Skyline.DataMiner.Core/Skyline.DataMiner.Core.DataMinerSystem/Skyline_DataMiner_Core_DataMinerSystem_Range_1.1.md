---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.1
---

# Skyline DataMiner Core DataMinerSystem Range 1.1

> [!NOTE]
> Range 1.1.x.x is supported as from **DataMiner 10.1.11**. It makes use of a change introduced in DataMiner 10.1.11 that makes it possible to obtain table cell data using the primary key. In earlier DataMiner versions, the display key was needed to obtain this data.

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

#### Fix - RemotingConnection replaced [ID_36324]

To prepare for the deprecation and removal of RemoteConnection, RemoteConnection has been replaced with a more secure connection type.

#### Fix - Views.Elements now returns stopped and paused elements [ID_36325]

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

Element creation through this library produced corrupt elements since DataMiner version 10.3.4 [ID_33515]. This version fixes that issue.

### 1.1.0.1

#### New feature - Migration from Class Library

IDms classes and functionality have been extracted alongside Class Library monitors into a public available NuGet library. This was extracted from Class Library range 1.3.0.X

#### Overloads added for specifying primary/display key [ID_35048]

A number of IDmsColumn methods have been marked obsolete. They have now been replaced with new methods in which a KeyType will indicate whether a primary key or a display key is being used.

Also, an overload method for SetValue has been added to IDmsColumn to specify which KeyType is being used.
