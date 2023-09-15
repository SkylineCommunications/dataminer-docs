---
uid: Connector_help_IBM_System_x
---

# IBM System x

The **IBM System x** connector can be used to display and configure information of any IBM System device.

## About

This protocol can be used to monitor and control an IBM System x device. An **SNMP** connection is used in order to successfully retrieve and configure the information of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x1.0.1.x</td>
<td><p>IMM2: 1AOO58T 4.31</p>
<p>UEFI: D7E142AUS 1.71</p>
<p>DSA: DSYTD8G 9.54</p></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host:** The polling IP of the device.

SNMP Settings:

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string needed to read from the device. The default value is *public*.
  **Set community string:** The community string needed to set to the device. The default value is *public*.

## Usage

The element consists of the following pages:

- **Driver Settings:** Configuration of whether or not to use only IMM-1 or IMM-2.
- **Temperature:** Overview table of the temperatures.
- **Voltage:** Overview table of the voltages.
- **Fan:** Overview table of the fan speeds.
- **VPD:** Overview of VPD-related information (for instance: **IMM**, **CPU**, **Memory**, **Machine Level**, **System Component** and **Host MAC**).
- **Event Log:** Overview of the device's events, with the possibility to clear them.
- **Remote Access:** Status and settings for **Remote Alerts**, **Remote Access**, **SNMP**, **SNMP AF**, **Authentication**, **Port**, **Groups** and **SSH**.
- **SP:** Settings related to the SP.
- **Network Configuration:** Status and settings for **ETH**, **ETH IPv6**, **DDNS**, **SNMMP**, **DNS**, **SMTP**, **TCP Application**, **TCP Port** and **LDAP**.
- **General System Settings:** OS-related settings.
- **System Power:** Status and settings related to the System Power.
- **Restart Reset:** Settings related to the restart and reset.
- **Firmware:** Firmware-related status and settings.
- **Web Interface:** The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Note

The device is very sensitive towards polling. Some data can be retrieved quickly, while some other settings cause a much higher load for the device.
