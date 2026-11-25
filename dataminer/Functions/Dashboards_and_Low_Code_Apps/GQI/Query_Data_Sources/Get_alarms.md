---
uid: Get_alarms
description: "Use the Get alarms data source to retrieve alarms from your DataMiner System and learn about default and optional columns in your GQI queries."
---

# Get alarms

The *Get alarms* data source retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value*, and *Time*, are included by default. Other columns, such as *Alarm ID* and *Root Alarm ID*, can be added with a [*Select* operation](xref:GQI_Select).

> [!NOTE]
> If your DataMiner System uses [self-managed storage with Cassandra but without an indexing database](xref:Separate_Cassandra_setup_without_Elasticsearch), we recommend always adding filtering on *Time*, as this filters directly on the database. Otherwise, the SLDataGateway process will fetch all alarms and then apply the filtering, which might take a lot of resources.

## Alarm ID and Root Alarm ID columns

The content of the *Alarm ID* and *Root Alarm ID* columns may differ depending on your DataMiner version:

| Column | From DataMiner 10.4.11/10.5.0 onwards<!--RN 40372--> | Prior to DataMiner 10.4.11/10.5.0 |
|--|--|--|
| Alarm ID | DMAID/EID/RootAlarmID/AlarmID, e.g., `537/45/2184182/2184188` | HostingDMAID/AlarmID, e.g., `537/2184188` |
| Root Alarm ID | DMAID/EID/RootAlarmID, e.g., `537/45/2184182` | HostingDMAID/RootAlarmID, e.g., `537/2184182` |

In the table above, "DMAID" refers to the DataMiner ID of the DataMiner Agent where the element was originally created. "HostingDMAID" refers to the DataMiner ID of the DataMiner Agent currently hosting the element and managing its alarms. Most of the time, these two values will be the same, but they may differ, for example, when an element is exported from one Agent and imported onto another Agent. In this case, the element retains the original DMAID, but the HostingDMAID will reflect the new Agent's ID.

## Alarm property columns

The way alarm property columns are linked to alarm properties depends on your DataMiner version.

From DataMiner Web 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards<!-- RN 45085 -->, property columns for alarms are linked to the underlying property by name. In earlier DataMiner versions, they are linked to the underlying property by ID. The adjusted behavior in recent DataMiner versions allows queries to be reused across DataMiner Systems where the same property can have a different ID.

When you upgrade to 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 or higher, existing queries that were created using earlier versions will continue to reference properties by ID to remain backwards-compatible. The existing property columns are marked as legacy columns in the query builder and can be updated manually when necessary.

## Alarm focus information

The following optional columns provide [alarm focus](xref:Alarm_focus) information: <!-- RN 47109 -->

- **Alarm likelihood**: The likelihood score assigned to the alarm. The value is displayed as a percentage (for example, `0.7` is displayed as `70%`); its underlying numeric value is between 0 and 1.
- **Is focus alarm**: Indicates whether the alarm is considered unexpected based on its likelihood. An alarm with a likelihood below 70% is a focus alarm.

Focus information is only available for active alarm trees. These columns are empty when no focus information is available, for example for inactive alarms or when the DataMiner server does not support retrieving focus events. Filtering *Is focus alarm* with `true`, or filtering *Alarm likelihood* with `=`, `<`, `>`, `<=`, or `>=`, only returns active alarms.
