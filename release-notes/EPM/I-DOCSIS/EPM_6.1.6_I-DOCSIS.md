---
uid: EPM_6.1.6_I-DOCSIS
---

# EPM 6.1.6 I-DOCSIS

## New features

#### New 'Other DOCSIS' KPI [ID_34346]

New aggregation operations were added to the hub, market, network, CCAP, service group, and node segment levels to register the number of CMs with a DOCSIS version other than DOCSIS 2.0, DOCSIS 3.0, or DOCSIS 3.1. The resulting KPI is displayed in the *Other DOCSIS* column.

#### Option to show/hide PNM on Node Segment map [ID_34387]

Both on the *Configuration* page of the Skyline EPM Platform element and in the front-end EPM visual overview, a toggle button is now available that can be used to show or hide the PNM layers on the Node Segment map.

#### Alarm color for total alarm statistics represented by colored circles in EPM visual overviews [ID_35451] [ID_35483]

For the total alarm statistics in the EPM visual overviews, colored circles will now be displayed that show the current alarm color. If there are no alarms, a gray color will be displayed, otherwise the color will reflect the alarm severity (critical, major, minor, or warning). This has been implemented by adding conditions to four circle shapes based on the total alarm statistics.

For the Skyline EPM Platform visual overview, the alarm statistics are shown both on the *Service Group [Fiber Node]* page and on the *CCAP* page. For the Skyline EPM Platform DOCSIS visual overview, they are located on the *CCAP* page. For the I-DOCSIS Network visual overview, they are shown on the *Overview* page.

#### Status parameter for CM QAM US/DS tables added [ID_35369]

The Status parameter present in the CM QAM US/DS tables in the Generic CM Collector has now been added to all CCAPs and to the EPM back end and front end. In the front end, a filter has also been added that only shows the active channels for a cable modem.

#### US QAM Channel Time Offset calculation updated [ID_35505]

The calculation of the Timing Offset for Upstream channels on a CCAP has been updated.

For DOCSIS v3, this is now calculated as follows: Time Offset = Upstream ticks * (6.25/(64*256)) * (97.6 / 1000).

For other DOCSIS versions, it is calculated as follows: Time Offset = Upstream ticks * (6.25/64) * (97.6 / 1000).

## Changes

### Enhancements

#### Maps with PNM layer moved to Node Segment layer [ID_34390]

The maps implementation with PNM layer has been moved from the Service Group layer to the Node Segment layer. Maps now retrieve data directly from the CCAP/collector elements instead of the front end.

#### Provisioning now by default enabled after back end restart [ID_34480]

When the back end was restarted, up to now, provisioning was disabled by default. Now it will be enabled by default. The Provisioning parameter is now also available on the Configuration page in Visual Overview.

#### Support for maps on passive levels [ID_35022]

Maps are now supported on the node segment, node, amplifier, and tap levels of the EPM topology.

#### Multi-threaded timer removed [ID_35034]

The CCAP Platform connectors will no longer use a multi-threaded timer to poll the DOCSIS version of each cable modem.

Because of this, a number of other changes have been implemented:

- The DOCSIS version column has been removed from the Cable Modems table, and aggregating actions based on this column have been moved to the Generic CM Collector connector. The column is now also no longer exported to the cable modem EC file.

- Alarm monitoring is now disabled on all columns of the CM QAM DS Channels table, CM QAM US Channels table, and Cable Modem table.

- QAction 7600, associated with the polling of the DOCSIS version of each cable modem available in the system, has been removed.

- The Threadpool page has been removed along with all its parameters, as these were associated with the multi-threaded timer.

#### Generic DOCSIS CM Collector: CM QAM Channels tables adjusted + SNMP interval logic removed from multi-threaded timer [ID_35292]

To avoid inconsistencies between the QAM DS/US Channels CM Collector table and CM QAM DS/US Channels CCAP tables, the latter will now contain all available channels per CM, and they will also contain a column indicating whether a channel is currently active or not.

In addition, SNMP interval logic has been removed from the multi-threaded timer, as this did not work as intended.

#### Visio drawings and dashboards included in EPM package [ID_35522]

In addition to the Automation scripts and connectors, the EPM application package now also includes the Visio drawings and dashboards available in the EPM I-DOCSIS Solution. Dashboards are included as companion files.

#### Resolving the invalid operation exception when updating connector [ID_35532]

When you update an EPM connector (e.g. the Skyline EPM Platform connector) with the SL.Lib.Common package 1.3.0.2 or above, a *System.InvalidOperationException* can be thrown. For example:

```txt
System.InvalidOperationException: Deserialization Failed for type: EpmData
   at Skyline.DataMiner.Library.Common.Serializing.NoTagSerializing.UsingJsonNewtonSoft.KnownTypesBinder.BindToType(String assemblyName, String typeName)
```

To resolve this, in the IEnumerable\<Type> knownTypes argument of *Skyline.DataMiner.Library.Common.InterAppCalls.CallBulk.InterAppCallFactory* methods, you should now specify all the types of the custom message that are added to the *Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle.Message* class.

### Fixes

#### Issues related to alarm in EPM Platform visual overview [ID_34449]

The following issues related to alarms could occur in the EPM Platform visual overview:

- On the Service Group level, the alarm tab in the EPM Platform visual overview did not show any alarms.
- Alarm statistics associated with the Service Group level could be incorrect.
- The alarm coloring of shapes could also be incorrect (e.g. minor alarms displayed with a green color instead of the correct light-blue color).

#### Arris E6000 CCAP Platform - Empty Node Segment table [ID_34461]

Because of an incorrect condition check, it could occur that the Node Segment table of the Arris CCAP connector did not get filled in. In addition, the export of the Node Segment EC file was not performed.

#### Exceptions thrown by CM Collector [ID_34472]

If the Generic DOCSIS CM Collector connector could not find the Passive Relation\\EP folder while parsing the SG file, an exception could be thrown.

#### Parameters based on system description not filled in in CCAP table [ID_34556]

In the CCAP table, it could occur that parameters based on the system description were not filled in.

#### QAM DS Channel: Missing decimals in MER and packet ratio columns [ID_34560]

Up to now, the MER and packet ratio columns for the QAM DS Channel did not show any decimals even when decimals were available for a particular KPI.

#### Incorrect DS/US Channel Utilization in Node Segment overview [ID_34623]

In the Node Segment overview, it could occur that the DS Channel Utilization showed the value for the US Channel Utilization and vice versa.

#### Percentage Ping OK value above 100% [ID_34726]

When the Number Ping OK parameter had a value larger than the number of CMs, the Percentage Ping OK parameter indicated a value above 100%. The percentage calculation has now been adjusted to prevent this. Exceptional cases like this will now be returned as -1 (N/A). Exception values were added to both the Percentage Ping OK and Percentage Ping Unreachable parameters in the amplifier and node overview tables.

#### Link to dashboard does not apply filter [ID_35207]

When a user clicked the dashboard icon, this opened a dashboard without applying a filter. Now a filter has been included in the dashboard link.

#### ArgumentNullException when CCAP tried to read information from files [ID_35294]

When the CCAP tried to read information from files, an "ArgumentNullException" could be thrown when it encountered a dictionary with null values. This has now been corrected.

#### Incorrect -1 values in Nodes, Amplifier Overview, and Subscribers Overview tables [ID_36197]

In the Nodes, Amplifier Overview, and Subscribers Overview tables, it could occur that the Node ID, Amplifiers ID, and Subscribers ID columns displayed the value "-1" where they were supposed to show "N/A".
