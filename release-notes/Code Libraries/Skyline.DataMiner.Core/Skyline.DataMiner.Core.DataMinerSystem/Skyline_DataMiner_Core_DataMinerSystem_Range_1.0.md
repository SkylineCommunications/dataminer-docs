---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.0
---

# Skyline DataMiner Core DataMinerSystem Range 1.0

> [!NOTE]
> Range 1.0.x.x is supported as from DataMiner version 10.1.0
> This is a continuation from the now obsolete [Class Library](xref:ClassLibrary_Range_1.2)

### 1.0.1.0

#### Breaking Change - AddSubscriptions in ICommunication

The breaking change indicated by the version was introduced in the ICommunication interface. This will only impact users that directly access and use RemotingCommunication.

#### New Feature - .NET DataFlow applied to Monitors

Scalability and performance of the Monitors has been improved through the use of .NET DataFlow technology and parallel processing in the background.
This version moves the largest bottleneck away from the software and places it mostly with the user hardware.
Also, where before you would have impacted other elements by using Monitors this is now much more isolated between elements.

The latest benchmark tests, at the time of release, demonstrate that the system's capacity to handle large workloads has increased by a factor ranging from 4 to 150 times depending on the hardware.

>[!Note]
> Scalability and performance depend on your system's ability to execute monitor handlers in parallel.

#### Fix - Automation Scripts failed to parse with EXE blocks other than C#

IDms can now retrieve Automation Scripts that have EXE blocks that do not contains C# code.

#### New Feature - Create Service Properties

IDms can now create Service Properties.

### 1.0.0.6

#### New Feature - LocalElement and GetColumns support

It is now possible to ask IDms for your local element. On that element you can perform additional code such as GetColumns on a retrieved table.
A call often missed in the Protocol interface provided in QActions.
This code was extracted from a popular internal community library "Utility Library" as can serve as an example for future extraction.

### 1.0.0.5

#### Fix - Views.Elements now returns stopped and paused elements \[ID_36325\]

Asking for all elements under a view will now return all stopped and paused elements.

#### Fix - RemotingConnection replaced \[ID_36324\]

​RemoteConnection was replaced with a more secure Connection type. As preparation for the deprecation and removal of RemoteConnection.

### 1.0.0.4

#### New Feature - Automation script retrieval support

Support was added to retrieve and create automation scripts.
Added calls:

- GetScripts
- GetScript
- CreateScript
- ScriptExists

### 1.0.0.3

#### Fixes to Element Creation

Element Creation through this library produced corrupt elements since DataMiner version 10.3.4 \[ID_33515\]
This version fixes that element creation.

### 1.0.0.2

#### Fixes to NuGet Descriptions

Added minimum required DataMiner version to the description of NuGets for user clarity.

### 1.0.0.1

#### New Feature - Migrated from Class Library

Extracted IDms classes and functionality alongside Class Library Monitors into a public available NuGet library.
This was extracted from Class Library range 1.2.0.X