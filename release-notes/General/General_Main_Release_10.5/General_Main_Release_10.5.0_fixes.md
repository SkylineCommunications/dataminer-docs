---
uid: General_Main_Release_10.5.0_fixes
---

# General Main Release 10.5.0 – Fixes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

#### Storage as a Service: Resources would not always be released correctly [ID 38058]

<!-- MR 10.5.0 - FR 10.4.2 -->

Resources would not always be released correctly, causing some resources to be used for longer than strictly necessary.

#### SLReset: Problem when cleaning a Cassandra database [ID 38332]

<!-- MR 10.5.0 - FR 10.4.2 -->

When cleaning (i.e. resetting) a Cassandra database, in some cases, a `TypeInitializationException` could be thrown.

#### StorageModule: Only final retry will be logged as error when a data storage request fails [ID 38897]

<!-- MR 10.5.0 - FR 10.4.4 -->

When a StorageModule client requests data to be stored, in some cases, a subscription exception can be thrown. Those data storage requests are retried automatically. However, up to now, each retry would be logged as error.

From now on, only the final retry will be logged as error. All prior retries will only be logged when the log level is set to "debug".

#### GQI: Problem when loading extensions [ID 38998]

<!-- MR 10.5.0 - FR 10.4.5 -->

When GQI extensions (i.e. ad hoc data sources or custom operators) were being loaded, in some cases, an exception could be thrown when inspecting the assembly of an extension that prevented subsequent extensions from being loaded.

This type of exceptions will be now be properly caught and logged as warnings so that other extensions will no longer be prevented from being loaded.

> [!TIP]
> See also: [GQI: Full logging [ID 38870]](xref:General_Main_Release_10.4.0_CU1#gqi-full-logging-id-38870)

#### Problem while checking whether the DataMiner System was licensed to use the ModelHost DxM [ID 39001]

<!-- MR 10.5.0 - FR 10.4.5 -->

A *ModelHostException* could be thrown while checking whether the DataMiner System was licensed to use the ModelHost DxM.

#### Skyline Device Simulator: Problem when loading HTTP simulation files that contained additional tags [ID 39379]

<!-- MR 10.5.0 - FR 10.4.6 -->

In some cases, when you tried to load a PDML file containing an HTTP simulation, the simulation would fail to load, especially when the PDML file contained additional tags (e.g. comments).

#### STaaS: Problem when using a delete statement with a filter [ID 39416]

<!-- MR 10.5.0 - FR 10.4.6 -->

When, on a STaaS system, an attempt was made to delete data from the database using a delete statement with a filter, in some cases, the data would not be deleted and the following error would be logged in the *CloudStorage.txt* log file:

`Provided delete filter resulted in a post filter, post filtering is not supported for cloud delete requests.`

This issue has now been fixed.

#### API Gateway: Problem when processing a large number of parallel calls [ID 39550]

<!-- MR 10.5.0 - FR 10.4.7 -->

When API Gateway had to process a large number of parallel calls, up to now, this could lead to a threading problem, causing clients to time out and get disconnected.

#### SLAnalytics: Elements imported after being deleted earlier would incorrectly be considered deleted [ID 39566]

<!-- MR 10.5.0 - FR 10.4.7 -->

When an imported element was deleted and then imported again, up to now, SLAnalytics would incorrectly considered that element as being deleted for at least a day. As a result, it would for example not detect any change points for that element during that time frame.

From now on, when an imported element is deleted and then imported again, SLAnalytics will no longer considered that element as being deleted.

#### TraceData generated during NATSCustodian startup would re-appear later linked to another thread [ID 39731]

<!-- MR 10.5.0 - FR 10.4.8 -->

In some rare cases, TraceData generated during NATSCustodian startup would re-appear later linked to another thread.

#### Service & Resource Management: Error occurring when the Service Manager fails to delete a service was incorrectly logged as 'information' instead of 'error' [ID 39738]

<!-- MR 10.5.0 - FR 10.4.8 -->

Up to now, the error thrown when the Service Manager fails to delete a service was incorrectly logged as "information" instead of "error". From now on, this error will be logged as error with log level 0.

Also, when the above-mentioned error is thrown, the *SLResourceManagerAutomation.txt* log file will no longer log "Done deleting service". Instead, it will log that an error occurred and that more information can be found in the *SLServiceManager.txt* log file.

#### Service & Resource Management: Deadlock when forcing quarantine during a booking update [ID 39755]

<!-- MR 10.5.0 - FR 10.4.6 [CU1] -->

After a quarantine had been forced during a booking update, in some cases, the SRM framework would stop responding.

See also: [Deadlock when forcing quarantine during booking update](xref:KI_Deadlock_when_forcing_quarantine)

#### SLAnalytics - Alarm template monitoring: Problem when processing template removals [ID 39819]

<!-- MR 10.5.0 - FR 10.4.8 -->

When all elements were removed from an alarm template, SLAnalytics would correctly remove the template from its cache. However, when that entire alarm template was removed later on, SLAnalytics would incorrectly add an incorrect version of that template to its cache.

Also, when a user created a template and then removed it without assigning elements to it, SLAnalytics would add it to its cache, but would never remove it from its cache.

#### Problem with SLProtocol after it had tried to read beyond the size of a table [ID 39829]

<!-- MR 10.5.0 - FR 10.4.6 [CU1] -->

In some cases, SLProtocol would stop working after it had tried to read beyond the size of a table.

#### GQI: Problem when performing a join operation [ID 39844]

<!-- MR 10.5.0 - FR 10.4.8 -->

When a join operation was performed with two of the following data sources, in some cases, the GQI query would fail and return a `Cannot add custom table to the registry as the registry is already built.` error.

- *Get alarms*
- *Get behavioral change events*
- *Get trend data pattern events*
- *Get trend data patterns*

#### Problem with SLAnalytics while starting up [ID 39955]

<!-- MR 10.5.0 - FR 10.4.8 [CU0] -->

In some rare cases, while starting up, SLAnalytics appeared to leak memory and could stop working.

#### DELT import failed if element name contained curly bracket [ID 40330]

<!-- MR 10.5.0 - FR 10.4.10 -->

When an element name contained a curly bracket ("{" or "}"), exporting the element to a .dmimport package or importing it from such a package failed.

#### DataMiner root page 'default.asp' incorrectly still used XBAP URLs to open Cube [ID 40433]

<!-- MR 10.5.0 - FR 10.4.10 -->

Up to now, when *defaultApp* was set to "Cube" in `C:\Skyline DataMiner\Webpages\Config.manual.asp`, the DataMiner root page `C:\Skyline DataMiner\Webpages\default.asp` would incorrectly still use deprecated XBAP URLs to open DataMiner Cube. It will now open DataMiner Cube using *cube://* URLs instead.

For example, when *defaultApp* is set to "Cube" in `C:\Skyline DataMiner\Webpages\Config.manual.asp`, using the URL ``https://mydma/?element=12/76`` will open DataMiner Cube, which will then immediately open an element card containing the specified element.

> [!NOTE]
> When *defaultApp* was set to "Cube" in `C:\Skyline DataMiner\Webpages\Config.manual.asp`, up to now, if you tried to open a link like ``https://mydma/?element=dmaID/elementID`` in Microsoft Edge, Google Chrome or Mozilla Firefox on Microsoft Windows, the link would incorrectly be opened in the Monitoring app instead of DataMiner Cube. From now on, that link will correctly be opened in DataMiner Cube. Only if you open the link on a mobile device or an operating system other than Microsoft Windows (e.g. Linux, macOS, etc.), will it still be opened in the Monitoring app.

#### SLDataGateway would not send the correct error to the client application when there was a database problem [ID 40488]

<!-- MR 10.5.0 - FR 10.4.11 -->

When SLDataGateway detected a database problem, up to now, it would incorrectly send a message mentioning a Cassandra error to the client (e.g. DataMiner Cube) whatever the type of database that was being used. From now on, the message sent to the client will mention the database that is actually being used.

Also, on systems using a Cassandra Cluster database, when the indexing engine could not be reached, up to now, DataMiner would keep on restarting. From now on, as soon as a required database cannot be reached, DataMiner will stop without trying to restart.

#### SLNet: Problem when internal and external authentication were used within the same DMS [ID 40635]

<!-- MR 10.5.0 - FR 10.4.12 -->

When, in a DataMiner System, some agents used external authentication while other agents used internal authentication, in some rare cases, the SLNet error "SSPI.DLL is no longer supported" could be thrown on certain agents.

#### DataMiner Cube - Scheduler app: No error would be shown when trying to send an email with a non-existing dashboard in attachment [ID 40705]

<!-- MR 10.5.0 - FR 10.4.11 -->

When, in e.g. Cube's Scheduler app, an action would send an email with in attachment a dashboard that no longer existed, the email would not be sent, but no error would be shown.

From now on, when an action tries to send an email with a non-existing dashboard in attachment, the task will fail and an exception will be thrown.

#### Problem when masking or unmasking DELT elements [ID 40723]

<!-- MR 10.5.0 - FR 10.4.11 -->

When a DELT element was masked or unmasked, when no hosting agent ID was passed along in the SetAlarmStateMessage, the message would be sent to the DataMiner Agent referred to by the DataMiner ID of the element. In some rare cases, this DataMiner ID could refer to a non-existing DataMiner Agent, causing an exception to be thrown.

#### Memory leaks when an element that was used in an alarm level link configuration was restarted [ID 40997]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When an element that was used in an alarm level link configuration was restarted, in some cases, both SLElement and SLProtocol could leak memory, as would SLDataMiner when the alarm level links were pushed to locked elements.

For more information on the `<AlarmLevelLinks>` element, see [How to aggregate alarm severities](xref:How_to_aggregate_alarm_severities)

#### SLElement: Incorrect alarm linking [ID 41057]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

In some cases, new alarm events could incorrectly get linked to previously closed external events or information events on the same element.

#### SLElement would leak memory when filtering a recursive table or a directview/view table that had to be sorted [ID 41058]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When SLElement had to process a table filter request, it would leak memory in the following cases:

- When the table had a foreign key to itself.
- When a directview or view table with a number of non-initialized columns had to be sorted.

#### SLElement would leak memory when SLNet needed to be notified of baseline changes [ID 41088]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

When a baseline changed and SLNet needed to be notified of the new values, SLElement would leak memory.

#### Failover: Problem when an element.xml file was updated while StorageModule was synchronizing its cache [ID 41133]

<!-- MR 10.5.0 [CU0] - FR 10.5.1 -->

When, in a Failover setup, SLDMS was synchronizing an updated *element.xml* file while the StorageModule DcM was synchronizing its cache to an XML file, in some rare cases, an exception could be thrown in the StorageModule DcM, causing the *element.xml* update to fail.

#### LDAP/ActiveDirectory domain users would no longer be able to log in [ID 41143]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

Since DataMiner 10.4.0 [CU4]/10.4.7, in some cases, LDAP/ActiveDirectory domain users would no longer be able to log in. When such a user tried to log in, the following entry would be added to the SLNet.txt log file:

`Authentication Step Failure: Not a DataMiner user: CONTOSA\user`

This issue would only occur on LDAP servers where `CN=CONTOSA,CN=Partitions,CN=Configuration,DC=contosa,DC=com` does not have a `nETBIOSName` attribute, for example when accessing the GlobalCatalog of a forest.

After having upgraded to a DataMiner version that contains this fix, you can do the following:

- Wait up to an hour for the next LDAP synchronization to occur, or
- Manually trigger the "Skyline DataMiner LDAP Resync" task in Windows Task Scheduler.

All users should then be able to log in again.

#### STaaS: Excessive number of duplicate entries added to the SLErrors.txt log file in case of connection problems [ID 41192]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

On STaaS systems, in case of connection problems, a large number of the following errors would be added to the *SLErrors.txt* log file:

- *The remote name could not be resolved.*
- *Unable to connect to the remote server.*

From now on, in case of connection problems, the generation of *SLErrors.txt* log file entries will be throttled in order to reduce the number of duplicate entries.

#### Protocols: Problems when polling SNMP tables using GetNext [ID 41235]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of problems that occurred when polling SNMP tables using *GetNext* have been fixed:

- When an entire SNMP table was polled using *GetNext* messages, and not all rows had values with the same syntax (e.g. 1.2.3 vs 4.5.6.7), in some cases, cells would be empty or would be shifted to another row. The SLSNMPManager process could even disappear. From now on, all table cell values will be displayed correctly.

- Up to now, an SNMP table would be polled until the returned OID result went out of scope. For example, when only 3 columns were defined in the table parameter, and the SNMP table contained 20 columns, all 20 columns would be polled, even though the data in the remaining 17 columns was not needed. From now on, as soon as the columns defined in the table parameter are polled, polling will stop and the result will be filled in.

- Up to now, only the rows with a value in the first column would be added to the table. From now on, when the table parameter has the `instance` option defined, rows of which the first column on the right of the instance column is empty will also be added to the table.

#### STaaS: Incorrect data would be returned when data was read immediately after a write operation had been executed [ID 41269]

<!-- MR 10.5.0 [CU0] - FR 10.4.12 [CU0] -->

On STaaS systems, in some cases, when data was read immediately after a write operation had been executed, incorrect data would be returned, especially while restarting elements.

#### Issues when synchronizing files among agents in a DMS [ID 41382]

<!-- MR 10.5.0 - FR 10.5.1 -->

A number of issues that occurred while synchronizing files among agents in a DMS have been fixed.

#### DataMiner upgrade: Folder to which the contents of the upgrade package had been extracted would not be removed [ID 41393]

<!-- MR 10.4.0 [CU16]/10.5.0 - FR 10.5.1 -->

When a DataMiner Agent had been upgraded, in some cases, the folder to which the contents of the upgrade package had been extracted would incorrectly not be removed.

#### DataMiner would use an incorrect IP address when connecting to BrokerGateway during startup [ID 41530]

<!-- MR 10.5.0 - FR 10.5.2 -->

During startup, in some cases, DataMiner would use an incorrect IP address when connecting to BrokerGateway.

#### Service & Resource Management: Debug lines would incorrect get logged multiple times in SLResourceManagerScheduler.txt [ID 41568]

<!-- MR 10.5.0 - FR 10.5.2 -->

While the booking scheduler task queue was being processed, in some cases, debug lines would incorrectly get logged multiple times in the *SLResourceManagerScheduler.txt* log file.

#### Problem with SNMPv3 elements after upgrading from Main Release version 10.4.0 CU6 (or later) to Feature Release version 10.4.x (10.4.9 to 10.4.12) [ID 41630]

<!-- MR 10.5.0 - FR 10.5.1 [CU0] -->

When a DataMiner Agent was upgraded from Main Release version 10.4.0 CU6 (or later) to Feature Release version 10.4.x (10.4.9 to 10.4.12), the `MigrateSNMPv3PasswordsToElementConfig` upgrade action would incorrectly not be executed, causing SNMPv3 passwords not to be migrated correctly. As a result, SNMPv3 connections would lose access to their credentials. Also, the following critical alarm would be generated for each of the affected elements:

`Error parsing SNMPv3 password for port: xxx on element: xxx`

> [!NOTE]
> See also [SNMPv3 elements not loaded correctly after upgrade](xref:KI_SNMPv3_elements_broken_after_upgrade)

#### GQI: Min and Max aggregation of a datetime column would incorrectly result in a number column [ID 41789]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, when a Min or Max aggregation was performed on a datetime column, the aggregated column would incorrectly be a number column instead of datetime column.

#### Fixes made with regard to the management of locally-stored element documents [ID 41882]

<!-- MR 10.5.0 - FR 10.5.3 -->

A number of fixes have been made with regard to the management of locally-stored element documents that are not synchronized among the DMAs in a DataMiner System.

#### Errors would be logged in SLErrors.txt and SLNet.txt when Mobile Gateway was enabled in a DMS with more than one agent [ID 41988]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, errors would be logged in the *SLErrors.txt* and *SLNet.txt* log files when Mobile Gateway was enabled in a DataMiner System with more than one DMA.

Also, the Mobile Gateway process would only be aware of elements that were hosted on the same agent as the one on which it was hosted itself. As a result, actions like GET and SET on other elements via the Mobile Gateway would fail.

#### Problem when updating the GQI DxM [ID 41990]

<!-- MR 10.5.0 - FR 10.5.3 -->

When you tried to update the GQI DxM by means of the MSI installer, in some cases, the update would either not entirely succeed or even fail.

A number of enhancements have now been made to prevent any problems from occurring while updating the GQI DxM.

#### No more logging would be added to SLWatchDog2.txt after a DataMiner upgrade [ID 42180]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

After a DataMiner upgrade, in some cases, no new entries would be added to the *SLWatchDog2.txt* log file anymore.

#### SLSNMPManager process could stop working when an SNMPv3 element was stopped [ID 42195]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When an SNMPv3 element was stopped, in some rare cases, the SLSNMPManager process could stop working.
