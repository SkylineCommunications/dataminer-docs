---
uid: General_Main_Release_10.4.0_CU17
---

# General Main Release 10.4.0 CU17

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU17](xref:Cube_Main_Release_10.4.0_CU17).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU17](xref:Web_apps_Main_Release_10.4.0_CU17).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: All TXF files will now be removed each time a DataMiner upgrade is performed [ID 43058]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

From now on, each time a DataMiner upgrade is performed, all TXF files will be automatically removed from the `C:\Skyline DataMiner\Scripts\` folder.

When you create an automation script, apart from an XML file containing the actual script, a number of TXF files will be created. These will contain cached query information to speed up XML querying.

### Fixes

#### Problem when combining conditional monitoring templates into an alarm template group [ID 42839]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When multiple conditional alarm templates had been combined into an alarm template group, up to now, the resulting group template could fail to properly apply its conditions.

#### Error 'The object exporter specified was not found' would get logged upon DMA startup [ID 42927]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

In some cases, a DataMiner Agent would not start up properly, and the following error would get logged in the *SLDataMiner.txt* log file:

`The object exporter specified was not found`

#### Problem with conditional alarm monitoring based on a condition made up of multiple AND/OR clauses [ID 42942]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When, in an alarm template, you had configured conditional monitoring based on a condition made up of multiple AND/OR clauses, up to now, some of those AND/OR clauses could incorrectly get disabled when the alarm template was refreshed in SLElement following e.g. a template update.

#### Problem with SLPort when stopping an element with a GPIB connection in an error state [ID 42949]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When you stopped an element with a GPIB connection in an error state, in some cases, the SLPort process could stop working and disappear.

#### Visual Overview in web apps: Incomplete images could be returned [ID 42968]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When a user requested a mobile visual overview, in some cases, an incomplete image could be returned.

#### Redundancy groups: Alarm mentioning that all redundancy resources are in use would incorrectly not get cleared [ID 42970]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU4] - FR 10.5.8 -->

If a redundancy group has more primary elements than backup elements, at the moment when all backups are in use, an alarm with severity level "Notice" will appear in the Alarm Console mentioning that all redundancy resources are in use.

By default, that alarm is cleared as soon as one of the backup elements is available again. However, up to now, in some cases, the alarm would incorrectly not get cleared.

#### Automation: Problem when trying to publish an automation script with an invalid name via DIS [ID 42974]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When, in DataMiner Integration Studio (DIS), you tried to publish an automation script of which the name contained leading and/or trailing spaces, up to now, the script would initially be added, but it would immediately be removed from the system. Also, the following error message would be added to the SLAutomation log file:

`Failed to load info for script 'XXX'`

From now on, when you publish an automation script via DIS, its name will be validated. If the name is invalid, the publish action will be aborted.

#### Protocols: Problem when polling an SNMP table using the partialSnmp option in combination with the multipleGetBulk option [ID 43034]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When both the `partialSnmp` option and the `multipleGetBulk` option were used when polling an SNMP table, up to now, too many `GetBulk` requests would be sent.

From now on, the maximum number of repetitions defined for `multipleGetBulk` will also be taken into account. For example, in case of `partialSnmp:8;multipleGetBulk:3`, the first 3 rows will be requested, then the next 3 rows will be requested, and finally the next 2 rows will be requested. A total of 8 rows will then be returned to SLProtocol. 3 plus 3 plus 2 makes 8, i.e. the value defined for `partialSnmp`.

> [!NOTE]
>
> - We recommend defining a partialSnmp row option that is equal to or a multiple of the maximum number of repetitions in order to avoid having to request a single row in the final request.
> - When both the `partialSnmp` option and the `GetNext` option were used when polling an SNMP table, up to now, this would result in an infinite loop. From now on, although combining `partialSnmp` with `GetNext` is still not supported, this will no longer cause any issues.

#### Problem with masked alarms when the alarm template was removed or when the parameters were no longer monitored [ID 43098]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When an element had masked alarms, the alarm status of the parameters in question would incorrectly remain masked when the alarm template was removed from the element or when conditional alarm monitoring would cause the parameters to no longer be monitored.

#### Problem when deleting or renaming services [ID 43109]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 -->

When a service was deleted, in some cases, it would only be fully deleted on the DataMiner Agent that hosted it.

Also, when a service was renamed, in some cases, all DataMiner Agents except the one hosting it could start to experience issues because the old service had not been properly deleted.

#### No history alarms shown when data was being migrated or replicated from separate Cassandra setup to STaaS [ID 43325]

<!-- MR 10.4.0 [CU17]/10.5.0 [CU5] - FR 10.5.8 [CU0] -->

While a DataMiner storage setup was migrated or replicated where each DMA had its own Cassandra database, no history alarms were shown.
