---
uid: MaintenanceSettings_xml
---

# MaintenanceSettings.xml

In the file *MaintenanceSettings.xml*, you can specify a number of general system settings.

- This file is located in the following folder:

    `C:\Skyline DataMiner\`

- Before you make changes to this file, always stop DataMiner. Restart DataMiner when your changes have been saved.

## Example

This is an example of a *MaintenanceSettings.xml* file:

```xml
<MaintenanceSettings>
  <AlarmSettings
      serviceTimeoutMode="displayTimeout"
      viewTimeoutMode="displayBoth">
    <AlarmsPerParameter recurring="true">60</AlarmsPerParameter>
    <Blinking blinkInterval="1000" blankInterval="200" enabled="true" />
    <MaxFreezeAlarms>1000</MaxFreezeAlarms>
    <MaxFreezeTime>60000000</MaxFreezeTime>
    <UseCreationTimeAsMainTime>true</UseCreationTimeAsMainTime>
    <AutoClear>true</AutoClear>
  </AlarmSettings>
  <AutoElementLock time="5000">TRUE</AutoElementLock>
  <BackupSettings method="takebackup">...</BackupSettings>
  <DMSRevision>
    <StartTime>00:00:00</StartTime>
    <StartTime>12:00:00</StartTime>
    ...
  </DMSRevision>
  <Documents>
    <MaxSize>20</MaxSize>
  </Documents>
  <Logging>
    <MaxSize>10</MaxSize>
  </Logging>
  <ProtocolSettings>
    <ExecutionVerification timeout="5000">True</ExecutionVerification>
  </ProtocolSettings>
  <RecycleBinSize>50</RecycleBinSize>
  <Spectrum>
    <AlarmRecordings maxDirSize="500" />
  </Spectrum>
  <Surveyor>
    <ViewStatistics>[#TotalAlarms] Active Alarms</ViewStatistics>
    <ServiceStatistics>[#TotalAlarms] Active Alarms</ServiceStatistics>
    <ElementStatistics>[#TotalAlarms] Active Alarms</ElementStatistics>
  </Surveyor>
  <SLNet>...</SLNet>
  <Trending>
    <EDCurves></EDCurves>
    <SDCurves></SDCurves>
    <TimeSpan1HourRecords window="60" />
    <TimeSpan5MinRecords window="5" />
    <WarningLevel></WarningLevel>
  </Trending>
  <WatchDog>
    <EMail active="FALSE" />
    <TimeoutTime>5</TimeoutTime>
    <Errors>2</Errors>
    <Actions restartElementOnProtocolRTE="true">Alarm;switch</Actions>
    <FailoverOnRTE>
      <SkipRTE process="SLDataMiner.exe" thread="Database Offload Thread [local]" />
      <SkipRTE process="SLDataMiner.exe" thread="Database cleaning" />
    </FailoverOnRTE>
  </WatchDog>
  <Network bitRateTracking="true"/>
</MaintenanceSettings>
```

## Alphabetical overview of settings

Below is an alphabetical overview of settings that can be specified in the *MaintenanceSettings.xml* file.

### Aggregation.Source

This tag contains one attribute, *ignoreExceptionValues*. If this attribute is set to *"true"*, all aggregation rules in the DMS will by default ignore parameter exception values. If the attribute is set to *"false"* or if it is not specified, then by default exception values will be taken into account.

Example:

```xml
<MaintenanceSettings>
  ...
  <Aggregation>
    <Source ignoreExceptionValues="true"></Source>
  </Aggregation>
  ...
</MaintenanceSettings>
```

> [!NOTE]
> This setting can also be configured on rule level instead of system level, in which case the rule-level configuration takes priority. See [Aggregation](xref:Aggregation).

### AlarmSettings

In this tag, you can add the following attributes to control how timeout alarms are visualized in Microsoft Visio shapes:

- **serviceTimeoutMode**, with the following possible values:

  | Value | Description |
  |--|--|
  | displayTimeout | Shapes linked to services will only show the timeout color. The current alarm color will not be shown. |
  | displayBoth | Shapes linked to services will show both the current alarm color and the timeout color (default setting). The timeout color will be shown as a hatch pattern. |

- **viewTimeoutMode**, with the following possible values:

  | Value | Description |
  |--|--|
  | displayTimeout | Shapes linked to views will only show the timeout color. The current alarm color will not be shown. |
  | displayBoth | Shapes linked to views will show both the current alarm color and the timeout color (default setting). The timeout color will be shown as a hatch pattern. |

- **elementTimeoutMode** (available from DataMiner 10.2.0/10.1.6 onwards), with the following possible values:

  | Value | Description |
  |--|--|
  | displayTimeout | Shapes linked to elements/parameters will only show the timeout color. The current alarm color will not be shown. This is the default setting. |
  | displayBoth | Shapes linked to elements/parameters will show both the current alarm color and the timeout color. The timeout color will be shown as a hatch pattern. |

### AlarmSettings.AlarmsPerParameter

The value of the *AlarmsPerParameter* tag determines the maximum number of alarms that can be included in an alarm tree. If there are more alarms in an alarm tree, by default a notice will be displayed in the Alarm Console.

> [!NOTE]
>
> - SLNet limits the alarm trees in the cache and in history queries based on this tag. If no value is specified in this tag, SLNet uses a default of 20. In addition, because in old DataMiner versions the default was 100, if the value in this tag is 100, SLNet will read it as 20 instead.
> - SLDataMiner is responsible for generating notices if there are too many alarms in an alarm tree. If no value is specified in this tag, SLDataMiner uses a default of 100.

This tag can also have the following attributes:

- **client**: Determines how many alarms in an alarm tree are saved in the Cube cache. This determines how many alarms are shown in Cube when you view the alarm tree in a new tab, when you reconnect to Cube, or when you restart the element.

- **recurring**:

  | Value | Description |
  |--|--|
  | true | An “Alarm history exceeded XXX alarms” notice will appear in the Alarm Console **every time** the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. (Default setting.) |
  | false | An “Alarm history exceeded XXX alarms” notice will appear in the Alarm Console **the first time** the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. |
  | disabled | An “Alarm history exceeded XXX alarms” notice will **never** appear in the Alarm Console when the number of alarms in an alarm tree exceeds the AlarmsPerParameter setting. |

For example:

```xml
<AlarmsPerParameter recurring="TRUE" client="30">60</AlarmsPerParameter>
```

### AlarmSettings.Blinking

The *Blinking* tag can be used to make elements, services and views blink in DataMiner Cube if they have an alarm of which nobody has taken ownership.

It has three required attributes:

| Attribute | Description |
|--|--|
| enabled | Whether the Blinking feature is activated or not. Possible values: true/false |
| blinkInterval | The number of milliseconds the item (icon, card header, alarm in Alarm Console, etc.) is shown. Default: 1000 |
| blankInterval | The number of milliseconds the item (icon, card header, alarm in Alarm Console, etc.) is hidden. Default: 200 |

> [!NOTE]
>
> - For optimal effect, the blankInterval should be less than the blinkInterval.
> - There are also several optional filter attributes to enable blinking of alarms based on certain conditions. For more information, see [Making alarms without owner blink](xref:Making_alarms_without_owner_blink).

### AlarmSettings.MaxFreezeAlarms & AlarmSettings.MaxFreezeTime

In the *AlarmSettings* tag, you can specify the following Alarm Console freeze settings:

- In the *MaxFreezeTime* subtag, you can specify the maximum period of time the Alarm Console can stay frozen (in milliseconds). Default: 60000000 milliseconds (i.e. 1000 minutes)

- In the *MaxFreezeAlarms* subtag, you can specify the maximum number of alarms that will be kept in the alarm buffer when the Alarm Console is frozen. Default: 1000 alarms

As soon as either *MaxFreezeTime* or *MaxFreezeAlarms* is reached, the Alarm Console will automatically be unfrozen.

### AlarmSettings.MustSquashAlarms

The *MustSquashAlarms* tag is used to enable (*true*) or disable (*false*) alarm consolidation by default. If this is enabled, consecutive alarm events without a severity change will be combined into a consolidated event in the DataMiner client software. This may be useful to reduce the load on DataMiner Cube and on the SLNet process.

The following types of alarm events will not be combined in a consolidated alarm event:

- Escalated
- Dropped
- New Alarm
- Cleared
- Dropped From Critical
- Dropped From Major
- Dropped From Minor
- Dropped From Warning
- Escalated From Warning
- Escalated From Minor
- Escalated From Major
- Flipped

> [!TIP]
> See also: [Alarm trees](xref:Alarm_trees)

### AlarmSettings.PersistParameterLatchState

From DataMiner 10.4.9/10.5.0 onwards<!--RN 39495-->, parameter latch states are not persistent by default. This means they will reset after every DataMiner restart.

To enable persistent parameter latch states, add the following tags and values in *MaintenanceSettings.xml*:

```xml
<AlarmSettings>
   <PersistParameterLatchState>true</PersistParameterLatchState>
</AlarmSettings>
```

> [!NOTE]
> From DataMiner 10.4.9/10.5.0 onwards<!--RN 39495-->, if this tag has not been added to the *MaintenanceSettings.xml* file, or if the `PersistParameterLatchState` option is set to "false", parameter latch states will not be written to or fetched from the database.

### AlarmSettings.UseCreationTimeAsMainTime

The default value of the *UseCreationTimeAsMainTime* tag is "false".

### AlarmSettings.AutoClear

If you set *AutoClear* to "false", alarms will not be cleared automatically. Instead, they will get into a "clearable" state, and someone will have to manually clear them.

Default: true

### AutoElementLock

When you activate this system-wide setting, an element will automatically be locked when a parameter set is performed on it by a user who is allowed to lock and unlock elements.

To activate this setting, do the following:

1. Set the value of the AutoElementLock tag to TRUE.

1. Set the automatic unlock delay in the time attribute (default: 5000 ms).

A locked element will automatically be unlocked

- after 5 seconds (default setting), or

- when the client disconnects.

> [!NOTE]
> If the element is already locked, DataMiner will not automatically force unlock it. In that case, the user has to do this manually.

### BackupSettings

Used to enforce a backup package mechanism on machines running an operating system prior than Windows Server 2008 (no longer supported).

### DeltCache

Every time a .dmimport package is exported from or imported onto a DataMiner Agent, it is stored in the `C:\Skyline DataMiner\System Cache\DELT\` folder of that DataMiner Agent. The cleanup instructions for this folder are configured within the *\<DeltCache>* tag.

> [!NOTE]
>
> - DELT stands for *DataMiner Element Location Transparency*. It is the feature that allows the exporting and importing of packages as well as migration of elements across DMAs in a cluster.
> - If no cleanup instructions are configured in *MaintenanceSettings.xml*, by default only the 20 most recent packages will be kept.

#### Syntax

The *\<DELTCache>* tag and its subtags use the following syntax:

```xml
<DELTCache activated="<true or false>">
  <DELTCacheMode mode="<clean-up mode>" value="<value>"/>
</DELTCache>
```

#### Cleanup modes

In a *\<DELTCacheMode>* tag, you can specify one of three cleanup modes:

| Mode | Description |
|--|--|
| CleanupKeepRecentPackages | Use this mode if you want all .dmimport packages deleted except the X most recent ones. If, for instance, you add a *\<DELTCacheMode>* tag in which you set the *mode* attribute to “CleanupKeepLastPackages” and the *value* attribute to 5, then after each import or export operation, DataMiner will delete all packages except the 5 most recent ones. |
| CleanupLargerThan | Use this mode if you want all .dmimport packages deleted that are larger than a specific number of bytes. If, for instance, you add a *\<DELTCacheMode>* tag in which you set the *mode* attribute to “CleanupLargerThan” and the *value* attribute to 2099200, then after each import or export operation, DataMiner will delete all packages larger than 2 MB. |
| CleanupOlderThan | Use this mode if you want all .dmimport packages deleted that were created prior to a specific date and time. If, for instance, you add a *\<DELTCacheMode>* tag in which you set the *mode* attribute to “CleanupOlderThan” and the *value* attribute to “11-07-2016 12:00”, then after each import or export operation, DataMiner will delete all packages that were created before that time. |

#### Example 1

If you specify the following cleanup condition, after each import or export operation, DataMiner will delete all packages except the 4 most recent ones.

```xml
<DELTCache activated="true">
  <DELTCacheMode mode="CleanupKeepRecentPackages" value="4"/>
</DELTCache>
```

#### Example 2

In the following example, three cleanup conditions have been specified.

When you specify multiple conditions, they will be combined into one expression using OR operators. In other words: a package will be deleted as soon as one of the conditions match.

```xml
<DELTCache activated="true">
  <DELTCacheMode mode="CleanupKeepRecentPackages" value="4"/>
  <DELTCacheMode mode="CleanupLargerThan" value="2099200"/>
  <DELTCacheMode mode="CleanupOlderThan" value="2016-04-25 00:00"/>
</DELTCache>
```

### DELTUpgrades

This tag allows you to configure the automatic cleanup of DELT-related packages in the folder `C:\Skyline DataMiner\Upgrades\`.

The tag contains a number of *\<Delete>* subtags, which each specify a particular deletion mode with a *mode* attribute and a corresponding value with a *value* attribute.

| mode attribute | value attribute |
|--|--|
| CleanupKeepRecentPackages | The X most recent packages that have to be kept. |
| CleanupLargerThan | The maximum size (in bytes) of the files that are allowed in the *Upgrades* folder. |
| CleanupOlderThan | The oldest timestamp of the files that are allowed in the *Upgrades* folder. |
| CleanupAll | N/A |

Example:

```xml
<DELTUpgrades activated="true">
  <Delete mode="CleanupKeepRecentPackages" value="4"/>
  <Delete mode="CleanupLargerThan" value="2099200"/>
  <Delete mode="CleanupOlderThan" value="2016-04-25 00:00"/>
  <Delete mode="CleanupAll" />
</DELTUpgrades>
```

### DMSRevision

In this tag, you can specify when a double check has to be done. You can specify as many starting times as you want.

Default: Only at 00:00:00

### Documents.MaxSize

In this *MaxSize* tag, you can specify the maximum size of the documents in the Documents module.

Default: 20 MB

### Filtering.SlElement

The order of operations in a table filter of type "fullFilter" (used in protocols and in the web services) can be determined by means of parentheses, e.g. “*fullfilter=PK \>= 0 AND (101 == 10 OR 101 \> 20) AND (205 EXACT Service)*”.

However, in case you encounter issues with such filters because of this new filtering parsing behavior, it is possible to return to the previous behavior by adding the following tags and values in *MaintenanceSettings.xml*:

```xml
<Filtering>
  <SLElement fallback="true" />
</Filtering>
```

### HTTPS

See [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer).

### Logging.MaxSize

In this *MaxSize* tag, you can specify the maximum log file size.

Default: 10 MB

### Network.bitRateTracking

With the *bitRateTracking* tag, you can enable or disable the bitrate calculations performed by SLProtocol.

| Value | Description |
|--|--|
| true | SLProtocol's bitrate calculations are enabled. (Default setting.) |
| false | SLProtocol's bitrate calculations are disabled. |

> [!NOTE]
> Disabling this setting will halt updates to the *Communication Info* table on the *General parameters* page. Bitrate-related notifies such as [NT_GET_BITRATE_DELTA](xref:NT_GET_BITRATE_DELTA) will not be usable by connectors.

For example:

```xml
<Network bitRateTracking="true"/>
```

### ProtocolSettings.DCF.CalculateAlarmState

From DataMiner 10.2.0 [CU4]/10.2.1 onwards, you can use this setting to enable or disable DCF interface state calculation on system level.

You can overrule the setting in a protocol, by setting the Protocol.ParameterGroups.Group@calculateAlarmState attribute to true or false.

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
  <ProtocolSettings>
    <DCF>
      <CalculateAlarmState>false</CalculateAlarmState>
    </DCF>
  </ProtocolSettings>
</MaintenanceSettings>
```

### ProtocolSettings.ExecutionVerification

With the *ExecutionVerification* tag, you can enable or disable the parameter update verification feature.

If you enable this feature, DataMiner will check all parameter updates that are executed either via DataMiner client applications or SNMP set commands, and return the result of each check in the form of an information event.

Default timeout: 30000 milliseconds

> [!NOTE]
> In a DataMiner protocol, you can also specify update verification settings on parameter level. See [Protocol.Params.Param](xref:Protocol.Params.Param).

### RecycleBinSize

In this tag, you can specify the maximum size (in MB) of the DataMiner recycle bin.

From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, the system checks every 7 minutes whether storage limits have been exceeded. If the system detects a breach, it performs a cleanup on the recycle bin to restore the storage within acceptable limits. The cleanup continues until both of the following conditions are met:

- The folder size is below the set limit (default: 100 MB).

- The number of files is below the set limit (default: 1000).

If either of these conditions is breached, the system will continue to clean up until the folder size is within the configured limit and the number of files is reduced to 80% of whichever number is lower: the maximum allowed number of files or the current number of files at the time of cleanup.

Examples:

- In a system with a limit of maximum 1000 files, there are 1010 files, so the file limit is exceeded, but the folder size is still within the limit. In this case, The system will clean up until only 80% of the maximum allowed number of files remain (i.e. 80% of 1000 = 800 files). Since 210 files are deleted, the folder size will automatically decrease as well.

- In a system with a limit of maximum 1000 files, there are 600 files, but a large file has caused the folder size to exceed the limit (i.e. 105 MB while the limit is 100 MB). In this case, the system will clean up until only 80% of the current number of files remain (i.e. 80% of 600 = 480 files). If necessary, the system will continue the cleanup process until the folder size is within the configured size limit of 100 MB.

This cleanup occurs for the first time two minutes after DataMiner startup. Prior to DataMiner 10.5.5/10.6.0, the recycle bin is cleaned to the maximum size and number of files every hour.

> [!NOTE]
>
> - Whatever the maximum size specified in this tag, the maximum number of files in the recycle bin is limited to 5000.
> - The default recycle bin size is 100 MB.
> - From DataMiner 10.5.5/10.6.0 onwards<!--RN 40565-->, if the recycle bin size is set to 0 MB or an invalid size, it will revert to the default value of 100 MB.

### Replication.ConnectionMinDelayBeforeRetry

When a DataMiner Agent fails to set up a connection to another DataMiner Agent for replication purposes, further attempts to set up a connection are blocked during a fixed time interval. By default, this interval is set to 60 seconds. In this tag, it is possible to customize the time interval.

Example:

```xml
<MaintenanceSettings>
  <Replication>
    <ConnectionMinDelayBeforeRetry>
      60
    </ConnectionMinDelayBeforeRetry>
    ...
  </Replication>
  ...
</MaintenanceSettings>
```

> [!NOTE]
>
> - If you change this setting, it will only be applied after a DMA restart.
> - This setting is not synchronized among DataMiner Agents in a DMS.

### SLASPConnection.ReportResponseTimeout

In this tag, you can customize how long the SLASPConnection process has to wait for a report to respond. The tag has to contain a number of minutes. If it contains “0” or if the tag cannot be found, then the default timeout is 60 minutes.

Example:

```xml
<MaintenanceSettings
 xmlns="http://www.skyline.be/config/maintenancesettings">
  <SLASPConnection>
    <ReportResponseTimeout>60</ReportResponseTimeout>
  </SLASPConnection>
</MaintenanceSettings>
```

When the DMA is started, the following line in the SLASPConnection log file mentions this setting:

```txt
2015/02/09 09:01:22.020|SLASPConnection.exe 8.5.1451.1|6828|17292|CServiceModule::ReadMaintenanceSettings|DBG|5|ReportResponseTimeout set to 60 minutes (configurable in maintenance settings).
```

> [!NOTE]
> If this setting is adjusted, the report’s ASP page also has to be able to run for the modified period of time. This can be configured in IIS or in the ASP file itself, using “Server.ScriptTimeout = 3600;”. In long reports it is also advisable to force sending out the data in packets using “Response.Flush();”.

### SLASPConnection.TimeLineCache

In the *TimeLineCache* tag, you can specify options for the caching of timeline data in the SLASPConnection process.

The following attributes can be configured:

| Attribute | Description |
|--|--|
| enabled | Can be set to “true” or “false” in order to enable or disable timeline caching. |
| expirationTime | A value in seconds (by default 300 seconds). Determines how long an entry remains in the cache. |
| gracePeriod | A value in seconds (by default 60 seconds). When Reporter has detected a change in the timeline data, the cached data will still be removed after this duration. |
| logVerbose | Can be set to “true” or “false” in order to enable or disable additional logging in the *SLASPConnection.txt* log file indicating whether a timeline request was resolved from the database or from the cache. |
| maxRecord | The maximum number of trend records in the cache, by default 1000000. Older entries will be removed to make room for new entries. |

> [!NOTE]
> These settings are not synchronized among the Agents in a DMS.

### SLNet

In this tag, you can specify a number of settings of the SLNet application.

For more information, see [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml)*.*

### Spectrum.AlarmRecordings

In the *AlarmRecordings* tag, you can specify the maximum size (in MB) of the `C:\Skyline DataMiner\Spectrum Alarm Recordings` folder.

Default: 250 MB

> [!NOTE]
> This setting applies to one DataMiner Agent only. It is not synchronized to other Agents in the cluster.

### Surveyor

In this tag, you can specify which statistical alarm data and/or ticket data you want to have displayed next to elements, services and views in the Surveyor.

For more information, see [Displaying alarm statistics in the Surveyor](xref:Displaying_alarm_statistics_in_the_Surveyor) and [Displaying ticket statistics in the Surveyor](xref:Displaying_ticket_statistics_in_the_Surveyor).

### Trending.EDCurves

This deprecated tag was used to specify the maximum number of trend graphs that could be loaded simultaneously in Element Display.

> [!NOTE]
> The Element Display client application is no longer available from DataMiner 9.6.0 onwards.

### Trending.SDCurves

This deprecated tag was used to specify the maximum number of trend graphs that could be loaded simultaneously in System Display.

> [!NOTE]
> The System Display client application is no longer available from DataMiner 9.6.0 onwards.

### Trending.TimeSpan1DayRecords

In the *TimeSpan1DayRecords* tag, you can customize the interval of the 1-day "average trending" records. To do so, specify a *window* attribute value in minutes.

By default, this is not included. If you do include this tag, make sure to not set it to "0", as this configuration is invalid and would lead to issues.

> [!NOTE]
> If you are looking to configure how long these records need to be stored, see [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml).

### Trending.TimeSpan1HourRecords

In the *TimeSpan1HourRecords* tag, you can customize the interval of the 1-hour "average trending" records to be something other than the default 1 hour. To do so, specify a *window* attribute value in minutes.

> [!NOTE]
> If you are looking to configure how long these records need to be stored, see [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml).

### Trending.TimeSpan5MinRecords

In the *TimeSpan5MinRecords* tag, you can customize the interval of the 5-minute "average trending" records to be something other than the default 5 minutes. To do so, specify a *window* attribute value in minutes.

> [!NOTE]
> If you are looking to configure how long these records need to be stored, see [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml).

### Trending.WarningLevel

**Obsolete**

This tag was used in older DataMiner versions to configure a trending warning message in the now obsolete Element Display and System Display applications.

### WatchDog

In this tag, the settings of the DataMiner WatchDog process are specified. This process monitors other DataMiner processes and takes action when a process disappears or an anomaly is detected.

You can configure Watchdog to:

- Initiate a Failover switch in case of a runtime error, by specifying the value "switch" in the tag. Optionally, to exclude certain threads from initiating a Failover switch, add the *\<FailoverOnRTE>* subtag and specify the threads in *\<SkipRTE>* subtags.

    > [!NOTE]
    >
    > - If a Failover switched is launched, the DMA is then also restarted in order to ensure that it frees the virtual IP address. Before the restart is initiated, the DMA is marked as "offline".
    > - If DataMiner Watchdog is set to initiate a Failover switch in case of a runtime error, it will even do so if the Failover type is set to "Manual" in the Failover settings.

- Initiate an element restart in case of a runtime error on an element-related SLProtocol thread, by adding the attribute *restartElementOnProtocolRTE*, and setting it to *true*.

> [!NOTE]
>
> - To make these changes to *MaintenanceSettings.xml* take effect, after you have saved the file, stop the DMA, manually stop the SLWatchdog service, and then restart the DMA.
> - If DataMiner Watchdog is set to initiate both a Failover switch and an element restart, then the latter takes precedence. No Failover switch will be initiated when the element restart succeeds.

In the *ProcessMonitor.Crashdumps* subtag, you can customize how long crashdump packages created by the Watchdog process are kept. This can for instance be useful to prevent situations where the crashdump packages take up too much disk space. The following subtags can be configured:

| Tag                           | Attribute     | Description                                                               | Default |
|-------------------------------|---------------|---------------------------------------------------------------------------|---------|
| LowDumps                      | maxDaysToKeep | Maximum number of days a low memory dump will be kept.                    | 60      |
|                               | minToKeep     | Minimum number of low memory dumps kept.                                  | 0       |
|                               | maxToKeep     | Maximum number of low memory dumps kept.                                  | 100     |
| HighDumps                     | maxDaysToKeep | Maximum number of days a high memory dump will be kept.                   | 30      |
|                               | minToKeep     | Minimum number of high memory dumps kept.                                 | 0       |
|                               | maxToKeep     | Maximum number of high memory dumps kept.                                 | 10      |
| RequestDumps                  | maxDaysToKeep | Maximum number of days a manual memory dump will be kept.                 | 7       |
|                               | minToKeep     | Minimum number of manual memory dumps kept.                               | 0       |
|                               | maxToKeep     | Maximum number of manual memory dumps kept.                               | 10      |
| TempFolders                   | maxDaysToKeep | Maximum number of days a temporary folder (incomplete dump) will be kept. | 7       |
|                               | minToKeep     | Minimum number of temporary folders (incomplete dumps) kept.              | 0       |
|                               | maxToKeep     | Maximum number of temporary folders (incomplete dumps) kept.              | 5       |
| MaxTotalCrashDumpFolderSizeGb | N/A           | Maximum size of the Logging/CrashDump folder.                             | 5       |

> [!NOTE]
>
> - If these tags are not specified, the default values will be used.
> - Customizing how long crashdump packages are kept does not require a DataMiner restart. However, these settings will only be applied once a crashdump package is created.

> [!TIP]
> See also: [SLWatchdog](xref:Configuration_of_DataMiner_processes#slwatchdog)
