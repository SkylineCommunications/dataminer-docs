---
uid: Connector_help_EEG_HD-492_CC_Encoder
---

# EEG HD-492 CC Encoder

The EEG HD-492 connector handles the monitoring of the device by polling general information and CC Encoder information. The connector can also receive traps.

## About

The HD-492 iCap Closed Caption Encoder has iCap and Lexi access as well as modern redundancy capabilities built into the unit. It offers secure web-based monitoring, real-time email status alerts, and optional cloud data warehousing and metrics.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | Build 3.1.1n, Firmware v1.52 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

On the web interface of the device, look for the SNMP module to add the IP of the DataMiner Agent to a host. If the SNMP menu module is not present, a firmware upgrade will be required from EEG.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

### General

This page displays general information about the device: the **Up Time**, the **Object ID**, the **Services** of the system, and the **Contact**, **Name**, and **Location** of the unit. Via a page button, you can find more information about the unit, including a conceptual **System** table.

### Encoder

This page displays standard information about the encoder module, such as the **Video Relay Status**, **Master Video Standard** and **Auxiliary Video Standard**. It also displays Telnet information such as the **Telnet State**, as well as the **SCTE104 Inserter State**, **Ethernet Status**, **Dash Board Status**, and **iCap Connection Status**.

### Traps

This page contains a table listing all the traps received from the source. The table is sorted by the **Time** a trap was received. It shows the **ID**, **Level**, and **Additional Information** provided by the trap.

## Notes

The OIDs for this connector do not end in ".0", as the device does not recognize them except for the general system OIDs.
