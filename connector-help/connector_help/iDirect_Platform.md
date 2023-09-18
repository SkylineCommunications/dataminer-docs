---
uid: Connector_help_iDirect_Platform
---

# iDirect Platform

The **iDirect Platform** connector is a DataMiner connector that can be used to monitor terminal, network, chassis, linecard, etc. components in iDirect satellite networks.

## About

In elements using this connector, all information about an iDirect NMS is retrieved and displayed. All the information is gathered from the MySQL databases.

This connector will export different connectors based on the retrieved data. Three kinds of DVEs can be generated, representing net modems, networks and line cards. No DVEs are created for the chassis; that information is available in the main element.

The creation of DVEs can be enabled or disabled in the main element. Different possibilities for **alarm monitoring** and **trending** are available.

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>Older ranges <strong>[Obsolete]</strong></td>
<td>-</td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>10.0.0.x</td>
<td>Automatically detects the iDirect version and displays the available information in the databases.</td>
<td>-</td>
<td></td>
</tr>
<tr class="even">
<td>10.0.1.x <strong>[Obsolete]</strong></td>
<td>Supports the polling of multiple iDirect hubs in a single element, to cope with roaming remotes between multiple NMS systems. <strong>From version 10.0.1.76 onwards, this range should be handled in parallel with range 10.0.2.x.</strong></td>
<td>10.0.0.47</td>
<td>-</td>
</tr>
<tr class="odd">
<td>10.0.2.x <strong>[Obsolete]</strong></td>
<td>Additional DCF external interfaces for iDirect Platform virtual DVEs. <strong>This range should be handled in parallel with range 10.0.1.x.</strong></td>
<td>10.0.1.76</td>
<td>Additional load on the system.</td>
</tr>
<tr class="even">
<td>10.0.3.x <strong>[Obsolete]</strong></td>
<td><p>Made Cassandra-compliant (fixed Cassandra Compliancy tag, incorrectly set in 10.0.1.x). <strong>This range should be handled in parallel with range 10.0.4.x.</strong></p></td>
<td>10.0.1.78</td>
<td><p>Old trend data will be lost for the following tables:</p>
<ul>
<li>Remotes Table</li>
<li>Enable Linecard Polling</li>
<li>Enable Network Polling</li>
<li>Chassis Table</li>
<li>IDirect Platform Table</li>
<li>Networks Table</li>
<li>Remotes On Network Table</li>
<li>Upstream Carriers Table</li>
<li>Downstream Carriers Table</li>
<li>iDirect Linecards Table</li>
</ul></td>
</tr>
<tr class="odd">
<td>10.0.4.x <strong>[Obsolete]</strong></td>
<td><p>Made Cassandra-compliant (fixed Cassandra Compliancy tag, incorrectly set in 10.0.2.x). <strong>This range should be handled in parallel with range 10.0.3.x [SLC Main].</strong></p></td>
<td>10.0.2.3</td>
<td>Old trend data will be lost for the following tables:
<ul>
<li>Remotes Table</li>
<li>Enable Linecard Polling</li>
<li>Enable Network Polling</li>
<li>Chassis Table</li>
<li>IDirect Platform Table</li>
<li>Networks Table</li>
<li>Remotes On Network Table</li>
<li>Upstream Carriers Table</li>
<li>Downstream Carriers Table</li>
<li>iDirect Linecards Table</li>
</ul></td>
</tr>
<tr class="even">
<td>10.0.5.x [SLC Main]</td>
<td><p>Reverted changes made in 10.0.3.x. This connector requires the display column to maintain the trend/alarm history when a replacement is done in the tables. Refer to the Notes section below for more information.</p>
<p><strong>This range should be handled in parallel with range 10.0.6.x [SLC Main], when applicable (no DCF integration).</strong></p></td>
<td>10.0.3.1</td>
<td>From 10.0.3.x/10.0.4.x only - old trend data will be lost for the following tables:
<ul>
<li>Remotes Table</li>
<li>Enable Linecard Polling</li>
<li>Enable Network Polling</li>
<li>Chassis Table</li>
<li>IDirect Platform Table</li>
<li>Networks Table</li>
<li>Remotes On Network Table</li>
<li>Upstream Carriers Table</li>
<li>Downstream Carriers Table</li>
<li>iDirect Linecards Table</li>
</ul></td>
</tr>
<tr class="odd">
<td>10.0.6.x [SLC Main]</td>
<td>Reverted changes made in 10.0.4.x.
<p>This connector requires the display column to maintain the trend/alarm history when a replacement is done in the tables. Refer to the Notes section below for more information.</p>
<p><strong>This range should be handled in parallel with range 10.0.5.x [SLC Main], when applicable (DCF Integration).</strong></p></td>
<td>10.0.4.1</td>
<td>From 10.0.3.x/10.0.4.x only - old trend data will be lost for the following tables:
<ul>
<li>Remotes Table</li>
<li>Enable Linecard Polling</li>
<li>Enable Network Polling</li>
<li>Chassis Table</li>
<li>IDirect Platform Table</li>
<li>Networks Table</li>
<li>Remotes On Network Table</li>
<li>Upstream Carriers Table</li>
<li>Downstream Carriers Table</li>
<li>iDirect Linecards Table</li>
</ul></td>
</tr>
<tr class="even">
<td>11.0.0.x</td>
<td>Range created for a specific customer, to support special requirements.</td>
<td>8.0.0.22</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range**      | **Device Firmware Version**           |
|-----------------------|---------------------------------------|
| 10.0.0.x              | Compatible with all iDirect versions. |
| 10.0.1.x \[SLC Main\] | Compatible with all iDirect versions. |
| 10.0.2.x              | Compatible with all iDirect versions. |
| 10.0.3.x              | Compatible with all iDirect versions. |
| 10.0.4.x              | Compatible with all iDirect versions. |
| 10.0.5.x              | Compatible with all iDirect versions. |
| 10.0.6.x              | Compatible with all iDirect versions. |

### System Info

<table>
<colgroup>
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
<td><strong>Linked Components</strong></td>
<td><strong></strong> <strong>Exported Components</strong></td>
</tr>
<tr class="even">
<td>Older ranges</td>
<td>No</td>
<td>No</td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>10.0.0.x</td>
<td>No</td>
<td>No</td>
<td>-</td>
<td><ul>
<li>iDirect Platform Virtual - Represents terminal components (customer installations) in an iDirect NMS.</li>
<li>iDirect Platform Network Virtual - Represents network components (beams) in an iDirect NMS.</li>
<li>iDirect Platform Linecard Virtual - Represents line card components in an iDirect NMS.</li>
</ul></td>
</tr>
<tr class="even">
<td>10.0.1.x</td>
<td>No</td>
<td>No</td>
<td>-</td>
<td></td>
</tr>
<tr class="odd">
<td>10.0.2.x</td>
<td>Yes</td>
<td>No</td>
<td>-</td>
<td></td>
</tr>
<tr class="even">
<td>10.0.3.x</td>
<td>No</td>
<td>Yes</td>
<td>-</td>
<td></td>
</tr>
<tr class="odd">
<td>10.0.4.x</td>
<td>Yes</td>
<td>Yes</td>
<td>-</td>
<td></td>
</tr>
<tr class="even">
<td>10.0.5.x</td>
<td>No</td>
<td>Yes</td>
<td>-</td>
<td></td>
</tr>
<tr class="odd">
<td>10.0.6.x</td>
<td>Yes</td>
<td>Yes</td>
<td>-</td>
<td></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

Additional settings need to be filled in on the **Configuration** page of the element. On that page, the polling can be *enabled*/d*isabled* for each database, and the polling interval can be configured.

All iDirect installations consist of two databases (schemas): "**nms**", with all the configuration data, and "**nrd_archive**", with all events and statistics. In small systems, these databases are typically placed on one single MySQL server. In larger systems, the config and statistics databases can be on multiple servers, each with another IP address. In very large systems, it is also possible that the archive database is spread over two separate machines: one with stats and one with events. In the connector, three individual IP addresses can be defined.

#### Range 10.0.1.x and 11.0.0.x

All iDirect databases containing the data that must be polled need to be added in the **Databases Table**. You can add or remove rows in the table using the right-click menu. For each iDirect hub, exactly one config database and one or more statistics databases must be specified. Even when the config and statistics database have the same IP address, two rows need to be added to the table.

For each row, specify the IP address, username and password, and select if the database contains configuration or statistics (archive) data.

The **DB Hub ID** column indicates to which iDirect NMS the database belongs. You can choose the hub ID yourself, but make sure that each hub has a unique ID and that all databases that belong to the same iDirect hub have the same ID.

#### Other ranges

Three database connections can be configured:

- The first database is where all the configuration data is stored.
- The second database contains all GPS position data. This data is used for the GPS tracking capabilities in DataMiner Maps.
- The third database contains all the archived data, which is used for trending and monitoring purposes.

## Usage

Not all available pages are mentioned here, because the data is meant to be accessed via the DVEs.

### General page

This page displays a table with the most important information about each remote. For each row in this table, a remote DVE is created, which also contains all the relevant information.

#### Remotes Enable/Disable subpage

This page allows you to control the creation of the remote DVEs. Each row in the table has an individual enable/disable toggle button.

Three main settings are available:

- **Auto Enable Remotes**: The default state for newly configured remotes. When this is enabled, if the connector detects a new remote, a new DVE element will automatically be created.
- **Auto Delete Remote DVEs**: When this is enabled, if the remote is deactivated or removed in the iDirect NMS, the DVE element will automatically be deleted in DataMiner. When this is disabled, you can delete the DVE manually by clicking the **Delete Element** button in the DVE.
- **Create DVE for Deactivated Remotes**: When this is disabled, deactivated remotes are treated the same way as removed remotes: no DVE element will be created. Enable this setting if you also want an element for deactivated remotes.

### Active Networks page

This page displays a table with all the available networks. For each line, a network DVE is created with the same information. In the second table, you can give each network a custom name.

#### Networks Enable/Disable subpage

This page allows you to control the creation of the network DVEs. Each row in the table has an individual enable/disable toggle button.

Two main settings are available:

- **Auto Enable Networks**: The default state for newly configured networks. When this is enabled, if the connector detects a new network, a new DVE element will automatically be created.
- **Auto Delete Network DVEs**: When this is enabled, if the network is removed in the iDirect NMS, the DVE element will automatically be deleted in DataMiner.

### Chassis page

This page displays a table with the current status of each chassis, together with the active alarms.

### Linecards page

This page displays a table with all the information about each line card. All the information is also available on the line card DVEs.

Via the page button at the bottom of the page, you can *enable* or *disable* the polling for each line card.

#### Linecards Enable/Disable subpage

This page allows you to control the creation of the linecard DVEs. Each row in the table has an individual enable/disable toggle button.

Two main settings are available:

- **Auto Enable Linecards**: The default state for newly configured linecards. When this is enabled, if the connector detects a new linecard, a new DVE element will automatically be created.
- **Auto Delete Linecard DVEs**: When this is enabled, if the linecard is removed in the iDirect NMS, the DVE element will automatically be deleted in DataMiner.

### Polling Status page

This page displays the current status of the data polling from the iDirect MySQL databases. It allows you to manually trigger a new polling cycle.

For GPS and statistics type polling, the time retrieved with the most recent polling is displayed. This time is used in the next polling cycle, in order to only receive newer data.

### Configuration page

The general configuration needs to be done on this page. For more information, refer to the section "Installation and configuration" above.

The IDirect Time Offset parameter can be used to correct a time difference (negative or positive) between the DataMiner server and the iDirect server. To calculate the value, use the following formula: \[iDirect time\] - \[DataMiner time\] (in hours).

## Notes

#### MySql.Data.dll

This connector uses functionality from the MySql.Data.dll file that is only available in relatively recent versions. By default, an older version of this file exists in the folder *C:\Skyline DataMiner\ProtocolScripts\\*, and as such the connector will not work correctly initially. To solve this issue, copy the file *MySql.Data.dll* from the folder *C:\Skyline DataMiner\Files\\* to *C:\Skyline DataMiner\ProtocolScripts\\* and restart the element.

#### \[10.0.x ranges\] DisplayColumn and Cassandra compliance

The purpose of the display column in this connector is to maintain the trend/alarm history when entries of the tables are replaced (different primary keys), by linking the history data with the display key. This is a specific use case that allows the use of DisplayColumn in both MySQL and Cassandra.

For example, when a modem is physically replaced, the trend/alarm history can be maintained. The ID of the modem will change (primary key), but the user can set the display key to be the same as the previous one, thus maintaining the trend and alarm history.
