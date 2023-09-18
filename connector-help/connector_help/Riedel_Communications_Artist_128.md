---
uid: Connector_help_Riedel_Communications_Artist_128
---

# Riedel Communications Artist 128

The Riedel Artist is a network infrastructure based on modular **matrix mainframes**. The individual Artist matrix mainframes can be equipped exactly as needed.

This connector uses a **TCP/IP** connection in order to retrieve and configure the matrix. It establishes communication towards the **RRCS**, which allows third-party router control systems to control Riedel Artist Intercom systems.

## About

### Version Info

| **Range**            | **Description**                                                                                                         | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Redundancy for the SERIAL connection is not available. The Serial Redundancy connection does not need to be configured. | No                  | Yes                     |
| 1.0.1.x              | Redundancy for the SERIAL connection is available. The Serial Redundancy connection will need to be configured.         | No                  | Yes                     |
| 2.0.0.x              | It is now possible to interact with the RRCS HTTP interface.                                                            | No                  | Yes                     |
| 2.0.1.x              | Changes made to table structures and keys.                                                                              | No                  | Yes                     |
| 2.0.2.x \[SLC Main\] | Addition of Unicode support.                                                                                            | No                  | Yes                     |
| 3.0.0.x              | Monitoring-only range based on range 2.0.0.x.                                                                           | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**            |
|-----------|-----------------------------------|
| 1.0.0.x   | \-                                |
| 1.0.1.x   | \-                                |
| 2.0.0.x   | RRCS Version: 6.90.RR5            |
| 2.0.1.x   | RRCS Version: 6.90.RR5 and higher |
| 2.0.2.x   | RRCS Version: 7.40.RR5 and higher |
| 3.0.0.x   | RRCS Version: 6.90.RR5            |

## Configuration

### Connections

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><h4 id="serial-main-connection">Serial Main Connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the primary RRCS gateway.</li>
<li><strong>IP port</strong>: The port of the primary gateway. Default: <em>8193.</em></li>
<li><strong>Bus address</strong>: If the proxy server has to be bypassed, specify <em>bypassproxy.</em></li>
</ul>
<h4 id="serial-event-notifications">Serial Event Notifications</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: This value should be set to "any".</li>
<li><strong>IP port</strong>: The notifications port. Default: <em>8194.</em></li>
<li><strong>Bus address</strong>: Not required.</li>
</ul></td>
</tr>
<tr class="odd">
<td>1.0.1.x</td>
<td><h4 id="serial-main-connection-1">Serial Main Connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the primary RRCS gateway.</li>
<li><strong>IP port</strong>: The port of the primary gateway. Default: <em>8193.</em></li>
<li><strong>Bus address</strong>: If the proxy server has to be bypassed, specify <em>bypassproxy.</em></li>
</ul>
<h4 id="serial-connection-redundant">Serial Connection Redundant</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the secondary RRCS gateway.</li>
<li><strong>IP port</strong>: The port of the secondary gateway. Default: <em>8193.</em></li>
<li><strong>Bus address</strong>: If the proxy server has to be bypassed, specify <em>bypassproxy</em>.</li>
</ul>
<h4 id="serial-event-notifications-1">Serial Event Notifications</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: This value should be set to "any".</li>
<li><strong>IP port</strong>: The notifications port. Default: <em>8194</em>.</li>
<li><strong>Bus address</strong>: Not required.</li>
</ul></td>
</tr>
<tr class="even">
<td>2.0.0.x2.0.1.x2.0.2.x3.0.0.x</td>
<td><h4 id="http-main-connection">HTTP Main Connection</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the primary RRCS gateway.</li>
<li><strong>IP port</strong>: The port of the primary gateway. Default: <em>8193.</em></li>
<li><strong>Bus address</strong>: If the proxy server has to be bypassed, specify <em>bypassproxy.</em></li>
</ul>
<h4 id="http-connection-redundant">HTTP Connection Redundant</h4>
<p>This connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the secondary RRCS gateway.</li>
<li><strong>IP port</strong>: The port of the secondary gateway. Default: <em>8193.</em></li>
<li><strong>Bus address</strong>: If the proxy server has to be bypassed, specify <em>bypassproxy.</em></li>
</ul>
<h4 id="serial-connection">Serial Connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: This value should be set to "any".</li>
<li><strong>IP port</strong>: The notification port. Default: <em>8194.</em></li>
<li><strong>Bus address</strong>: Not required.</li>
</ul></td>
</tr>
</tbody>
</table>

## Usage (all ranges except 3.0.0.x)

### General Page

This page displays the following information:

- **RRCSVersion**: The device's RRCS version.
- **Gateways**: Information regarding the Connection State, Ping State, and Gateway State of the primary and secondary gateway. A gateway connection parameter also displays the gateway that will be used. A Failover button allows you to change the gateway value.
- **PollingConfiguration**: Allows you to enable/disable the polling for the different tables that are displayed.
- **Commands**: Allows you to execute the Call-to-IFB and Call-to-Port commands.
- **Registration**: Allows you to register for crosspoint change notifications and alarms notifications.

**Note:** In range 2.0.1.x, an automatic gateway switchover mechanism is implemented in order to automatically switch from primary gateway to secondary gateway in case the primary gateway fails.

### Crosspoints Page

This page displays the **Crosspoints Info Table**, which contains all information regarding the crosspoints. It is also possible to add crosspoints (using the **Add Crosspoint button**), set the volume of each crosspoint (using the **Set Volume** button), and delete crosspoints (using the **Delete** button).

Please note that only crosspoints activated by RRSC can be deleted in DataMiner.

### Ports Page

This page displays the **Ports Table**, which contains all information regarding the ports.

### IFBs Page

This page displays the **IFBs Table**, which contains all Interruptible Fold Back information.

### Users Page

This page displays the **Users Table**, which contains all information regarding the users.

### Conferences Page

This page displays the **Conferences Table**, which contains all information regarding the conferences.

In range 2.0.2.x only, this page displays a **Conferences Tree** instead to present the information regarding the conferences.

### Notifications Page

This page displays the **Notifications Table**, which contains information about all the notifications that have been received. On this page, you can also find an **Auto Clear** button, a **Clear Table** button, and a **Refresh** button.

Using the **Auto Clear** button, you can configure the following generic parameters:

- **Notification Clean Up Method**: There are three possible ways to clean up the Notifications Table:
  - Based on the number of rows ("Row Count").
  - Based on how long the alarm has existed ("Notification Age").
  - Based on a combination of both ("Combo"). In this case, the "Row Count" check is done first.
- **Maximum Number of Notifications**: The maximum number of notifications that can be displayed.
- **Maximum Age of Notifications**: The maximum age of a notification allowed in the Notifications Table.
- **Notifications Clean Up Amount**: The number of oldest notifications that will be removed from the Notifications Table when the maximum is reached.

### Key Management page

This page displays the **Panel Table,** **Key Table**, and **Functions Table** tree view, and a **Keys and Panels** button to display all data tables.

There are two ways to add panels and keys:

1. Manually add one panel/key at a time.

1. Import a CSV file with all the keys or panels.

To use the CSV import feature:

1. Define the full file path in **Path of the Files** (e.g. C:\Users\\User)\Desktop).

1. Choose a file name:

   > [!IMPORTANT]
   > If you want to import a key table or a panel table, the file name must contain "Key Table" or "Panel Table" (e.g. "Key Table 2017-09-25").

1. Make sure the columns in the CSV file are correctly ordered and have the correct names. Refer to the examples below.

**Panel Table**

| Panel Table.Name \[IDX\] (Panel) | Panel Table.Main/Extension (Panel) | Panel Table.Model (Panel) | Panel Table.Node (Panel) | Panel Table.Port (Panel) |
|--|--|--|--|--|
|  |  |  |  |  |

- **Panel Table.Name \[IDX\] (Panel)**: Panel identifier (must be unique).
- **Panel Table.Main/Extension (Panel)**: 7 possible values ranging from 0 (Main), 1 (Extension 1), ..., to 6 (Extension 6).
- **Panel Table.Model (Panel)**: Can be chosen freely.
- **Panel Table.Node (Panel)**: Panel node.
- **Panel Table.Port (Panel)**: Port address. This column has dependency values in the Ports table.

**Key Table**

| Key Table.Key ID \[IDX\] (Key) | Key Table.Page (Key) | Key Table.Key Number (Key) | Key Table.Call Status (Key) | Key Table.Panel ID (Key) |
|--|--|--|--|--|
|  |  |  |  |  |

For the Key table data, you only need to fill in **Panel ID**, **Number**, **Page**, and **Call Status**.

- **Key Table.Key ID \[IDX\] (Key)**: Can be disregarded. Filled in automatically by DataMiner.
- **Key Table.Panel ID (Key)**: Has a dependency value in **Panel ID** defined in the **Panel Table**. We recommend first filling in the **Panel Table** and then setting this value. This value will link the key to the corresponding panel in the tree control view.
- **Key Table.Page (Key)**: Key page.
- **Key Table.Key Number (Key)**: Key number. Make sure you **do not fill in duplicate keys**. Each key number is allowed only once per **Panel ID**.
- **Key Table.Call Status (Key)**: Three possible values: "Dropped", "In Use" or "Not in Use".

**Functions Table (only available on range 2.0.1.x)**

> [!NOTE]
> This table is automatically filled in after the Key Table CSV file is imported.

| Functions Table.ID \[IDX\] (Functions) | Functions Table.Key ID (Functions) | Functions Table.Port ID (Functions) | Functions Table.IFB ID (Functions) | Functions Table.Trunk Port ID (Functions) | Functions Table.Trunk IFB ID (Functions) | Functions Table.Delete (Functions) | Functions Table.Label (Functions) |
|--|--|--|--|--|--|--|--|
|  |  |  |  |  |  |  |  |

- **Functions Table.ID \[IDX\] (Functions)**: Function identifier. This is a combination of the key ID and an auto-increment number.
- **Functions Table.Key ID (Functions)**: Key ID number defined in the Key Table. This value will link the key to the corresponding key in the tree control view.
- **Functions Table.Port/IFB/Trunk Port/Trunk IFB ID (Functions)**: Depending on the function assigned to the panel key, the corresponding ID will appear in the correct field. Note that the connector currently only supports one function per key.
- **Functions Table.Delete (Functions)**: A Delete button for each entry.
- **Functions Table.Label (Functions)**: A label corresponding to the actual single function assigned to the panel key.

Note that when a new CSV file is imported, the current keys or panels in the tables are not deleted. This can cause tables to grow indefinitely. Also note that when you delete a panel, all associated keys and functions will also be deleted.

## Usage (3.0.0.x only)

### General Page

This page displays the following information:

- **RRCS Version**: The device's RRCS version. The supported RRCS version is 6.90.RR5.
- **Registration**: Allows you to register for crosspoint change notifications and alarm notifications.
- **Gateways**: Information regarding the Connection State, Ping State, and Gateway State of the primary and secondary gateway. A gateway connection parameter also displays the gateway that will be used. A Failover button allows you to change the gateway value.

### Notifications Page

This page displays the **Notifications Table**, which contains information about all the notifications that have been received. On this page, you can also find an **Auto Clear** button, a **Clear Table** button, and a **Refresh** button.

Using the **Auto Clear** button, you can configure the following generic parameters:

- **Notification Clean Up Method**: There are three possible ways to clean up the Notifications Table:
  - Based on the number of rows ("Row Count").
  - Based on how long the alarm has existed ("Notification Age").
  - Based on a combination of both ("Combo"). In this case, the "Row Count" check is done first.
- **Maximum Number of Notifications**: The maximum number of notifications that can be displayed.
- **Maximum Age of Notifications**: The maximum age of a notification allowed in the Notifications Table.
- **Notifications Clean Up Amount**: The number of oldest notifications that will be removed from the Notifications Table when the maximum is reached.

## Notes

Range 3.0.0.x only includes the General and Notifications pages. This is a monitoring-only range.
