---
uid: Connector_help_Rohde_Schwarz_TMU9_FM_Dual_Drive_IRT
---

# Rohde Schwarz TMU9 FM Dual Drive IRT

The Rohde Schwarz TMU9 FM Dual Drive IRT is a redundant FM transmission system. This driver can be used to monitor and control this system. The driver has a page with general information and two pop-up pages for the configuration of traps. The driver uses SNMP to retrieve and configure data.

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

The **General** page displays the **Transmitter** status, **Pr‚sence RF**, **Local Mode**, **Faute** (Fault Status) and **Warning** status, etc. Use the **Refresh Table** button to trigger the immediate polling of these parameters. The information is bundled in the **Table Service**. You can also define a **Description** for the single table entry.

There is a page button that will display the **Trap** **configuration** for each of the previously mentioned parameters. As these parameters are not polled automatically, use the **Refresh Traps** button to update them.

A second page button displays the **Trap Handler** subpage, which allows you to enable or disable **Trap Handling** and to set the **Trap Delta**.

Note: A received trap will only trigger a parameter update if **Trap Handling** is enabled and the difference between the trap event counter and the previous trap event counter is more than the value of the **Trap Delta** parameter.
