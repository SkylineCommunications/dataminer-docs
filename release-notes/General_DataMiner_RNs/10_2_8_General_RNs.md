---
uid: 10_2_8_General_RNs
---

# DataMiner 10.2.8 release notes

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!NOTE]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.8 release notes](xref:10_2_8_Cube_RNs).

## Highlights

## Other new features

### Core functionality

#### DataMiner Object Model: Defining a script execution action that will execute an interactive Automation script [ID_33513]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

It is now possible to define a script execution action that will execute an interactive Automation script.

Process:

1. A client requests the execution of a DOM action in which the execution of an interactive Automation script has been defined via the `domHelper.DomInstances.ExecuteAction()` method.

    To indicate that the Automation script is an interactive Automation script, the *IsInteractive* property of the *ExecuteScriptDomActionDefinition* must be set to true.

1. The `domHelper.DomInstances.ExecuteAction()` method replies immediately.

    - Its *TraceData* contains a *DomActionInfo* object in which type is set to "DomActionInfo.Type.ScriptExecutionId".
    - The *info* object has an *ExecutionId* property that contains the execution ID of the script that was triggered by the DOM action.

1. The client sends a *ScriptControlMessage* of type "Launch" using the script ID that was returned and will then receive *ScriptProgressEventMessages*.

> [!NOTE]
> The connection used by the DomHelper sending the DOM action execution request should also be used to interact with the script.

### DMS web apps

#### Dashboards app: Service Definition component now supports both types of process automation service definitions [ID_33615]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

The Service Definition component now supports both types of process automation service definitions:

- Skyline Process Automation
- Custom Process Automation

#### GQI: Data source 'Get custom data' renamed to 'Get ad hoc data' [ID_33795]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

The data source "Get custom data" has been renamed to "Get ad hoc data".

### DMS tools

#### QA Device Simulator: Help link now directs users to the QA Device Simulator help pages on 'https://docs.dataminer.services/' [ID_33680]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In the UI of the QA Device Simulator, the help link now directs users to the QA Device Simulator help pages on <https://docs.dataminer.services/>.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

## Changes

### Enhancements

#### Enhanced BPA error message [ID_33393]

<!-- Main Release Version 10.2.0 [CU5] - Feature Release Version 10.2.8 -->

Up to now, when a BPA test could not be executed on an offline Failover agent, it would return the following error message:

`This BPA does not apply for this DataMiner Agent.`

From now on, it will return the following error message instead:

`This BPA does not apply for this DataMiner Agent: cannot run on Offline Failover Agent.`

#### GQI queries: Enhanced performance when retrieving custom properties [ID_33538]

<!-- Main Release Version 10.2.0 [CU5] - Feature Release Version 10.2.8 -->

Because of a number of enhancements, overall GQI query performance has increased when retrieving custom properties for views, services and elements.

### Fixes

#### Problem when processing a history set with a timestamp referring to a moment far in the past [ID_33774]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->
<!-- Not added to 10.3.0 -->

When SLElement was processing a history set, an error could occur when the timestamp of that history set referred to a moment far in the past.

#### Failover: Problem with AlwaysBruteForceOffline option [ID_33775]

<!-- Main Release Version 10.2.0 [CU5] - Feature Release Version 10.2.8 -->

The following problems with the Failover option AlwaysBruteForceOffline have now been fixed:

- When configured via an `UpdateFailoverConfigMessage` in an Automation script, the option would not be applied in the *DMS.xml* file.
- When configured by manually updating the *DMS.xml* file, the option would be overwritten.
- When applied, the option would cause the DMA to restart without also restarting SLNet.

> [!NOTE]
> In DataMiner Cube, the *AlwaysBruteForceOffline* option can now be configured by enabling or disabling the *Auto restart agent when going offline* option in the *Advanced options* tab of the *Advanced Failover Configuration* window.
