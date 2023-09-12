---
uid: Connector_help_ATX_Networks_ChromaFlex
---

# ATX Networks ChromaFlex

ATX's ChromaFlex platform and its application-specific modules have been designed for headend and major hub site applications where performance, versatility, and space efficiency are of the highest importance.

The ChromaFlex platform is a mid-plane design with blind mate connectors, 2RU passive chassis with support for redundant power supplies, 8 application-specific modules, and remote monitoring and control of all important operating parameters.

The application modules include the high-performance Chromadigm DWDM transmitter, 1310 nm and DWDM directly modulated transmitters, optical amplifiers, return path receivers, optical destackers, and optical and RF switches.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.3-4.10               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                        |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \- [ATX Networks ChromaFlex - DMTx](/Driver%20Help/ATX%20Networks%20ChromaFlex%20-%20DMTx.aspx) - [ATX Networks ChromaFlex - QRRX](xref:Connector_help_ATX_Networks_ChromaFlex_-_QRRX) |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page contains system information parameters, such as the **Software Version**, **Hardware Version**, **Model Name**, **Serial Number**, and **Module Temperature**.

### Modules

This page contains the **Modules Table**. This table displays all the modules of the device.

### DMTx

This page contains 2 tables: **DMTx Modules Table** and **DMTx Lasers Table**.

For each module in the DMTx Modules Table, the **Slot State** indicates the status of the DVE, and the **Remove Module** button allows you to delete the DVE.

With the **DMTx Auto Remove** parameter, you can enable or disable the automatic removal of **unequipped** DVE modules.

Laser entries that are no longer available for the duration of the **DMTx Lasers** **Expiration Time** will be removed from the table. In case you want the table entries to stay present for a longer period of time, set this parameter to a different value than the default value of 0.

### QRRX

This page contains 2 tables: **QRRX** **Modules Table** and **QRRX Lasers Table**.

For each module in QRRX Modules Table, the **Slot State** indicates the status of the DVE, and the **Remove Module** button allows you to delete the DVE.

With the **QRRX** **Auto Remove** parameter, you can enable or disable the automatic removal of **unequipped** DVE modules.

Laser entries that are no longer available for the duration of the **QRRX** **Lasers** **Expiration Time** will be removed from the table. In case you want the table entries to stay present for a longer period of time, set this parameter to a different value than the default value of 0.
