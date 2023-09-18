---
uid: Connector_help_Enensys_Gigacaster_DMB
---

# Enensys GigaCaster DMB

The Enensys GigaCaster DMB is a DAB/DAB+/DMB multiplexer with audio and data encoders.

## About

This connector monitors and configures Enensys GigaCaster DMB devices over **SNMP**, with the possibility of receiving traps on alarm updates.

### Version Info

| **Range**            | **Key Features**                                                                   | **Based on** | **System Impact**                              |
|----------------------|------------------------------------------------------------------------------------|--------------|------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                   | \-           | \-                                             |
| 1.0.1.x \[SLC Main\] | Compliancies, version history, and new parameters have been added in this version. | 1.0.0.3      | Page name changed. Cassandra compliance added. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

### General

This page contains information about the device itself:

- Identification, e.g. **Device Name**, **Device Type**, **Device Serial Number**, etc.
- Hardware status, e.g. **Product Mode**, **Current Temperature**, etc.
- Generic alarm information: **Current Status**, **Alarm Current Count**.
- Date and time: **Date Time ISO**, **Date Time Unix**.
- Options: **Device Option Table**.

The page also allows you to restart the multiplexer with the **Reboot Device** button, or to reset it by entering *confirm* in the **Device Factory Reset** box. You can also have all parameters polled again with the button **Refresh all Values**.

### IP to ETI

This page contains a **Config** and **Stats** table to monitor and configure the processing for the direction IP to ETI.

### ETI to IP

This page contains a **Config** and **Stats** table to monitor and configure the processing for the direction ETI to IP.

### Alarms

On this page, you can monitor the current alarms and their history, in the **Alarm Current Table** and the **Log Table** respectively.

### Alarm Settings

On this page, you can configure each alarm individually in the **Alarm Table**. The **Trap V2 Destination Table** contains the **SNMP trap** configuration.

### Interface

On this page, you can configure each interface of the device in the **Information Table**.
