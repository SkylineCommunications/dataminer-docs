---
uid: DIS_2.44
---

# DIS 2.44

## New features

### IDE

#### DIS now fully supports Visual Studio themes [ID 37025]

DIS now supports Visual Studio themes. Several components like *Display Editor*, *Table Editor*, *Function Editor*, etc. have been redesigned to fully support Visual Studio themes.

Also, the overall look and feel of DIS now matches that of DataMiner Cube.

#### DIS Inject: Attaching the Visual Studio Debugger to multiple SLScripting processes [ID 37042]

Up to now, when attaching the Visual Studio Debugger to SLScripting, DIS would only attach the Visual Studio Debugger to the first SLScripting process it found. As, in DataMiner, there is an option to have multiple SLScripting processes, DIS will now attach the Visual Studio Debugger to all processes that match the process name.

See also: [Setting the number of simultaneously running SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes)

### Validator

#### New checks and error messages [ID 37077]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 3.37.1 | UnrecommendedCultureInfoDefaultThreadCurrentCulture | Setting property 'CultureInfo.DefaultThreadCurrentCulture' is unrecommended. QAction ID 'qactionId'. |
| 3.37.2 | UnrecommendedThreadCurrentThreadCurrentCulture | Setting property 'Thread.CurrentThread.CurrentCulture' is unrecommended. QAction ID 'qactionId'. |
| 3.37.3 | UnrecommendedThreadCurrentThreadCurrentUICulture | Setting property 'Thread.CurrentThread.CurrentUICulture' is unrecommended. QAction ID 'qactionId'. |

## Changes

### Enhancements

#### Enhanced performance when building the app package of a large automation script solution [ID 37013]

Because of a number of enhancements, overall performance has increased when building the app package of a large automation script solution.

### Fixes

#### Problem when converting a protocol.xml file to a solution [ID 37087]

In some cases, a NullReferenceException could be thrown when converting a protocol.xml file to a solution.

When a new DIS version is installed from scratch, the following default DLL location will now be specified in the settings: `C:\Skyline DataMiner\ProtocolScripts\DllImport`

#### Problem when opening a QAction of a protocol that was not a solution [ID 37088]

When you opened a QAction of a protocol that was not a solution, an exception would be thrown when installing a NuGet package.

#### MIB Browser: Compare would not take into account tables in the MIB tree [ID 37163]

The *Compare* tab shows the differences between the OID data in the MIB tree and the parameter data in the protocol.xml file.

Up to now, a message could incorrectly appear, saying that a particular table in the protocol could not be found in the MIB tree. From now on, tables in the MIB tree will also be taken into account when comparing the OID data in the MIB tree with the parameter data in the protocol.xml file.
