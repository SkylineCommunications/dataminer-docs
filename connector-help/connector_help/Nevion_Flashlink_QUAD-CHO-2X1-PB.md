---
uid: Connector_help_Nevion_Flashlink_QUAD-CHO-2X1-PB
---

# Nevion Flashlink QUAD-CHO-2X1-PB

The Nevion Flashlink QUAD-CHO-2X1-PB is a quad 2x1 3G/HD/SD-SDI changeover device with passive input bypass well-suited for quad-stream UHD/4K applications.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial range.   | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0.9.3.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device

SNMP Settings:

- **Port number:** The port of the connected device (default value: *161).*
- **Get community string:** The community string used when reading values from the device (default value: *public*).
- **Set community string:** The community string used when setting values on the device (default value: *private*).

## Usage

This is an **SNMP** connector for the Nevion Flashlink QUAD-CHO-2X1-PB device. The element created with this connector consists of the following data pages:

- **General**: Contains general information on the module.
- **Alarms**: Displays a table listing all alarms associated with the card.
- **Cable Driver**: Displays a table with information about cable parameters. Also allows you to configure the **Config** and **Slew Rate**.
- **GPIO**: Displays a table with information regarding I/O blocks. Also allows you to configure the **Mode**, **Status**, **Description** and **Alarms**.
- **Reclocker**: Displays a table with information about reclocker parameters. Also allows you to configure **Config**, **ASI**, **Bandwidth** and **Alarms**.
- **Temperature**: Displays a table with information about temperature measurements. Also allows you to configure the **Nominal** value, **Upper** and **Lower Limit** and **Alarms**.
- **Voltage**: Displays a table with information about voltage measurements, including the nominal and measured voltage and current. Also allows you to configure the **Upper** and **Lower Limit** and **Alarms**..
