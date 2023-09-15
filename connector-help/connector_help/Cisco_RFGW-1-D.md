---
uid: Connector_help_Cisco_RFGW-1-D
---

# Cisco RFGW-1-D

The Cisco RF Gateway 1 is a standards-based universal edge QAM (U-EQAM) solution for convergence of high-speed and high-bandwidth data and video distribution at the edge of the cable access network.

## About

The Cisco RFGW-1-D connector allows to monitor and control a Cisco RF Gateway 1 device. Different parameters of the device can be viewed and different settings can be set to a preferred value.

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
<td>1.0.0.x [Main]</td>
<td><p>Intial Version</p></td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>1.0.1.x</td>
<td>Removed Normalization</td>
<td>No</td>
<td><p>No</p></td>
</tr>
<tr class="even">
<td><p>1.1.0.x</p></td>
<td><p>New firmware based on 1.0.0.x (see below)</p></td>
<td>No</td>
<td>No</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td><p>Customer specific branch with extra columns/table populated from external source</p>
<p>Connector review</p></td>
<td>No</td>
<td>No</td>
</tr>
<tr class="even">
<td>3.0.0.x</td>
<td>Customer-specific version for Unity Media</td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Device Firmware Version**                 |
|------------------|---------------------------------------------|
| 1.0.0.x          | 05.02.06                                    |
| 1.0.1.x          | 05.02.06                                    |
| 1.1.0.x          | Cisco RF Gateway 1 Software Release 5.02.09 |
| 2.0.0.x          | 05.02.06                                    |
| 3.0.0.x          | 06.04.07                                    |

## Installation and configuration

### Creation

SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the connector: *public*).
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the connector: *private*).

## Usage

### General page

The **General** page displays some general parameters of the device.

The **Configuration** page button will save the **QAMs** configuration, it will allows to confirm the last **File Management Command**, the **File Management Last Result**, the **File Configuration File Name**, **Last Backup File Name** and the **Refresh** button will refresh these parameters after clicking on it.

There is also one page button (**IF Table.**) available on the page. This will display a pop-up page where the **IF Table** can be viewed.

### Resources

The **Resources** page displays the **FPGA temperatures** on the left-hand side of the page. On the right-hand side there is a Table that displays the **QAM Cards**.

Underneath this table there are two page buttons (**PS Status.**, **Fan Status.**) that each take you to a pop-up page that will displays extra parameters.

### IP Network

The **IP Network** page displays data regarding the network. There is one button (**Norm. With Current IP**) available on this page, this button will set the normalizations set on the **Normalize Values** pop-up page as the normal value for the alarms.

Three page buttons are also available on this page (**Normalize Values.**, **IP Network More.** and **GbE Input Ports.**), each page button will display a pop-up page with additional parameters.

### GbE Interfaces

This page displays data regarding the **GbE Interface**. There is one page button available (**Nominal Inputs.**), that will display a pop-up page where the normalized values can be set for the four GbE Inputs. By pressing the button (**Normalize Inputs**) these values will be set as the normal for the alarms.

### QAMs

The QAMs page displays two tables (**Global RF Port Configuration** and **Global QAM Channel Configuration**). There are two page button available (**Normalize RF Ports.** and **Normalize TS ID.**), each of these page buttons will open a pop-up page where the normalized values can be set. By pressing the respectable button (**Normalize RF Ports** or **Normalize TS ID**), the normalized values will be set as the normal value for the alarms.

### Output

This page displays the **Output Overview** Table. The page button (**Norm. BW Sessions.**) will open the **Normalized with Sessions Values** pop up. Here the normalized values can be set as preferred. By clicking the button (**Norm. BW Sessions**) the set values will be used as the normal values for the alarms.

### Alarm

This page displays the **Active Alarms** Table. There is one page button (**Filters.**) available where the user can add/remove filters. This is done by entering a value for the **Filter Name** and then pressing either the **Add Filter** or **Delete Filter** button.

### Stream Map

This page displays the stream **Map Monitoring** Table. Above this table the user can choose to set the **Stream Map Poll** *On* or *Off*.

### Monitor Input

This page is related to the new *Cisco RF Gateway 1 Software Release 5.02.09* and shows the **RFGW-1 Input Streams** and the **Input Redundancy** commands.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 3.0.0.x)

### General Page

This page contains general information about the device. It displays the **System Description**, **System Name**, **System Location** and **System Contact.**

### Interfaces Page

This page contains information on the interfaces of the Arris E6000 device.

The **Interface Table** shows information for each interface, such as the **Description**, **Type**, **MTU**, **Speed**, **Physical Address**, status information (**Admin Status** and **Operational Status**), information about errors and discarded packets (**Inbound Discards**, **Inbound Errors**, **Outbound Discards**, **Outbound Errors**) and interface utilization (**Utilization In** and **Utilization Out**).

The page shows the **Number of Displayed Interfaces,** based on how many interfaces are currently being displayed in the table.

It contains the **Interface Selection page button** with the **Interface Selection Table.**

> The **Interface Selection Table** controls the displayed interfaces on the Interface Table:
>
> - It has two parameters in order to filter the Interfaces and Enable or Disable interfaces being displayed (**Description Filter** and **Type Filter**) once clicked on the correspondent **Enable/Disable** button.
> - The Interface Selection Table has a **Displayed** column as **toggle button** Enable/Disabled.

### QAMs Page

This page contains two tables, the **QAM Channels Overview** table and the **QAM Channels Details** table, which both use the **QAM Channel Name** as an identifier.

- The **QAM Channels Overview** table contains information regarding the **Bandwidth**, **Bitrate**, **Utilization** and sessions per channel.
- The **QAM Channel Details** table contains more specific information for each channel, such as if the channel is muted or not, Spectrum Inversion value, transport id value, etc...

### RF Ports Page

This page contains the **RF Port Table**, which displays a counter for interfaces that are down, as well as the administrator status per RF port (**Interfaces Down** and **Admin Status**). Like previous tables, this table displays bit rates, the total maximum bandwidth and the usage percentage per RF port (**Bit Rate**, **Total Max Bandwidth** and **Utilization**).

### Streams Map Page

This page contains a table that displays the current stream map. This map is used to route video streams from the input ports to an output port (QAM Channel).
