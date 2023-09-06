---
uid: Connector_help_Evertz_570XS_Decoder
---

# Evertz 570XS Decoder

This connector is designed to monitor the information of the Evertz 570XS decoder and interact with this device, using **SNMP** communication.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The following pages are available:

- **General**: Displays system information and allows you to execute a **reboot**. A subpage is available, which displays the **SFP monitor** table.
- **Card**: Contains information regarding the **decoder card software** and **hardware**. A subpage is available, which displays the Log Stream table.
- **Product Features**: Displays the **license information** and the **product feature table**.
- **Network Management**: Contains multiple tables, with the configuration for the different connections.
- **Timing**: Displays **PTP** failover information.
- **Input** and **Output**: These pages contain tables with status information for the different inputs and outputs. The Output page has 4 subpages reflecting the different kinds of outputs: **Video, Video IP, Audio IP** and **ANC IP**.
- **Decoder Control**, **Decoder Program Monitor** and **IP Input Monitor**: These pages contain tables for multiple receivers and packets received.
- **System Notify**, **Input Notify** and **Decoder Notify**: These pages display the faults and notifications of the device.
- **SNMP Setup**: Allows you to add an **SNMP trap** as well as display the **current configured traps**.
