---
uid: Connector_help_Linux_Platform_SNMP
---

# Linux Platform SNMP

With this connector, you can monitor Linux platforms with SNMP.

## About

This connector uses SNMP in order to monitor a Linux platform.

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
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x (obsolete)</td>
<td>Initial version</td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.1.0.x (obsolete)</td>
<td>Based on 1.0.0.25 New firmware based on 1.0.0.x (see below)</td>
<td>Yes</td>
<td>No</td>
</tr>
<tr class="even">
<td>1.1.1.x [SLC Main]</td>
<td>Based on 1.1.0.56 Process Counter table was created in version 1.1.0.47. Impact upgrading from 1.1.0.46 or below: none Impact upgrading from 1.1.0.47 or above: <strong>loss of trend data for Process Counter Table</strong>. Process Counter table remade.</td>
<td>Yes</td>
<td>No</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td>Based on 1.1.0.35 Implemented SNMPv3</td>
<td>Yes</td>
<td>No</td>
</tr>
<tr class="even">
<td>2.0.1.x</td>
<td>Based on 1.1.0.44 Changed displayColumn to Naming to improve performance and make the connector Cassandra-compliant. Impact: <strong>loss of trend data on tables</strong>:
<ul>
<li>Software Info</li>
<li>Storage Table</li>
<li>Linux Monitored Disks</li>
<li>Load Average Information</li>
<li>Processor Table</li>
<li>Disk IO Table</li>
<li>Dell Power Supply Table</li>
<li>Dell Temperature Probe Table</li>
<li>Dell Cooling Device Table</li>
<li>Dell Controller Table</li>
<li>Dell Channel Table</li>
<li>Dell Enclosure Table</li>
<li>Dell Array Disk Table</li>
<li>Dell Virtual Disk Table</li>
</ul></td>
<td>Yes</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not applicable              |
| 1.1.0.x          | Not applicable              |
| 1.1.1.x          | Not applicable              |
| 2.0.0.x          | Not applicable              |
| 2.0.1.x          | Not applicable              |

## Installation and creation

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

From version **2.0.0.x** onwards, depending on the **Security level and protocol** selected, you may also need to fill in the **User name**, **Authentication password** and **Encryption password**.

## Usage

### General Page

This page displays general information regarding the Linux Platform:

- **Device info**
- **Total Processor Load**: Only available if **Poll Task Manager** is enabled (on the Task Manager page).
- **Memory usage**
- etc.

The **Memory Calculation Change** parameter is used to change the calculation for the **Available Physical Memory**. Between Red Hat EL net-snmp releases 5.7.2-43 and 5.7.2-46, the memory calculation was changed to a new formula. The old formula that was used for Red Hat EL net-snmp releases prior to 5.7.2-43 is back in use since 5.7.2-47. The **default value** of the Memory Calculation Change parameter is ***Disabled***, meaning it uses the old formula. If the installed net-snmp release on the Linux server is **between 5.7.2-43 and 5.7.2-46**, **enable** this parameter to use the new formula for the memory calculation. If you notice that the current Available Physical Memory value is incorrect, toggle the Memory Calculation Change parameter value to get the correct value of the memory.

The page contains several page buttons:

- **Port**: Displays a Port List and allows you to add/remove ports manually.
- **Ping:** Allows you to configure the ping definitions.
- **Load:** Displays load information.
- **Ext Commands:** Displays a table containing extensible commands and result codes.
- **Raw CPU:** Displays detailed information on CPU usage.
- **Processor**: Displays processor load information.

### Task Manager

On this page, you can enable **Poll Task Manager** in order to retrieve all the data from the **Task Manager Table**. Click **Auto Clear Task Manager** in order to automatically clear inactive processes.

The following page buttons are available:

- **Process Counters**: Counts the number of processes running and the CPU load and Memory Usage. There are also **Export** and **Import CSV** buttons used to export/import CSV files to/from the specified path and file name. After pressing the **Export CSV** button, the user has to check the specified file name at the specified file path of the server.
- **Nominal Value**: Displays additional process information.
- **Process Validation:** Displays information regarding process validation.
- **More:** Displays the Linux Monitored Processes information.

### Network Info

This page displays all interfaces and data rates.

From version **1.1.0.53** onwards, an additional monitoring subpage is available, the **Interface Monitor Config** page:

- This page displays the **status** of all interfaces.
- In the **Monitor** column, you can enable or disable rows to configure which rows are shown in the **Interfaces Tables** on the **Network Info** page.
- Four buttons at the top of the page allow you to **Enable All** interfaces, **Disable All** interfaces, **Enable Operational Up** and **Refresh** the table.

### Memory Info

This page displays memory information in the **Storage Table**, if **Storage Table Polling** is enabled.

The following page buttons are available:

- **Storage Availability:** Displays the Storage Availability Table.
- **More Memory**: Displays additional memory information.
- **Disk IO**: Displays the Disk IO Table.

### Software Info

This page displays a list of all installed software.

### More Disks

This page displays disk info, if **Linux Monitored Disks Polling** is enabled.

One page button is available, **Mount Availability**, which shows whether the mount is available (*present/not present*).

### External Data

This page contains data that is filled in through a dynamic link to elements of type **Sun File Reader**.

### HP/Dell

If the Linux platform is installed on an HP/Dell platform, you can enable **Poll HP Parameters** or **Poll Dell Parameters** to receive specific HP or Dell data.

On the **HP General** page (from version 1.1.1.2 onwards), you can configure an alternative IP (iLo IP) from which the HP parameters have to be polled, with the **HP Polling IP** parameter. The default value for this parameter is the element IP. If you do not want to use the alternative IP, you can disable it using the **HP Polling IP Status** parameter; the connector will then reset the IP to the default element IP. In order to fill in a new IP as the **HP Polling** **IP**, make sure the **HP Polling IP Status** parameter is enabled.

The following page buttons allow access to additional HP or Dell info:

- **Fan**
- **Power Supply**
- **Temperature**
- **Memory**
- **CPU**
- **Disk**

### SuperMicro

If the Linux platform is installed on a SuperMicro platform, you can enable **Poll SuperMicro Parameters** to receive specific SuperMicro data.

The following page buttons allow access to additional SuperMicro info:

- **OS**
- **Disk**
- **Memory**
- **CPU**
- **Health**

### Huawei

If the Linux platform is installed on a Huawei platform, you can enable **Poll Huawei Parameters** to receive specific Huawei data.

The following page buttons allow access to additional Huawei info:

- **CPU**
- **Fan**
- **LDAP**
- **DNS**
- **Network**
- **Memory**
- **Storage**
- **Power Supply**
- **Temperature**
- **Components**

### Virtual Server

This page is available from version **1.1.0.41** onwards. It displays general information about the virtual server. It also allows you to enable/disable **Poll LVS Parameters** to receive the data in question.

The following page buttons allow access to additional virtual server info:

- **LVS Real Table**
- **Service Table**

## DataMiner Connectivity Framework

From version **1.1.0.29** onwards, this protocol supports the usage of DCF and can only be used on a DMA with **8.0** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- The physical dynamic interface is created for the parameter **Interfaces Table** and its interface is **inout**.

## Note

For range **1.1.0.x**, it is possible to create a virtual dynamic Interface from an external source by adding a row to the Remote DCF Interface table (49997). This functionality does not exist in the 2.0.0.x range.
