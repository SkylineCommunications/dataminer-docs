---
uid: Connector_help_Evertz_EMR-IP96-AESB
---

# Evertz EMR-IP96-AESB

The EMR is a multi-format modular router that provides a high density solution without compromising functionality. The EMR provides a unified platform for routing digital audio, analog audio, MADI audio, A-LINK audio, data, and time code. The EMR uses a packet routing core that allows for highly dense applications and also provides the flexibility for expansion as demands grow. It contains 96 Balanced AES inputs with TDM outputs.

## About

This **SNMP** driver is used to monitor and configure the **Evertz EMR-IP96-AESB** Audio Processor.

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
<li>Audio Channel Traps</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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

On the **Faults** page, the **Audio Faults** table monitors the traps for the **Audio Channel Loss**, **Audio Channel Silence** and **Audio Channel Over** types of faults.
