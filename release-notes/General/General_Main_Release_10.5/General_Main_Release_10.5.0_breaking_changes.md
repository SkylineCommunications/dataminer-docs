---
uid: General_Main_Release_10.5.0_breaking_changes
---

# General Main Release 10.5.0 – Breaking changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

#### Parameter latch states will now be reset after every DataMiner restart [ID 39495]

<!-- MR 10.5.0 - FR 10.4.9 -->

In order to increase overall performance when starting up elements, parameter latch states will no longer be persistent by default. They will be reset after every DataMiner restart.

If you want to have persistent parameter latch states, do the following:

1. Open the *MaintenanceSettings.xml* file.

1. In the `AlarmSettings` section, add the `PersistParameterLatchState` option, and set it to true.

   ```xml
   <AlarmSettings>
      ...
      <PersistParameterLatchState>true</PersistParameterLatchState>
      ...
   </AlarmSettings>
   ```

1. Restart the DataMiner Agent.

> [!IMPORTANT]
>
> - From now on, by default (or when the `PersistParameterLatchState` option is set to false in *MaintenanceSettings.xml*), parameter latch states will no longer be written to or fetched from the database. This means that, after every DataMiner restart, all parameter latch states will be reset.
> - Element, service and view latch states will remain persistent as before.

#### GQI - 'Get alarms' data source: Updated 'Alarm ID' and 'Root Alarm ID' columns [ID 40372]

<!-- MR 10.5.0 - FR 10.4.11 -->

In the *Get alarms* data source, the following columns have been updated:

| Column | Former contents | New contents |
|--------|-----------------|--------------|
| Alarm ID      | HostingDMAID/AlarmID     | DMAID/EID/RootAlarmID/AlarmID |
| Root Alarm ID | HostingDMAID/RootAlarmID | DMAID/EID/RootAlarmID         |

> [!NOTE]
> "DMAID" refers to the DataMiner ID of the DataMiner Agent where the element was originally created. "HostingDMAID" refers to the DataMiner ID of the DataMiner Agent currently hosting the element and managing its alarms. Most of the time, these two values will be the same, but they may differ, for example, when an element is exported from one Agent and imported onto another Agent. In this case, the element retains the original DMAID, but the HostingDMAID will reflect the new Agent's ID.

#### Automation: SubScriptOptions.SkipStartedInfoEvent will now by default be set to true [ID 40867]

<!-- MR 10.5.0 - FR 10.4.12 -->

If you have created an Automation script that launches subscripts, you can use the `SkipStartedInfoEvent` option to specify whether "Script started" information events should be generated for the subscripts or not.

Up to now, this `SkipStartedInfoEvent` option would by default be set to false. From now on, it will by default be set to true.
