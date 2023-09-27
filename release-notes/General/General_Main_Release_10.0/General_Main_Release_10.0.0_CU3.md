---
uid: General_Main_Release_10.0.0_CU3
---

# General Main Release 10.0.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### BPA test framework update \[ID_25840\]\[ID_25891\]

A number of enhancements have been made to the BPA test framework.

Also, special user permissions will now be required to create, update, delete, read, and execute BPA tests and to be able to receive BPA test results.

Best Practice Analysis (BPA) tests can be uploaded and run using the SLNetClientTest tool.

#### Enhanced service elements will now be started along with all other elements \[ID_25843\]

Up to now, enhanced service elements would be started when the services were loaded. Now, they will be started along with all other elements.

#### Service & Resource Management: Deleting resources based only on ID \[ID_25867\]

When a DataMiner Agent was asked to delete a resource, up to now, it would only delete that resource when all resource properties received matched the resource to be deleted. From now on, a DataMiner Agent will delete a resource based solely on the resource ID received in the delete request.

#### SLDMS: Object handling enhancements to prevent memory leaks \[ID_25879\]

In SLDMS, a number of object handling enhancements have been made to prevent memory leaks.

#### EULA page updated \[ID_25937\]

The EULA page has been updated.

This page can be accessed by clicking *Skyline software license terms* in the *About* window of Cube and the HTML5 applications, or by going to `http://<IP address of DMA>/EULA.htm` on the DataMiner Agent.

#### DataMiner Cube - Protocols & Templates: Link to Cube logging added to error window that appears when a server-side error occurred while uploading a functions file \[ID_25953\]

When a server-side error occurs while uploading a functions file in the Protocols & Templates app, from now on, a hyperlink in the error window will allow you to check the cause of the error in the Cube logging.

#### DataMiner Cube - Ticketing: Tickets page will now by default list all tickets associated with the first ticket domain that is found \[ID_25963\]

When, in a card, you selected the TICKETS page, up to now, that page would show a list of all open tickets across all known ticket domains. From now on, the list of open tickets will by default be restricted to the tickets associated with the first ticket domain that is found.

#### Protocols: Compression algorithm(s) can now be specified in an Accept-Encoding header \[ID_25969\]

In a protocol, it is now possible to specify which compression algorithm(s) should be used when performing a HTTP GET request. See the following examples.

##### Example 1: Using compression algorithm 'deflate'

```xml
<Session id="2">
  <Connection id="1">
    <Request verb="PUT" url="/index.php">
      <Headers>
        <Header key="PutHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 2: Using compression algorithm 'gzip'

```xml
<Session id="4">
  <Connection id="1">
    <Request verb="POST" url="/index.php">
      <Headers>
        <Header key="Accept-Encoding">gzip</Header>
        <Header key="PostHeader">HEADER_DATA</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 3: Using compression algorithms 'deflate' and 'gzip'

```xml
<Session id="6">
  <Connection id="1">
    <Request verb="TRACE" url="/index.php">
      <Headers>
        <Header key="TraceHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate;q=0.5,gzip;q=1.0</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

> [!NOTE]
> When no \<Header key="Accept-Encoding"> tag was specified, gzip and deflate compression will be used by default.

#### Error message 'Unknown destination DataMiner specified' replaced by 'Unable to find hosting agent. The agent might still be starting up' \[ID_25976\]

Up to now, when the hosting agent of an element or service could not be found, an “Unknown destination DataMiner specified” error would be thrown. This error message has now been replaced by “Unable to find hosting agent. The agent might still be starting up”.

#### DataMiner Cube - Router Control: Highlighting now also supported when working with linked pages \[ID_26001\]

When you select a routed output in the Router Control app, the crosspoints. the IO button and the tab item(s) of the corresponding button will all be highlighted.

Now, this highlighting feature is also supported in a dynamic environment, i.e. when working with linked pages.

#### DataMiner.xml: XML namespace now set during DataMiner installation \[ID_26011\]

In the *DataMiner.xml* file, from now on, the XML namespace will by default be set to   `xmlns=http://www.skyline.be/config/dataminer` during DataMiner installation.

### Fixes

#### Problem when sending table data from SLElement to SLDataGateway \[ID_25048\]

In some cases, an error could occur in SLElement when sending table data to SLDataGateway.

#### Indexing Engine: Active alias would incorrectly be created as index \[ID_25461\]

In some rare cases, the active alias would be created as index.

#### Problem with SLNet connections when a large amount of requests were sent over them \[ID_25613\]

In some cases, an SLNet connection could break when a large amount of requests were sent over it.

Together with this fix, the following changes have also been made:

- Automatic recovery of SLNet connections has now been rendered obsolete and is no longer supported.

- The event cache log options (SLNetClientTest \> Advanced \> Options \> SLNet Options \> EventCacheLogOptions) now support “filter=xxxxx” keywords to limit the output to specific types. “xxxxx” can be “element”, “dma”, “alarm” or any of the types listed in SLNetClientTest \> Diagnostics \> Caches & Subscriptions \> GeneralCacheStats \> Cache for xxxxxxxxx.

#### Miscellaneous small fixes \[ID_25645\]

A number of small fixes have been made, including the following:

- In some cases, a run-time error could occur in “Database Offload Thread \[local\]” when a DataMiner startup took too long.

- SLElement could leak memory when registering a link with an empty filter or when initializing a parameter group.

- The SLElement.txt log file will now indicate that it is loading all active alarms from the database. This will make it easier to analyze DataMiner startup issues.

- The license check will now skip adapters without MAC address.

- In some cases, especially when dealing with SNMPv3 elements, the following error could appear.

    ```txt
    Failed trying to send an initial cached event to EGMCC [...] System.ArgumentNullException: Value cannot be null
    ```

- In some cases, the following error could be added to the SLErrors.txt log file.

    ```txt
    SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|1|Failed to deserialize TableDefinitions Could not find file 'C:\Skyline DataMiner\Database\TableDefinitionCollection.xml'
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup for each exported protocol:

    ```txt
    CDataMiner::NotifySLElementProcess|ERR|-1|Notify SLELement process failed (86): 0x8004024c: The element is unknown.
    CExportProtocolsHandler::ExportProtocols|ERR|0|Failed exporting protocol with 0x8004024c The element is unknown.
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup:

    ```txt
    Could not load XSD: C:\Skyline DataMiner\Tools\Schemas\MobileGatewaySchema.xsd
    XSD URI was empty for: C:\Skyline DataMiner\Elements\xxxxxxxxx\Description.xml
    ```

#### DataMiner Cube - Visual Overview: Problem with session variables used by the Resource Manager timeline component \[ID_25718\]

In some cases, certain session variables used by the Resource Manager timeline component (e.g. YAxisResources) would not work properly when the page contained a setvar shape but no initvar action.

#### DataMiner Cube: Properties window of service or view would show incorrect Visio file extension \[ID_25760\]

In the Properties window of a service or a view, you can check the name of the Visio file that was assigned to that service or view. In some cases, when the extension of the file was “vdx” or “zip”, it would incorrectly be shown as “vsdx”.

#### Element that generated a large amount of data would be missing data after being restarted \[ID_25761\]

When an element that generates a large amount of data was restarted, in some cases, it would be missing data when it started up again.

#### Upgrade action 'CassandraActiveAlarmsRootOnlyUpgrade' would incorrectly only be run once \[ID_25764\]

Up to now, when a DataMiner Agent with a Cassandra database was upgraded, the upgrade action “CassandraActiveAlarmsRootOnly” would incorrectly only be run once. Now, it will be rerun at every upgrade until no more errors are reported.

Also, an additional upgrade action will now be run at every upgrade. The “CassandraDistinct-PropertiesUpgrade” action will check all alarms in the database and fix any incorrect alarm properties it encounters.

#### DataMiner Cube - Visual Overview: Problem with parameter chart updates \[ID_25777\]

When using a parameter chart, in some rare cases, that chart’s update interval would incorrectly be set to 0 seconds. As a result, it would be updated constantly. From now on, setting the update interval of a parameter chart to 0 seconds will no longer be possible.

#### DataMiner Cube - Profiles app: Modification of profile instance field 'applies to' would incorrectly be disregarded \[ID_25790\]

When configuring a profile instance in the Profiles module, you can indicate to which profile definition the instance applies. In some cases, when you changed this field, the modification would be disregarded.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25794\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### DataMiner Cube - Alarm Console: Problem when enabling or disabling history tracking \[ID_25813\]

When you enabled or disabled history tracking while viewing an alarm tab page that contained a large number of alarms, in some cases, Cube would become unresponsive.

#### DataMiner Cube - Visual Overview: Problem with \[profile:xxx\] placeholder \[ID_25817\]

In some cases, the \[profile:xxx\] placeholder would no longer be resolved correctly.

#### DataMiner Cube - Router Control: Options field of InfoPanel block would incorrectly be disregarded \[ID_25818\]

When, while configuring an InfoPanel block in the Router Control app, options had been specified in the Options field, those options would incorrectly be disregarded when the matrix configuration was loaded.

#### Memory leak in SLPort \[ID_25846\]

While a SmartIPHeader UDP socket was receiving data from multiple clients, in some cases, the SLPort process could leak memory when another client was detected.

#### Disabling the 'Enable DVE child creation' option in the 'Advanced element settings' would prevent the creation of virtual functions \[ID_25869\]

In some cases, disabling the Enable DVE child creation option in the Advanced element settings would incorrectly prevent the creation of virtual functions.

#### Alarms would have incorrect properties \[ID_25880\]

In some cases, alarms would have incorrect properties.

#### EPM view cards would not always have the same title \[ID_25895\]

If the name of the enhanced view was not identical to the system name, the EPM card of that view would not always have the same title. The title displayed would depend on the way in which the card was opened.

#### Problem caused by missing \<BackupSettings> tag in MaintenanceSettings.xml \[ID_25908\]

Up to now, when the \<BackupSettings> tag was missing from the MaintenanceSettings.xml file, it would not be possible to save backup settings.

From now on, when the MaintenanceSettings.xml file does not contain a \<BackupSettings> tag, it will automatically be added and filled with the correct settings.

#### DataMiner Cube: Element card of a Dynamic Virtual Element incorrectly had a 'Notes' page \[ID_25910\]

Up to now, when you opened the card of a Dynamic Virtual Element, it incorrectly had a Notes page. As DVE elements currently cannot have notes, this page has been removed.

#### DataMiner Cube - Listview: Problem when column icons got a severity update \[ID_25916\]

When a column in a ListView component was configured to show alarm icons, in some cases, an error could occur when one of those icons got a severity update.

#### Duplicate logger table storage types would incorrectly be created when migrating from MySQL to Cassandra \[ID_25935\]

When migrating a database from MySQL to Cassandra, in some cases, duplicate logger table storage types would incorrectly be created.

#### Problem when migrating newly created trend data from MySQL to Cassandra \[ID_25971\]

When you created an element or started trending a parameter and then, afterwards, migrated from MySQL to Cassandra, in some cases, the newly created trend data would not be migrated.

#### Automation: Problem when calling FindElements with a 'WarningOnly' element filter \[ID_25973\]

When the FindElements method was called with a “WarningOnly” element filter, in some cases, it would incorrectly return all elements.

#### Problem when multiple smart-serial elements using the same port restarted \[ID_25982\]

In some rare cases, an error could occur when multiple smart-serial elements using the same port restarted.

#### DataMiner Cube - Visual Overview: Tree view with 'SingleSelectionMode' option would incorrectly allow multiple values to be selected after a filter had been applied \[ID_25986\]

When, on a Visio page, you selected an item in a tree view to which you had added the “SingleSelectionMode” option, applied a filter and then selected another item, in some cases, the item you selected previously would incorrectly remain selected.
