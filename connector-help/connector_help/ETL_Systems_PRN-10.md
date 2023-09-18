---
uid: Connector_help_ETL_Systems_PRN-10
---

# ETL Systems PRN-10

This SNMP connector shows the status of the different parameters of an ETL Systems PRN-10.

The ETL Systems PRN-10 is a 1U, 19" rack-mountable chassis with up to 16 DC injector modules fitted at the rear and hot-swappable dual redundant power supplies.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1v03                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the data pages detailed below.

### Chassis

This page contains information about the chassis and the modules contained within it. This includes the temperature of each module, the 5V status, etc.

There is also a **Reboot** button, which allows you to perform a soft reboot.

The page contains the following page buttons:

- **IP Settings**: Contains a table with information such as the IP address and IP subnet of the device.
- **Trap Settings**: Contains a table with trap information such as the Receiver IP Address and Trap Community.

### Modules

This page contains the Module Info Table. For each module, it mentions the type, the max voltage and the DC inject voltage status, etc.

The **Module Settings** page button displays a table with information such as the voltage of the modules, the Current/RF Alarm Level Low/High, etc.

### Reference

This page contains the **10 Mhz Info** Table, which includes information such as the RF Power, the Amp Current 1, and the Summary Alarm.

The **Reference Settings** page button displays a table with the **10 Mhz Internal Source** setting, and the **10 Mhz Gain**.

### PSU

This page contains a table with PSU info, including the status, voltage and current.
