---
uid: Connector_help_Terrasat_Communications_IBUC
---

# Terrasat Communications IBUC

The **Terrasat Communications IBUC** is a highly advanced intelligent BUC with special custom features such as low phase, built-in M&C and increased RF efficiency with integrated fully automatic gain control and ALC.

## About

### Version Info

| **Range**            | **Key Features**                                 | **Based on** | **System Impact**                                                                                                                                                                                                                                         |
|----------------------|--------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                  | \-           | \-                                                                                                                                                                                                                                                        |
| 2.0.0.x              | New driver range due to firmware version change  | 1.0.0.11     | \-                                                                                                                                                                                                                                                        |
| 2.0.1.x \[obsolete\] | Mandatory changes due to firmware version change | 2.0.0.8      | The parameter descriptions "DC Voltage" (105) and "DC Current" (107) have been changed to "Supply Voltage" and "Supply Current". If these parameters are used in a script (GetParameter by name), make sure to update the referenced names in the script. |
| 2.0.2.x \[SLC Main\] | Added DCF Support, RF In and RF Out              | 2.0.1.3      | \-                                                                                                                                                                                                                                                        |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.0.1.x   | FW IBR v5.19           |
| 2.0.2.x   | FW IBR v5.19           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

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

On the **Main** **View** and **General** page, you can find monitoring parameters such as **Input** **Power** **Level**, **Output** **Power** **Level**, **Supply** **Voltage** and **Supply** **Current**.

On the **Transmitter** page, you can configure the **Attenuation**, **Gain** **Mode**, **Burst** **Timeout** and other parameters.
