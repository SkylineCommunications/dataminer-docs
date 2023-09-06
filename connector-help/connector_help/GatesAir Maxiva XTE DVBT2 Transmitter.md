---
uid: Connector_help_GatesAir_Maxiva_XTE_DVBT2_Transmitter
---

# GatesAir Maxiva XTE DVBT2 Transmitter

This driver monitors the activity of the GatesAir Maxiva XTE DVBT2 Transmitter.

## About

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
<td>1.0.0.x[SLC Main]</td>
<td><ul>
<li>Initial Version</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | E.3.3.0                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

## General

The General Page displays information related with the **System**, the **Transmitter** and the **Exciter**.

## Alarms

This page displays the device **Alarms.** In the subpage **Event Configuration** it is possible to configure the traps.

## Transmitter

This page displays information about the device Transmitter. More information is displayed in the **Switch** and **Versions** subpages.

## DVBT2 Modulator

This page displays the parameters and the tables related with **DVBT2 Modulator**.

## DVBT2 Alarms

In this page it is possible to check and configure the **DVBT2 Alarms.**
