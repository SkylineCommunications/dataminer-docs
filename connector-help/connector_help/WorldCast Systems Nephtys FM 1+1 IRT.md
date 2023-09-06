---
uid: Connector_help_WorldCast_Systems_Nephtys_FM_1+1_IRT
---

# WorldCast Systems Nephtys FM 1+1 IRT

The WorldCast Systems Nephtys FM 1+1 IRT is a redundant FM transmission system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page displays the **Transmitter** status, **Pr‚sence RF**, **Local Mode**, **Faute** (Fault Status)and **Warning** status, etc. A **Refresh Table** button allows you to trigger immediate polling of the previously mentioned parameters. You can also define a **Description** for the single table entry.

Via a page button, you can view the **trap** **configuration** for each of the previously mentioned parameters. Use the **Refresh Traps** to update these parameters, as they will not be polled otherwise.

Note: A received trap will only trigger a parameter update in case the difference between its event counter and the previous trap event counter is more than the value indicated by the **Delta Trap** parameter and if **Trap Handling** ison.
