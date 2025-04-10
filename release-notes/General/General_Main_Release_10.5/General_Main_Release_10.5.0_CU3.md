---
uid: General_Main_Release_10.5.0_CU3
---

# General Main Release 10.5.0 CU3 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU3](xref:Cube_Main_Release_10.5.0_CU3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU3](xref:Web_apps_Main_Release_10.5.0_CU3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### New NotifyProtocol call NT_CLEAR_PARAMETER can now be used instead of ClearAllKeys() [ID 42368]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

A new NotifyProtocol call *NT_CLEAR_PARAMETER* can now be used to clear tables and single parameters.

Up to now, in order to clear a table, you had to use the SLProtocol method `ClearAllKeys()`. That method would first retrieve all primary keys from the table using an *NT_GET_INDEXES* (NotifyProtocol 168) call, and when there was at least one primary key present, it would then perform an *NT_DELETE_ROW* (NotifyProtocol 156) call to remove all rows.

> [!NOTE]
> NT_CLEAR_PARAMETER* cannot be used to clear table columns.

#### SLAnalytics: Enhanced caching of DVE element information [ID 42555]

<!-- MR 10.5.0 [CU3] - FR 10.5.6 -->

A number of enhancements have been made with regard to the caching of DVE element information.

#### Cassandra Cluster: Enhanced performance when importing DELT packages [ID 42613]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

Because of a number of enhancements, overall performance has increased when importing DELT packages on systems with a database of type *Cassandra Cluster*, especially when those packages contain a large amount of trend data.

#### Enhanced performance when logging in using external authentication via SAML [ID 42668]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.5 [CU0] -->

Because of a number of enhancements, overall performance has increased when logging in using external authentication via SAML.

### Fixes

#### Problem with SLProtocol when a protocol version was overwritten while an element using that protocol version was starting up [ID 42344]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When a protocol version was overwritten while an element using that protocol version was starting up, in some cases, the SLProtocol process could stop working. Also, this could result in alarms like the following being generated:

`Unexpected Exception [Exception from HRESULT: 0x8004024C]: The element is unknown.`

#### Redundancy groups: Matrix parameter updates in a derived element would incorrectly not get applied in the source element (and vice versa) [ID 42598]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When, within a redundancy group, a matrix parameter in a derived element was updated, in some cases, that same matrix parameter would incorrectly not get updated in the source element (and vice versa).

#### Problem when starting an element with DCF connections towards a previously deleted element [ID 42632]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

When an element that had DCF connections towards a previously deleted element was started, in some cases, an "unhandled exception" notice could appear in the Alarm Console. Also, as a result of the exception, the element's connection information would not be available in SLNet and DataMiner Cube, and no connection lines would be displayed for the connections in question.

#### SNMP forwarding: Inconsistent messages in alarm storm information events [ID 42642]

<!-- MR 10.4.0 [CU15]/10.5.0 [CU3] - FR 10.5.6 -->

SNMP managers generate an information event each time an alarm storm starts and ends.

Up to now, the word "SNMP manager" would not be spelled consistently in both messages. The information event announcing the start of an alarm storm would start with `Alarmstorm for SNMP Manager: ...`, while the information event announcing the end of an alarm storm would start with `Alarmstorm for SNMPManager: ...`

From now on, both information events will start with `Alarmstorm for SNMP Manager: ...`
