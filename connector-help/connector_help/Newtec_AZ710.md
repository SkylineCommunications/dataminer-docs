---
uid: Connector_help_Newtec_AZ710
---

# Newtec AZ710

The Newtec AZ710 is a high-performance frequency upconverter designed for broadcast, telco, and IP satellite applications. It includes features such as a calibrated high linearity over the entire bandwidth combined with a very high frequency stability. In its default configuration, the AZ710 converts IF to L-band signals. The IF input frequency can be switched between 70 MHz and 140 MHz. The L-band output frequency ranges from 950 MHz up to 1750 MHz in steps of 48 Hz. Optionally, the AZ710 can be delivered with a C, Ku, or DBS-band with an L-band monitoring output.

The high output frequency stability is provided by an internal 10 MHz reference clock. For applications requiring a very high frequency stability such as very low data rate carriers, an optional reference clock of 0.01 ppm can be ordered separately. A DC power supply and a reference frequency on the L-band output are also available as options.

With this connector, you can monitor and control the Newtec AZ710 device via RMCP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.6.0.x              | Initial version  | \-           | \-                |
| 2.0.0.x \[SLC Main\] | SNMP connection  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.6.0.x   | \-                     |
| 2.0.0.x   | 1.56                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.6.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections \[1.6.0.x\]

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Direct connection:

- **Baudrate**: Can be changed on the Serial page.

Interface connection:

  - **IP address/host**: The IP of the device.
- **IP port**: By default *5933*.
- **Bus address**: By default *100*.

### Connections \[2.0.0.x\]

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

## How to Use \[1.6.0.x\]

### General

This page contains general information regarding this device, including **Device Hardware ID**, **Control Mode**, **Operating Mode**, **RMCP Version**, etc.

In addition, specific information can be displayed or set on multiple subpages: **Device Info**, **Display**, **Power Supply**, **Security**, **Ethernet**, **Serial**, and **Config**.

### Control

This page contains technical control information: **IF To L-Band**, **10 MHz Reference Board**, and **Up Converter parameters**.

### Monitor

This page technical monitoring information, such as **10 MHz Available for Mux Out**, **IF and L-Band Output Status**, **RF Transmit Status**, etc.

### Alarms

This page contains various information about alarms.

## How to Use \[2.0.0.x\]

The **Alarm Status** page displays the **Alarm Table,** which contains an overview of the state of all the possible alarms in the system. If an alarm has the status *Fail*, you can manually clear the alarm by clicking the **Clear** button for that alarm. You can also check the corresponding **Alarm Count**, and you can reset that value to zero by clicking the **Reset** button.

On the **Converter** page and its subpages you can find information such as the **RF Gain**, **Upconverter Frequency**, and **Converter Output Level**.
