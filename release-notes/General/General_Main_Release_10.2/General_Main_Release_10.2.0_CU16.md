---
uid: General_Main_Release_10.2.0_CU16
---

# General Main Release 10.2.0 CU16

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### System Center: Overhaul of LDAP settings [ID_35782]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.6 -->

In *System Center > System settings > LDAP*, you can configure a number of LDAP settings. These settings have had an overhaul.

- In the *General* tab, from now on, you will only be able to set *Authentication type* to either "Anonymous" or "Simple".

  > [!NOTE]
  > When you set *Authentication type* to "Anonymous", the *User name* and *Password* fields will now be disabled. When both fields contain a value, *Authentication type* will by default be set to "Simple".

- In this section, it is now also possible to configure the *nonDomainLDAP* setting. Up to now, this setting could only be configured in the *DataMiner.xml* file.

- When you update LDAP settings, a warning will now appear to notify you that these settings will only be changed on the DataMiner Agent to which you are connected. Changes made to LDAP settings will not be synchronized among the agents in the cluster.

Also, a number of issues have been fixed. Up to now, the value entered in *Use fully qualified domain name (FQDN)* would not be saved to the *DataMiner.xml* file, an incorrect default value would be entered in the *User class name* field, and the value entered in the *Password* field would get lost when the LDAP settings were updated without changing the password.

#### Failover: Obsolete CheckVIPs thread has been removed [ID_36253]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In Failover setups using virtual IP addresses, once every minute the CheckVIPs thread would check whether the online Agent holds the correct IP addresses. However, due to the many locks it claimed to verify the current state of the IP addresses, it would delay other actions being executed in the system.

This obsolete thread has now been removed.

#### DataMiner tasks in Windows Task Scheduler will now return 0 instead of error code 1 [ID_36393]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

The following scheduled tasks will now by default return 0 instead of error code 1.

- Skyline DataMiner Backup (DataMinerBackup.js)
- Skyline DataMiner Database Optimization (OptimizeDB.js)
- Skyline DataMiner LDAP Resync (ReloadLDAP.js)

#### SSH settings saved in parameters are now passed to SLPort together instead of separately [ID_36404]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you set up an SSH connection in a protocol, you can store the username, the password, the SSH options and the IP address in parameters using a `<Type options="">` element inside the `<Param>` element.

| Parameter          | Option                          |
|--------------------|---------------------------------|
| SSH username       | `<Type options="SSH USERNAME">` |
| SSH password       | `<Type options="SSH PWD">`      |
| SSH options        | `<Type options="SSH OPTIONS">`  |
| Dynamic IP address | `<Type options="DYNAMIC IP">`<br>Note: This value can also be used for other types of connections. |

Up to now, when an element with an SSH connection was started, these values would each be passed separately to SLPort. From now on, they will all be passed together to SLPort.

> [!NOTE]
> A separate set will be performed whenever one of the above-mentioned values is changed at runtime.

### Fixes

#### Cassandra Cluster: Every DMA would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS [ID_31923]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU3] - FR 10.3.3 -->

At start-up, every DataMiner Agent with a Cassandra Cluster configuration would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS.

From now on, at start-up, every DataMiner Agent with a Cassandra Cluster configuration will only delete the old Cassandra compaction and repair tasks found locally.

#### Alarm templates: Problem with anomaly detection alarms [ID_33216]

<!-- MR 10.2.0 [CU16] - FR 10.2.6 -->

When you created an element with an alarm template in which anomaly detection alarms were configured for table parameters, in some cases, none of the enabled types of change points would trigger an alarm.

#### DataMiner Cube - Resources app: Problem when opening the element list in the 'device' tab [ID_36239]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Resources* app, you created a resource and then opened the element list in the *device* tab in order to link a device to that newly created resource, in some cases, DataMiner Cube could become unresponsive, especially when the element list contained a large number of elements.

#### Business Intelligence: Secondary index of certain SLA logger tables would not be created correctly [ID_36245]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

The secondary index of certain SLA logger tables would not be created correctly. As a result, certain rows in those tables would not get cleaned up and exceptions like the following would be added to the *SLDBConnection.txt* log file:

```txt
SLDataGateway.Types.DBGatewayException: CassandraConnection ExecuteQuery - exception while executing query: SELECT "array_active_service_alarms_id","array_active_service_alarms_time" FROM ELEMENTDATA_7102_1334_750 WHERE "array_active_service_alarms_rootid" = '0/0'; - Cannot execute this query as it might involve data filtering and thus may have unpredictable performance. If you want to execute this query despite the performance unpredictability, use ALLOW FILTERING
```

When SLAs were stored in a Cassandra cluster, none of their rows would get cleaned up.

#### Dashboards app & Low-Code Apps: State component would incorrectly not be cleared when its input feed was cleared [ID_36261]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, a *State* component would incorrectly not be cleared when its input feed was cleared.

#### Low-Code Apps: Table actions would incorrectly be executed before the rows were fed [ID_36263]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, table actions would be executed before the rows were fed. As a result, the feed would get lost when you navigated away from the page via an action. From now on, a row will always be fed before row actions are executed.

#### Low-Code Apps: Custom icon of a low-code app without a draft version would not be displayed on the DataMiner landing page [ID_36277]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a low-code app with a custom icon did not have a draft version, the DataMiner landing page would incorrectly not display the icon of that app.

#### Dashboards app: Height of 'DATA USED IN DASHBOARD' section would incorrectly change after collapsing and expanding it [ID_36282]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you collapsed and expanded the *DATA USED IN DASHBOARD* section of the *DATA* tab, in some cases, the height of that section would incorrectly change.

#### Monitoring app: Surveyor items would be sorted incorrectly [ID_36303]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In the Surveyor of the Monitoring app, items of which the name contained a number would be sorted incorrectly. For example, *Element 2* would appear below *Element 11*. From now on, the items in the Surveyor of the Monitoring app will be sorted in the same way as those in the Surveyor of DataMiner Cube.

#### DataMiner Cube - Automation app: C# editor would incorrectly jump to the first line of code when saving a script [ID_36321]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Automation* app, you saved an Automation script after making changes to a C# code block, the C# editor would incorrectly jump to the first line of that code block. From now on, when you save an Automation script, the C# editor will jump to the last line of code that was changed.

#### DataMiner Cube - Visual Overview: Problem when opening an EPM card [ID_36323]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened an EPM card by clicking a shape that was linked to the EPM object via the *SystemName* and *SystemType* properties, in some cases, the card would be missing certain pages.

#### Exported DVE child protocols would no longer be set as production after re-uploading a main DVE protocol version used as production version [ID_36334]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you re-uploaded a main DVE protocol with the same version as the one that was being used as production version, the exported child protocols would incorrectly no longer be set as production.

#### DataMiner Cube - Spectrum analysis: Trace would no longer be updated when you restarted a spectrum element while its card was open [ID_36347]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you restarted a spectrum element while its card was open, the trace would no longer be updated. For the trace to get updated, you had to close the card and open it again. From now on, the trace will be updated as soon as the element has finished restarting.

#### DataMiner Cube - Visual Overview: Blinking shapes would affect other components [ID_36357]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, setting a shape to blink in Visual Overview could unintentionally affect other components. For example, when the parameter table contained monitored parameters, the monitored cells would incorrectly blink along with the shape.

From now on, when a shape is set to blink, other components will no longer be affected.

#### DataMiner Cube: Problem with 'Use credentials' selection box when creating or editing an element [ID_36362]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you selected the *Use credentials* option for an SNMPv1 or SNMPv2 connection while creating or updating an element, you would incorrectly not be required to select any predefined credentials. As a result, an error would occur when the element was created or the update was applied. From now on, when you select this option, the label will turn red and the *Create* or *Apply* button will be disabled as long as no credentials have been selected.

Also, when you edited an element for which credentials had been selected, the *Use credentials* selection box would be disabled and the *Get community string* and *Set community string* boxes would be enabled until you toggled the *Use credentials* option off and on again.

#### SNMP tables using the 'subtable' option no longer received any data when a single-value filter was applied [ID_36370]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a single-value filter was applied to an SNMP table using the `subtable` option, in some cases, the table would no longer receive any data.

Due to a filtering problem, using a single filter like "1.1" would no longer poll instances like "1.1" and "1.1.2". This has now been fixed.

Also, it is now possible to use a "\*" wildcard in a filter. See the following examples:

- "1.2" will accept values like "1.2.1" and "1.2.2", but will reject "1.3.1" and "2.2".
- "1.*" will accept values like "1.1" and "1.2.3", but will reject "1" and "2.1.2".
- "*.1" will accept values like "2.1" and "2.1.2", but will reject "1.1" and "1.2.1".

#### Dashboards app & Low-Code Apps - Table component: Columns with an action applied would not show a loading indication [ID_36376]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Table columns that had an action applied would incorrectly not show a loading indication. Instead, they would remain empty until the data was loaded.

#### DataMiner Cube : Reports and heatline of a monitored parameter of a DVE child element would incorrectly show "No monitoring" [ID_36384]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened the card of a DVE child element, drilled down to a monitored parameter and opened the *Details* tab, the reports would incorrectly show "No monitoring". Also, "No monitoring" would be shown when you viewed the heatline of the parameter in question.

#### Protocols: Setting the type of an advanced port to SNMPv3 would cause the advanced port settings to get lost [ID_36400]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, while editing an element using a (production) protocol with an advanced port of type SNMPv1 or SNMPv2, you set the type of the advanced port to SNMPv3, then the advanced port settings would get lost when the production version of the protocol was set to another version that also did not have SNMPv3 configured. Moreover, when you tried to correct the advanced port settings of the element, an error would occur in SLDataMiner as soon as you applied the changes.

#### Dashboards app & Low-Code Apps: A message would no longer be displayed when a component was being migrated [ID_36410]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

A message would incorrectly no longer be displayed when a component was being migrated to the most recent version. From now on, when a component is being migrated, a message showing the component icon and the text *Migrating...* will again be displayed.

#### Dashboards app: Problem when updating a query linked to a feed [ID_36414]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a dashboard contained a query component that was linked to a feed, the app could become unresponsive when the feed would send updates faster than the time it took to resolve the query.

#### DataMiner Cube: Problem when opening the alarm template of a large matrix parameter [ID_36444]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, Cube could become unresponsive when you tried to open the alarm template of a large matrix parameter.

#### Cube: Problem when trying to export all elements to a CSV file [ID_36512]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, the following exception could be thrown when you tried to export all elements to a CSV file:

`Export failed: Object reference not set to an instance of an object`
