---
uid: Get_alarms
---

# Get alarms

The *Get alarms* data source retrieves the alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value*, and *Time*, are included by default. Other columns, such as *Alarm ID* and *Root Alarm ID*, can be added with a [*Select* operation](xref:GQI_Select).

> [!NOTE]
> If your DataMiner System uses [self-managed storage with Cassandra but without an indexing database](xref:Separate_Cassandra_setup_without_Elasticsearch), we recommend always adding filtering on *Time*, as this filters directly on the database. Otherwise, the SLDataGateway process will fetch all alarms and then apply the filtering, which might take a lot of resources.

The content of the *Alarm ID* and *Root Alarm ID* columns may differ depending on your DataMiner version:

| Column | From DataMiner 10.4.11/10.5.0 onwards<!--RN 40372--> | Prior to DataMiner 10.4.11/10.5.0 |
|--|--|--|
| Alarm ID | DMAID/EID/RootAlarmID/AlarmID, e.g. `537/45/2184182/2184188` | HostingDMAID/AlarmID, e.g. `537/2184188` |
| Root Alarm ID | DMAID/EID/RootAlarmID, e.g. `537/45/2184182` | HostingDMAID/RootAlarmID, e.g. `537/2184182` |

In the table above, "DMAID" refers to the DataMiner ID of the DataMiner Agent where the element was originally created. "HostingDMAID" refers to the DataMiner ID of the DataMiner Agent currently hosting the element and managing its alarms. Most of the time, these two values will be the same, but they may differ, for example, when an element is exported from one Agent and imported onto another Agent. In this case, the element retains the original DMAID, but the HostingDMAID will reflect the new Agent's ID.
