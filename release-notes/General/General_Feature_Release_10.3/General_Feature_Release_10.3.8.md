---
uid: General_Feature_Release_10.3.8
---

# General Feature Release 10.3.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.8](xref:Cube_Feature_Release_10.3.8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.8](xref:Web_apps_Feature_Release_10.3.8).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### SLNetClientTest tool: New menu to manage the cloud connection of a DMA while it is offline [ID_36611]

<!-- MR 10.4.0 - FR 10.3.8 -->

In the *SLNetClientTest* tool, you can now go to *Offline tools > CcaGateway (offline)* to manage the cloud connection of the local DataMiner Agent while it is offline.

> [!WARNING]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### 'ExportRule' elements can now have a 'whereAttribute' attribute [ID_36622]

<!-- MR 10.4.0 - FR 10.3.8 -->

`ExportRule` elements can now have a `whereAttribute` attribute. This will allow you to validate the value of an attribute when applying an export rule.

See the following example. If the `includepages` attribute of the *Protocol.SNMP* element is true, the export rule will change that value to false in the exported protocol. Without the `whereAttribute`, the `whereValue` check would be performed on the value of the *Protocol.SNMP* element itself (which is mostly set to "auto") instead of the value of the `includepages` attribute.

```xml
<ExportRule table="*" tag="Protocol/SNMP" attribute="includepages" value="false" whereTag="Protocol/SNMP" whereAttribute="includepages" whereValue="true"/>
```

In this next example, all *Column* elements of parameters that have a `level` attribute that is set to 5 will have their value set to 2 in the exported protocol.

```xml
<ExportRule table="*" tag="Protocol/Params/Param/Display/Positions/Position/Column" value="2" whereTag="Protocol/Params/Param" whereAttribute="level" whereValue="5"/>
```

## Changes

### Enhancements

#### SLLogCollector now collects more API Gateway data [ID_34967]

<!-- MR 10.4.0 - FR 10.3.8 -->

SLLogCollector packages now include the following API Gateway data:

- *appsettings.json*
- DLL version
- Health
- Log file
- Version

#### SLAnalytics - Pattern matching: No automatic pattern matching anymore after creating or editing a pattern [ID_36265]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, when a trend pattern was created or edited, the system would automatically start searching for that new or updated pattern. Now, this will no longer happen. Pattern matching will only be done after explicitly sending a `getPatternMatchMessage`.

#### Security enhancements [ID_36294]

<!-- 36294: MR 10.3.0 [CU5] - FR 10.3.8 -->

A number of security enhancements have been made.

#### Service & Resource Management: Enhanced performance when creating and updating bookings [ID_36391]

<!-- MR 10.4.0 - FR 10.3.8 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings, especially on systems with a large number of overlapping bookings.

#### Service & Resource Management: Enhanced performance of GetEligibleResources call [ID_36430]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

Because of a number of enhancements, overall performance of the *GetEligibleResources* call has increased.

#### SLAnalytics: Overall accuracy of the proactive cap detection function has increased [ID_36476]

<!-- MR 10.4.0 - FR 10.3.8 -->

Because of a number of enhancements, overall accuracy of the proactive cap detection function has increased.

#### DataMiner Agents joining a cluster will now synchronize their ProtocolScripts\DllImport folder [ID_36494]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When a DataMiner Agent joins a cluster, it will now synchronize its `ProtocolScripts\DllImport` folder.

Also, when processing a protocol, a DataMiner Agent will now synchronize

- the files in the `ProtocolScripts/DllImport` folder, and
- the files in the folders mentioned in the *QAction@dllImport* attribute.

#### Cassandra: 'analytics_changepointalarmentries_v2' table renamed to 'ai_cpalarms' [ID_36503]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

In a *Cassandra Cluster* and an *Amazon Keyspaces* database, the `analytics_changepointalarmentries_v2` table has now been renamed to `ai_cpalarms`.

As this new table name is quite a bit shorter, for both types of databases, keyspace prefixes can now have a maximum length of 20 characters instead of 11 characters.

#### Stream Viewer will now display parameter IDs in decimal format instead of octal format [ID_36525]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Stream Viewer will display an error message when an SNMP poll group contained either an invalid parameter or a parameter that did not have its SNMP setting enabled.

Up to now, that error message would contain the ID of the parameter in octal format. From now on, it will contain the ID of the parameter in decimal format instead.

#### Enhancements in order to deal with situations where HTTP traffic is modified [ID_36540]

<!-- MR 10.4.0 - FR 10.3.8 -->

A number of enhancements have been made in order to deal with situations where proxy servers, gateways, routers or firewalls modify HTTP traffic.

#### Factory reset tool will no longer try to delete non-existing folders [ID_36550]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, the factory reset tool *SLReset.exe* would log an exception each time it had tried to delete a non-existing folder. From now on, when it has to delete a folder, it will first check whether that folder exists. If not, it will not try to delete it.

#### SNMP tables: Columns of type 'retrieved' can now be placed in between columns of type 'snmp' [ID_36559]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when an SNMP table had columns of type "retrieved" in between columns of type "snmp", problems could occur. All columns of type "retrieved" had to be grouped and placed at the right of the columns of type "snmp".

From now on, in an SNMP table, columns of type "retrieved" can be placed in between columns of type "snmp", providing the primary key column is a column of type "snmp" and not a column of type "retrieved".

#### Service & Resource Management: Enhanced performance [ID_36568]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

Because of a number of enhancements with regard to fetching LinkerTableEntries of function resources, overall performance has increased.

#### SLAnalytics - Automatic incident tracking: Alarms will no longer be regrouped after a manual operation [ID_36595]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, manually removing an alarm from an incident could result in that alarm being regrouped with another existing or newly created incident. Also when you manually cleared an incident could all base alarms of that incident be regrouped.

From now on, alarms will no longer be regrouped after a manual operation.

#### SLAnalytics - Automatic incident tracking: Automatic incidents can now also be cleared manually [ID_36600]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, users will be allowed to manually clear automatic incidents.

### Fixes

#### SLAnalytics: Incorrect trend predictions in case of incorrect data ranges set in the protocol [ID_36521]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

If, in the protocol, a data range is specified for a parameters for which trend data prediction is required, the trend prediction algorithm will cap the prediction values to the data range. For example, if a parameter has a rangeLow value equal to 0 and a rangeHigh value equal to 100, the prediction will not contain values lower than 0 or higher than 100.

From now on, if the trend data contains values outside of the specified data range, the trend prediction algorithm will no longer consider the data range values to be valid or reliable, and will not limit the prediction to this range.

#### SLNet would incorrectly return certain port information fields of type string as null values [ID_36524]

<!-- MR 10.4.0 - FR 10.3.8 -->

When element information was retrieved from SLNet, in some cases, certain port information fields of type string would incorrectly be returned as a null value instead of an empty string value. As a result, DataMiner Cube would no longer show the port information when you edited an element.

Affected port information fields:

- BusAddress
- Number
- PollingIPAddress
- PollingIPPort

#### Problem with protocol.SendToDisplay API call [ID_36528]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When the following protocol API call was used to update specific matrix crosspoints, in some cases, the API call could ignore the physical size of the matrix. Also, the API call could change the dimensions of future `ParameterChangeEventMessages`.

```csharp
protocol.SendToDisplay(matrixReadParameterId, changedInputs, changedOutputs);
```

#### Problem with SLElement due to timeout actions of an element being overwritten [ID_36591]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

In some rare cases, an error could occur in SLElement when a timeout action of an element with multiple connections would overwrite another timeout action of the same element.

#### NATSMaxPayloadException could be thrown when a client requested large amounts of data [ID_36655]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a client requested large amounts of data, in some cases, a `NATSMaxPayloadException` could be thrown.
