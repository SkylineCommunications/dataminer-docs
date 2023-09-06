---
uid: Connector_help_WorldCast_Systems_Ecreso_FM_Single_Drive_IRT
---

# WorldCast Systems FM Single Drive IRT

The WorldCast Systems Ecreso FM Single Drive IRT is an FM transmitter.

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

The **General** page displays the **Transmitter** status, **RF**, **Local Mode**, **Faute** (Fault Status), and **Warning** status. Use the **Refresh Table** button to trigger the immediate polling of these parameters. You can also define a **Description** for the single table entry.

There is a page button that will display the **Trap** **configuration** for each of the previously mentioned parameters. As these parameters are not polled automatically, use the **Refresh Traps** button to update them.

In addition, **Current Audio** is displayed. With **Select Audio**, you can set one of the following options for the audio: *Undefined, Auto, Line 1, Line 2, Aip, Tuner, Mpx 1, Mpx 2, Aip 1, Aip 2, Tuner 1, Tuner 2, Player* and *Generator*. The Select Audio parameter is polled after you click the Refresh Table button.

The **line 1** and **line 2 alarm** are also displayed on the General page together with the **alarms** for **Mpx 1** and **Mpx 2**.

Note: A received trap will only trigger a parameter update in case the difference between its event counter and the previous trap event counter is more than 10.
