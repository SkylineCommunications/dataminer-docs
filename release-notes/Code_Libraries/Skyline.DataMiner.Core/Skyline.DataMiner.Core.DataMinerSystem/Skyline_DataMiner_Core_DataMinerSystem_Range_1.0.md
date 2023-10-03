---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.0
---

# Skyline DataMiner Core DataMinerSystem Range 1.0

> [!NOTE]
> Range 1.0.x.x is supported as from **DataMiner 10.1.0**. This is a continuation from the now obsolete [Class Library](xref:ClassLibrary_Range_1.2).

### 1.0.1.2

#### Fix - Monitors could stop working for long duration user actions

When many monitors were started, and the actions you provided took several seconds to execute, there could be a race condition, and the monitor for an element could go into a faulted state because of the incoming initial events. The element would then ignore all new events coming in until the monitors were manually stopped and then started again.

This has been fixed by adding additional low-level locking. Benchmark tests show no negative impact on efficiency from this change.

### 1.0.1.1

#### Breaking change - AddSubscriptions in ICommunication

A breaking change was introduced in the ICommunication interface. This will only affect users that directly access and use RemotingCommunication.

#### New feature - .NET DataFlow applied to Monitors

Scalability and performance of the Monitors has been improved through the use of .NET DataFlow technology and parallel processing in the background. This version moves the largest bottleneck away from the software and places it mostly with the user hardware. Also, where before you would have affected other elements by using Monitors, this is now much more isolated between elements.

The latest benchmark tests, at the time of release, demonstrate that the system's capacity to handle large workloads has increased by a factor ranging from 4 to 150 times depending on the hardware.

>[!Note]
> Scalability and performance depend on your system's ability to execute monitor handlers in parallel.

#### Fix - Automation scripts failed to parse with EXE blocks other than C\#

IDms can now retrieve Automation scripts that have EXE blocks that do not contain C# code.

#### New feature - Creation of service properties

IDms can now create service properties.

#### New feature - Monitors on tables now allow filtering on columns

Starting a value monitor on tables can now be done on only a few columns. This allows more efficiency by only subscribing to the changes you need.

### 1.0.0.6

#### New feature - LocalElement and GetColumns support

It is now possible to ask IDms for your local element. On that element you can perform additional code, such as GetColumns on a retrieved table, a call often missed in the Protocol interface provided in QActions.

This code was extracted from a popular internal community library "Utility Library", which can serve as an example for future extraction.

### 1.0.0.5

#### Fix - RemotingConnection replaced [ID_36324]

To prepare for the deprecation and removal of RemoteConnection, RemoteConnection has been replaced with a more secure connection type.

#### Fix - Views.Elements now returns stopped and paused elements [ID_36325]

Asking for all elements under a view will now return all stopped and paused elements.

### 1.0.0.4

#### New feature - Automation script retrieval support

Support has been added to retrieve and create Automation scripts.

The following calls have been added:

- GetScripts
- GetScript
- CreateScript
- ScriptExists

### 1.0.0.3

#### Fixes to element creation

Element creation through this library produced corrupt elements since DataMiner version 10.3.4 [ID_33515]. This version fixes that issue.

### 1.0.0.2

#### Fixes to NuGet descriptions

For the sake of clarity, the minimum required DataMiner version has been added to the description of NuGet packages.

### 1.0.0.1

#### New feature - Migration from Class Library

IDms classes and functionality have been extracted alongside Class Library Monitors into a publicly available NuGet library. This was extracted from Class Library range 1.2.0.x.
