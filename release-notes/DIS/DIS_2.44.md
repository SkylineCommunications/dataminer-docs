---
uid: DIS_2.44
---

# DIS 2.44

## New features

### IDE

#### Improved theming support in Visual Studio [ID_37025]

DIS now has improved theming support in Visual Studio. Several components like the Display Editor, Table Editor, ... have gotten an overhaul and can properly support other themes.
In addition, the overall style has been modernized to match Cube.

#### DIS Inject - Support for multiple SLScripting processes [ID_37042]

Up to now, when attaching to SLScripting it would only attach to the first SLScripting process found. In DataMiner, there is however an option to have multiple SLScripting processes.

Now it will attach to all processes that match the process name.

> [!NOTE]
> This change is made futureproof for Automation scripts in case there would be multiple SLAutomation processes.

See [Setting the number of simultaneously running SLScripting processes](https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Agents/Configuring_a_DMA/Configuration_of_DataMiner_processes.html#setting-the-number-of-simultaneously-running-slscripting-processes)

### Validator

#### New checks and error messages [ID_37077]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 3.37.1 | UnrecommendedCultureInfoDefaultThreadCurrentCulture | Setting property 'CultureInfo.DefaultThreadCurrentCulture' is unrecommended. QAction ID 'qactionId'. |
| 3.37.2 | UnrecommendedThreadCurrentThreadCurrentCulture | Setting property 'Thread.CurrentThread.CurrentCulture' is unrecommended. QAction ID 'qactionId'. |
| 3.37.3 | UnrecommendedThreadCurrentThreadCurrentUICulture | Setting property 'Thread.CurrentThread.CurrentUICulture' is unrecommended. QAction ID 'qactionId'. |

## Changes

### Enhancements

#### Enhanced performance when building the app package for big automation script solutions [ID_37013]

Because of a number of enhancements, overall performance has increased when building the app package for big automation script solutions (e.g.: 80+ scripts).

### Fixes

#### Convert protocol XML to solution could throw NullReferenceException [ID_37087]

In specific scenario's it could be that the conversion throws a NullReferenceException.
This should not happen anymore.

In addition, for new installations, the following path has been added as a default DLL location in the settings: "C:\Skyline DataMiner\ProtocolScripts\DllImport".

#### Open QAction on imported protocol throws exception [ID_37088]

When opening a QAction from a protocol, that isn't a solution, it would throw an exception during a NuGet package installation.

#### DIS MIB Browser - Compare didn't take in account tables [ID_37163]

When comparing a protocol and MIB files in the MIB Browser, it would falsely say that the table in the protocol wasn't found in the MIB.

This has now been fixed by checking the tables in the MIB as well.
