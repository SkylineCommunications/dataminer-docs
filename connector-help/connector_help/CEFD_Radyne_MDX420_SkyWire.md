---
uid: Connector_help_CEFD_Radyne_MDX420_SkyWire
---

# CEFD Radyne MDX420 SkyWire

The **CEFD Radyne MDX420 SkyWire** connector can be used to display information and configure settings for the **CEFD Radyne MDX420 SkyWire** satellite network gateway.

## About

This protocol can be used to monitor and control the **CEFD Radyne MDX420 SkyWire** modem. An SNMP connection is used to retrieve and set the modem's information and configuration data.

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
<td>1.0.0.x</td>
<td>Initial version</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td><p>Same as 1.0.0.x but this version uses SNMPv3.</p></td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="even">
<td>1.0.1.x [SLC Main]</td>
<td><p>Based on 1.0.0.4</p>
<p>Implemented changes in layout and configuration parameters based in feedback from vendor.</p>
<p>Parameters listed in the Notes section are no longer available, so please verify any references in DMS to these parameters.(Visio, Automation Scripts, DMS Filters, Reports ...)</p></td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | F05804-L                    |
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | F05804-L                    |

## Installation and configuration

### Creation

For protocol version range 1.0.0.x, this connector uses a Simple Network Management Protocol (SNMP) connection. For protocol version range 2.0.0.x, this connector uses a Simple Network Management Protocol version 3 (SNMPv3) connection. The following user information is required for either version:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page displays general information about the modem, for example: **System Name**, **Firmware Version**.

The page also displays some buttons and page buttons. The **Load Config**, **Save Config** and **Load Defaults** buttons can be used to load or save the configuration. The page buttons all display different pages with extra information about the MDX420. The **Installed Features...** button displays a separate page with information about the features that are installed for this modem. The **Events...** button displays information about the events that are occurring and the last events that have occurred in the system. The **Voltages...** button displays a page with the voltages.

### Modulator

The **Modulator** page displays the transceiver configuration settings.

### Modulator Alarms

The **Modulator** **Alarms** page displays all alarms related to the transceiver. There are 2 groups of alarms: **Alarms** and **Latched Alarms**.

The **Clear Latched Alarms** button can be used to clear the latched alarms. However, note that this button will clear all latched alarms, and not just the modulator latched alarms.

### Demodulator

The **Demodulator** page displays information about the receiver settings and data.

This page displays 2 tables: **Rx NV Status Table** and **Rx Status Table**. The first table displays non-volatile status information, while the second one displays volatile status information. The **Rx NV Status Table** can be used to configure the Demodulator settings.

This page is similar to the **Modulator** page, except that here the settings are displayed in a table, because there can be up to 4 receivers for this device.

### Demodulator Alarms

The **Demodulator Alarms** page displays all receiver alarms.

This page is similar to the **Modulator Alarms** page, except that the alarms are displayed in tables, because there can be up to 4 demodulators.

Note that the **Clear Latched Alarms** button will clear all latched alarms, so not only those related to the demodulator.

### Configuration

The **Configuration** page displays extra modulator and demodulator configuration settings. These settings are divided into 3 groups: **BUC, LNB** and **AUPC Controls**.

### Terrestrial Interfaces

The **Terrestrial Interfaces** page displays extra information and configurations for the terrestrial interfaces. The left side of this page displays M&C (Monitor & Control) parameters, while the right side displays ethernet information.

### Common Alarms

The **Common Alarms** is another alarms page that displays the common alarms. These are system alarms rather than alarms linked to the modulator or demodulator.

There is also a **Clear Latched Alarms** button, which will clear all the latched alarms. However, note that this button will clear all latched alarms, and not just the common latched alarms.

### Remotes

The **Remotes** page displays remote configuration and information data. This data is displayed in 2 tables: **Remote NV Status Table** (non-volatile) and **Remote Status Table** (volatile). You can also start or reboot the network on this page.

### TCP/IP Settings

The **TCP/IP Settings** page can be used to access the TCP/IP settings. The **FTP** **controls** are also displayed on this page. The **Advanced...** page button displays a separate page that can be used to change the **Terminal Logon Password**.

### Ping Function

This page displays information about the **Ping Queries**, such as **Ping Status**, **Average** **Success**, **Average** **RTT**, **Availability** and **Percentage of Packet Loss**. It also contains a toggle button to enable or disable **Ping Queries** and other editable properties of the queries ,such as **Cycle**, **Timeout**, **Requests** **per** **Cycle** and **Requests** **History**.

## Notes

The following parameters are not longer available in connector range 1.0.1.x:

- Events Log Status (PID 684). That parameter now is hidden and its information is showed in a new table.

- Rx Mesh Membership Key (PID 303), Rx Test Pattern Ber Status(PID 402), Rx Test Pattern Error Count(PID 403), Rx Test Pattern Bit Count(PID 404), Rx Composite Alarms(PID 409), NV Inband(PID 714). These parameters were hidden.

- Boot Mode(PID 1000/1001). Parameter was removed

- The following parameters are read-only, so the drop-down menu was removed: Local Host Name, Modem IP Mask, Modem IP Address, Server IP Address, Router IP Address, Modem Ethernet Address.
