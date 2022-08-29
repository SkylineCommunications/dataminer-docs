---
uid: DIS_2.16
---

# DIS 2.16

## New features

### IDE

#### Table editor now also allows 'RTDisplay' settings to be edited \[ID_20200\]

In the table editor, it is now also possible to edit "RTDisplay" settings.

- In the *Options* section, you can enable or disable the RTDisplay setting on table level.
- In the *All Columns* section, you can enable or disable RTDisplay settings on column level.

When you enable or disable the RTDisplay setting of a particular table parameter, a pop-up window will appear, asking whether you also want to enable or disable the RTDisplay settings of all columns of that parameter.

Also, in the *Tables* list on the left, warning icons will now appear next to table parameters with configuration errors.

#### DIS will now be using Microsoft .NET Framework 4.6 \[ID_21320\]

From v2.16 onwards, DIS will be using Microsoft .NET Framework 4.6 to be able to support debugging (DIS Inject) as from DataMiner 9.6.4.

> [!NOTE]
> In DataMiner 9.6.4, Automation scripts require Microsoft .NET Framework 4.6 while QActions still require Microsoft .NET Framework 4.5.

### Validator

#### New and updated checks and error messages \[ID_20432\]\[ID_21330\]\[ID_21341\]\[ID_21392\]\[ID_21393\]\[ID_21394\]\[ID_21435\]\[ID_21455\]

The following checks and error messages have been added or updated.

| ID     | Check                         | Error message                                                                                                             |
|--------|-------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| 1.2.6  | CheckNameTag                  | Protocol Name 'oldProtocolName' changed into 'newProtocolName'.                                                           |
| 1.17.1 | CheckDatabaseOptionsAttribute | Partitioned trending was enabled on protocol.                                                                             |
| 2.1.12 | CheckIdAttribute              | Missing displayed Param. Param Name 'paramName'. Param Type 'paramType'. Param ID 'paramId'.                              |
| 2.2.9  | CheckNameTag                  | Logger table column name 'oldColumnName' for column PID 'columnPid' on table 'tablePid' was changed into 'newColumnName'. |
| 2.11.1 | CheckRangeTag                 | Missing tag 'Range' in Param 'paramId'.                                                                                   |
| 2.11.2 | CheckRangeTag                 | Excessive tag 'Range' in Param 'paramId'.                                                                                 |
| 2.17.5 | CheckOptionsAttribute         | Database link for logger table 'paramId' was removed.                                                                     |
| 2.21.4 | CheckOptionsAttribute         | HeaderTrailerLink option should be defined on headerOrTrailer with PID 'paramId'.                                         |
| 2.21.5 | CheckOptionsAttribute         | HeaderTrailerLink option is wrongly defined on headerOrTrailer with PID 'paramId'.                                        |
| 2.21.6 | CheckOptionsAttribute         | HeaderTrailerLink option should not be defined on Param 'paramId' as it is nor a header nor a trailer.                    |
| 2.21.7 | CheckOptionsAttribute         | HeaderTrailerLink with ID 'linkId' defined on more than 1 headerOrTrailer. PIDs paramIds.                                 |
| 2.22.1 | CheckPageTag                  | Parameter 'paramId' was removed from page 'pageName'.                                                                     |
| 2.23.1 | CheckTypeAttribute            | Normalization with Alarm type 'alarmType' on Param 'paramId' was removed.                                                 |
| 2.23.2 | CheckTypeAttribute            | Normalization with Alarm type 'alarmType' on Param 'paramId' was changed into 'newAlarmType'.                             |
| 2.23.3 | CheckTypeAttribute            | Normalization with Alarm type 'normalizationType' on Param 'paramId' was added.                                           |
| 2.24.1 | CheckMonitoredTag             | Alarming for Parameter 'paramId' was removed.                                                                             |
| 2.25.1 | CheckIdxAttribute             | IDX 'oldIdx' of column with PID 'columnPid' on table 'tablePid' was changed into 'newIdx'.                                |
| 2.26.1 | CheckPartialAttribute         | Partial Table option was enabled on table 'paramId'.                                                                      |
| 2.27.1 | CheckLoggerTable              | Column with PID 'columnPid' was removed from logger table 'tablePid'.                                                     |
| 2.28.1 | CheckColumnDefinitionTag      | Database type 'oldType' for columns on table 'tablePid' was changed into 'newType'.                                       |
| 2.29.1 | CheckHistorySetAttribute      | HistorySet attribute was enabled on Parameter 'paramId'.                                                                  |
| 2.30.1 | CheckTypeTag                  | Trend Type 'oldTrendType' on Parameter 'paramId' was changed into 'newTrendType'.                                         |
| 2.31.1 | CheckOptionsAttribute         | Displayed column order with IDX's 'oldColumnOrder' in table 'paramId' was changed to 'newColumnOrder'.                    |
| 2.32.1 | CheckLowTag                   | Low range 'previousValue' in Param 'paramId' increased to 'newValue'.                                                     |
| 2.32.2 | CheckLowTag                   | Low range 'newValue' in Param 'paramId' was added.                                                                        |
| 2.33.1 | CheckHighTag                  | High range 'previousValue' in Param 'paramId' decreased to 'newValue'.                                                    |
| 2.33.2 | CheckHighTag                  | High range 'newValue' in Param 'paramId' was added.                                                                       |
| 2.34.1 | CheckOptionsAttribute         | Threshold with value 'oldValue' on Param 'paramId' was changed into 'newValue'.                                           |
| 2.34.2 | CheckOptionsAttribute         | Threshold with value 'newValue' was added to Param 'paramId'.                                                             |
| 2.34.3 | CheckOptionsAttribute         | Threshold with value 'oldValue' was removed from Param 'paramId'.                                                         |
| 2.35.1 | CheckColumnOptionTag          | Column with PID 'columnPid' was removed from table 'tablePid'.                                                            |
| 2.8.1  | CheckTrendingAttribute        | Trending on Param 'paramId' was disabled.                                                                                 |

> [!NOTE]
> Check 2.11.x replaces the legacy Validator return code 3602.

### XML Schema

#### UOM Schema: New units added \[ID_21125\]

The following units have been added to the UOM Schema:

- Threads
- Rack units
- Jobs
- cps (chips per second)

#### Protocol Schema: Updated element and attribute rules \[ID_21126\]\[ID_21250\]

The syntax rules for the following elements and/or attributes have been updated:

| Element/attribute                                           | Syntax rule                                         |
|-------------------------------------------------------------|-----------------------------------------------------|
| Protocol.Chains.SearchChain.Tabs.Tab@tablePid               | No longer needs to refer to a defined parameter ID. |
| Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field@columnPid | No longer needs to refer to a defined parameter ID. |
| Protocol.Params.Param.SNMP.TrapOID@setBindings              | Suggested value: “allBindingInfo”                   |

#### Action type 'power' has been changed to 'pow' \[ID_21127\]

The action type “power” has been changed to “pow”.

#### Types and base types changed to 32-bit integer \[ID_21129\]

The type of the following attributes is now “xs:int”:

| Attribute                                                                                                                             | Type        |
|---------------------------------------------------------------------------------------------------------------------------------------|-------------|
| Protocol.Params.Param.CRC.Type@byteOffset                                                                                             | xs:int      |
| Protocol.Params.Param.CRC.Type@off                                                                                                    | xs:int      |
| Protocol.Params.Param@pollingInterval                                                                                                 | xs:int (>0) |
| Protocol.VersionHistory.Branches.Branch.SystemVersions.<br>SystemVersion.MajorVersions.MajorVersion.MinorVersions.<br>MinorVersion@id | xs:int (>0) |
| Protocol.VersionHistory.Branches.Branch@id                                                                                            | xs:int (>0) |

The base type of the following types is now “xs:int”:

| Type               | Base type |
|--------------------|-----------|
| TimerTime          | xs:int    |
| TypePingInterval   | xs:int    |
| TypePortNumber     | xs:int    |
| TypePortRetryCount | xs:int    |
| TypePortSlowPoll   | xs:int    |

## Changes

### Enhancements

#### IDE - Display editor: Title labels more visible when using color theme 'Dark' \[ID_20667\]

When, in Visual Studio, you have selected the color theme “Dark”, then title labels like “Options” and “Filter” will now be more visible in the *Display Editor* window.

### Fixes

#### Problem loading a MIB file that contained tables \[ID_21508\]

When loading a MIB file that contained tables, in some cases, those tables were not detected.
