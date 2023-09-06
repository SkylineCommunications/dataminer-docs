---
uid: Connector_help_Harmonic_System_Manager
---

# Harmonic System Manager

## About

This driver receives SNMP traps from the Harmonic Spectrum's System Manager for analysis and monitoring.

The SystemManager acts as the administrative hub of an Spectrum media server installation. Its streamlined and intuitive browser-based user interface allows users to make rapid adjustments to system configurations, integrate additional components and identify fault conditions. The SystemManager's fault reporting and alerting capabilities can head off issues before they become critical. It provides both facility wide control, as well as active monitoring and alerting.

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
<td>1.0.0.x</td>
<td><p><strong>Initial Version</strong></p>
<p>Displays SNMP traps in a table</p>
<p>Configure lifetime which traps stay in displayed table</p></td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.0.1.x [SLC Main]</td>
<td>REST API</td>
<td>1.0.0.x</td>
<td>New connection</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 9.8.0.0.5              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

#### HTTP Connection - \[HTTP Connection\]

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: (Default: 443)
- **Bus address**: (Default: ByPassProxy)



## How to use

The element consists of the following pages/subpages:

- **General:** Device Info table: (Shows the data for all Spectrum servers being monitored by System Manager).
- **Media Store:** Media storage data for devices in the System Manager database.
- **Alarms:** Displays information from alarms received from System Manager.
- **Alarm Settings:** Set if element should automatically remove alarms if they reach a certain lifetime in the element.


